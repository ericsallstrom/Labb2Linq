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
    }
}

