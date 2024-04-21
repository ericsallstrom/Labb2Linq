using Labb2Linq.Data;
using Labb2Linq.Models;
using Labb2Linq.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Labb2Linq.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllStudentsWithTeachers()
        {
            var studentsWithTeachers = await _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                        .ThenInclude(c => c.CourseTeachers)
                            .ThenInclude(ct => ct.Teacher)
                .Include(s => s.ClassList)
                .OrderBy(s => s.ClassList.ClassName)
                .ThenBy(s => s.StudentName)
                .Select(s => new StudentsWithTeachersVM
                {
                    StudentName = s.StudentName,
                    Teachers = s.Enrollments
                        .SelectMany(e => e.Course.CourseTeachers.Select(ct => ct.Teacher.TeacherName))
                        .Distinct(),
                    ClassName = s.ClassList.ClassName
                })
               .ToListAsync();

            return View(studentsWithTeachers);
        }

        public async Task<IActionResult> GetStudentsForProgramming1()
        {
            var studentsInProgramming1 = await _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                        .ThenInclude(c => c.CourseTeachers)
                            .ThenInclude(ct => ct.Teacher)
                .Include(s => s.ClassList)
                .Where(s => s.Enrollments.Any(e => e.Course.CourseName == "Programmering 1"))
                .OrderBy(s => s.ClassList.ClassName)
                .ThenBy(s => s.StudentName)
                .Select(s => new StudentsWithTeachersVM
                {
                    StudentName = s.StudentName,
                    Teachers = s.Enrollments
                        .SelectMany(e => e.Course.CourseTeachers.Select(ct => ct.Teacher.TeacherName))
                        .Distinct(),
                    ClassName = s.ClassList.ClassName
                })
               .ToListAsync();

            return View(studentsInProgramming1);
        }

        public async Task<IActionResult> UpdateTeacherForStudent(int? studentId, int? teacherId)
        {
            if (studentId == null || teacherId == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                        .ThenInclude(c => c.CourseTeachers)
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student == null)
            {
                return NotFound();
            }

            // Hitta kursen "programmering1" för eleven
            var programming1Course = student.Enrollments
                .FirstOrDefault(e => e.Course.CourseName == "Programmering 1")?.Course;

            if (programming1Course == null)
            {
                return NotFound("Student is not enrolled in 'Programmering 1'.");
            }

            var chosenTeacher = await _context.Teachers.FindAsync(teacherId);

            if (chosenTeacher == null)
            {
                return NotFound("Selected teacher is not found.");
            }

                                            

            // Spara ändringar i databasen
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var enrollment = await _context.Enrollments.FindAsync(id);
        //    if (enrollment == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", enrollment.FkCourseId);
        //    ViewData["FkStudentId"] = new SelectList(_context.Students, "StudentId", "StudentName", enrollment.FkStudentId);
        //    return View(enrollment);
        //}
    }
}

