using Labb2Linq.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Labb2Linq.ViewModels
{
    public class GetStudentsWithTeachersInProgramming1VM
    {
        [Display(Name = "Student")]
        public string StudentName { get; set; }
        public List<Teacher> Teachers { get; set; }

        [Display(Name = "Course")]
        public string CourseName { get; set; }

        [Display(Name = "Class")]
        public string ClassName { get; set; }
    }
}
