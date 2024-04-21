using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2Linq.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        [StringLength(200), MinLength(2)]
        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [ForeignKey("ClassList")]
        public int FkClassId { get; set; }
        public ClassList? ClassList { get; set; }

        public ICollection<StudentCourse>? StudentCourses { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
        
    }
}
