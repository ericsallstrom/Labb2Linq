using Labb2Linq.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb2Linq.Controllers
{
    public class CourseTeachersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseTeachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTeachersForProgramming1()
        {
            var teachers = await _context.Courses
                .Where(c => c.CourseName == "Programmering 1")
                .Include(c => c.CourseTeachers)
                    .ThenInclude(ct => ct.Teacher)                                
                .ToListAsync();

            return View(teachers);
        }
    }
}
