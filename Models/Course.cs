using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Labb2Linq.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(100), MinLength(3)]
        [Display(Name = "Course")]
        public string CourseName { get; set; }

        public virtual ICollection<CourseTeacher>? CourseTeachers { get; set; }    
        public virtual ICollection<StudentCourse>? StudentCourses { get; set; }
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}
