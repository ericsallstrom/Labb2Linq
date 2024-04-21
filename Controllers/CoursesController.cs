using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb2Linq.Data;
using Labb2Linq.Models;
using Labb2Linq.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Labb2Linq.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ApplicationDbContext> _logger;

        public CoursesController(ApplicationDbContext context, ILogger<ApplicationDbContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTeachersInProgramming1()
        {
            var teachersInProgramming1 = await _context.Courses
                .Where(c => c.CourseName == "Programmering 1")
                .Include(c => c.CourseTeachers)
                    .ThenInclude(ct => ct.Teacher)
                .Select(c => new GetTeachersInProgramming1VM
                {
                    CourseName = c.CourseName,
                    Teachers = c.CourseTeachers.Select(ct => ct.Teacher).ToList()
                })
                .FirstOrDefaultAsync();

            return View(teachersInProgramming1);
        }

        public async Task<IActionResult> GetAllStudentsWithTeachers()
        {
            var allStudentsWithTeachers = await _context.Students
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                        .ThenInclude(c => c.CourseTeachers)
                            .ThenInclude(ct => ct.Teacher)
                .Select(s => new GetAllStudentsWithTeachersVM
                {
                    StudentName = s.StudentName,
                    Teachers = s.StudentCourses
                        .SelectMany(sc => sc.Course.CourseTeachers.Select(ct => ct.Teacher))
                        .Distinct()
                        .ToList(),
                    ClassName = s.ClassList.ClassName
                })
                .OrderBy(s => s.ClassName)
                .ToListAsync();

            return View(allStudentsWithTeachers);
        }

        public async Task<IActionResult> GetStudentsWithTeachersInProgramming1()
        {
            var studentsWithTeachersInProgramming1 = await _context.Courses
                .Where(c => c.CourseName == "Programmering 1")
                .SelectMany(c => c.StudentCourses.Select(sc => new GetStudentsWithTeachersInProgramming1VM
                {
                    StudentName = sc.Student.StudentName,
                    Teachers = c.CourseTeachers.Select(ct => ct.Teacher).Distinct().ToList(),
                    CourseName = c.CourseName,
                    ClassName = sc.Student.ClassList.ClassName
                }))
                .ToListAsync();

            return View(studentsWithTeachersInProgramming1);
        }

        public async Task<IActionResult> GetAllCourses()
        {
            return View(await _context.Courses.ToListAsync());
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,CourseName")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public async Task<IActionResult> UpdateTeacherForStudentInProgramming1()
        {
            var studentsInProgramming1 = await _context.Students
                .Where(s => s.StudentCourses.Any(sc => sc.Course.CourseName == "Programmering 1"))
                .ToListAsync();

            var programming1Course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseName == "Programmering 1");

            var teachersInProgramming1 = await _context.CourseTeachers
                .Where(ct => ct.FkCourseId == programming1Course.CourseId)
                .Select(ct => ct.Teacher).Distinct()
                .ToListAsync();

            var teachersInProgramming1Ids = teachersInProgramming1.Select(t => t.TeacherId);
            var restOfTheTeachers = await _context.Teachers
                .Where(t => !teachersInProgramming1Ids.Contains(t.TeacherId))
                .ToListAsync();

            var viewModel = new UpdateTeacherForStudentInProgramming1VM
            {
                StudentList = new SelectList(studentsInProgramming1, "StudentId", "StudentName"),
                Course = programming1Course,
                CurrentTeachers = new SelectList(teachersInProgramming1, "TeacherId", "TeacherName"),
                AvailableTeachers = new SelectList(restOfTheTeachers, "TeacherId", "TeacherName"),
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTeacherForStudentInProgramming1(UpdateTeacherForStudentInProgramming1VM viewModel)
        {
            if (viewModel.StudentId != null && viewModel.TeacherId != null && viewModel.NewTeacherId != null)
            {
                var selectedStudent = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == viewModel.StudentId);

                if (selectedStudent != null && ModelState.IsValid)
                {
                    try
                    {
                        var oldCourseTeacher = await _context.CourseTeachers
                            .FirstOrDefaultAsync(ct => ct.FkTeacherId == viewModel.TeacherId && ct.FkCourseId == viewModel.Course.CourseId);

                        if (oldCourseTeacher != null)
                        {
                            _context.CourseTeachers.Remove(oldCourseTeacher);
                            await _context.SaveChangesAsync();
                        }

                        var newCourseTeacher = new CourseTeacher
                        {
                            FkTeacherId = viewModel.NewTeacherId.Value,
                            FkCourseId = viewModel.Course.CourseId
                        };

                        _context.CourseTeachers.Add(newCourseTeacher);
                        await _context.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        return NotFound();
                    }
                }
            }
            
            var programming1Course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseName == "Programmering 1");
            var teachersInProgramming1 = await _context.CourseTeachers
                .Where(ct => ct.FkCourseId == programming1Course.CourseId)
                .Select(ct => ct.Teacher)
                .Distinct()
                .ToListAsync();

            var teachersInProgramming1Ids = teachersInProgramming1.Select(t => t.TeacherId);
            var restOfTheTeachers = await _context.Teachers
                .Where(t => !teachersInProgramming1Ids.Contains(t.TeacherId))
                .ToListAsync();

            viewModel.Course = programming1Course;
            viewModel.StudentList = new SelectList(await _context.Students.ToListAsync(), "StudentId", "StudentName");
            viewModel.CurrentTeachers = new SelectList(teachersInProgramming1, "TeacherId", "TeacherName");
            viewModel.AvailableTeachers = new SelectList(restOfTheTeachers, "TeacherId", "TeacherName");

            return View(viewModel);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseId == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,CourseName")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }

        private bool CourseTeacherExists(int teacherId, int courseId)
        {
            return _context.CourseTeachers.Any(ct => ct.FkTeacherId == teacherId && ct.FkCourseId == courseId);
        }
    }
}
