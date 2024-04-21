using Labb2Linq.Models;
using System.ComponentModel.DataAnnotations;

namespace Labb2Linq.ViewModels
{
    public class GetAllStudentsWithTeachersVM
    {
        [Display(Name = "Student")]
        public string StudentName { get; set; }

        public List<Teacher> Teachers { get; set; }

        [Display(Name = "Class")]
        public string ClassName { get; set; }
    }
}
