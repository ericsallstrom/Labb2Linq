using Labb2Linq.Models;
using System.ComponentModel.DataAnnotations;

namespace Labb2Linq.ViewModels
{
    public class GetTeachersInProgramming1VM
    {
        [Display(Name = "Course")]
        public string CourseName { get; set; }        

        [Display(Name = "Name")]
        public List<Teacher> Teachers { get; set; }
    }
}
