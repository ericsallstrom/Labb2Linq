using System.ComponentModel.DataAnnotations;

namespace Labb2Linq.ViewModels
{
    public class StudentsWithTeachersVM
    {
        public int StudentsWithTeachersId { get; set; }

        [Display(Name = "Students")]
        public string StudentName { get; set; }
        public IEnumerable<string> Teachers { get; set; }
        [Display(Name = "Class")]
        public string ClassName { get; set; }
    }
}
