using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2Linq.Models
{
    public class ClassList
    {
        [Key]
        public int ClassId { get; set; }

        [Required(ErrorMessage = "Class name is required.")]
        [StringLength(50), MinLength(3)]
        [Display(Name = "Class")]
        public string ClassName { get; set; }

        public virtual ICollection<Student>? Students { get; set; }        
    }  
}
