using System.ComponentModel.DataAnnotations;

namespace Labb2Linq.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Teacher name is required")]
        [StringLength(200), MinLength(2)]
        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }

        public virtual ICollection<CourseTeacher>? CourseTeachers { get; set; }
    }
}
