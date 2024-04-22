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
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ApplicationDbContext context, ILogger<CoursesController> logger)
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
            var viewModel = await CreateUpdateTeacherForStudentViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTeacherForStudentInProgramming1(UpdateTeacherForStudentInProgramming1VM viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = await CreateUpdateTeacherForStudentViewModel();
                return View(viewModel);
            }

            var selectedStudent = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == viewModel.StudentId);

            if (selectedStudent == null)
            {
                return NotFound();
            }

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

        private async Task<UpdateTeacherForStudentInProgramming1VM> CreateUpdateTeacherForStudentViewModel()
        {
            var programming1Course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseName == "Programmering 1");
            var studentsInProgramming1 = await _context.Students
             .Where(s => s.StudentCourses.Any(sc => sc.Course.CourseName == "Programmering 1"))
             .ToListAsync();
            var teachersInProgramming1 = await _context.CourseTeachers
                .Where(ct => ct.FkCourseId == programming1Course.CourseId)
                .Select(ct => ct.Teacher)
                .Distinct()
                .ToListAsync();

            var teachersInProgramming1Ids = teachersInProgramming1.Select(t => t.TeacherId);
            var restOfTheTeachers = await _context.Teachers
                .Where(t => !teachersInProgramming1Ids.Contains(t.TeacherId))
                .ToListAsync();

            var viewModel = new UpdateTeacherForStudentInProgramming1VM
            {
                Course = programming1Course,
                StudentList = new SelectList(studentsInProgramming1, "StudentId", "StudentName"),
                CurrentTeachers = new SelectList(teachersInProgramming1, "TeacherId", "TeacherName"),
                AvailableTeachers = new SelectList(restOfTheTeachers, "TeacherId", "TeacherName"),
            };

            return viewModel;
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
