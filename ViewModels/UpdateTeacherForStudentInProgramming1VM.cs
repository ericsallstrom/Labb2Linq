using Labb2Linq.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Labb2Linq.ViewModels
{
    public class UpdateTeacherForStudentInProgramming1VM    
    {
        [Required(ErrorMessage = "You must select a student.")]
        [Display(Name = "Student")]
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        public SelectList? StudentList { get; set; }
        
        public Course? Course { get; set; }

        [Required(ErrorMessage = "You must select a teacher.")]
        public int? TeacherId { get; set; }        
        public Teacher? Teacher { get; set; }
        public SelectList? CurrentTeachers { get; set; }

        [Required(ErrorMessage = "You must select a new teacher.")]
        public int? NewTeacherId { get; set; }
        public Teacher? NewTeacher { get; set; }
        public SelectList? AvailableTeachers { get; set; }
    }
}
