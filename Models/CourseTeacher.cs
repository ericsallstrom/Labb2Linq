using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2Linq.Models
{
    public class CourseTeacher
    {
        [Key]
        public int CourseTeacherId { get; set; }

        [ForeignKey("Teacher")]
        public int FkTeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [ForeignKey("Course")]
        public int FkCourseId { get; set; }
        public Course Course { get; set; }
    }
}
