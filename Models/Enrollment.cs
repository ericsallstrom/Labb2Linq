using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2Linq.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }        

        [ForeignKey("Student")]
        [Required(ErrorMessage = "Student is required")]
        public int FkStudentId { get; set; }
        public Student? Student { get; set; }

        [ForeignKey("Course")]
        [Required(ErrorMessage = "Course is required")]
        public int FkCourseId { get; set; }
        public Course? Course { get; set; }

        public Grade? Grade { get; set; }
    }

    public enum Grade   
    {
        A,
        B, 
        C,
        D,
        E,
        F
    }
}
