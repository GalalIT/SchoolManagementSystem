using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.Entities
{
    public class Subject
    {
        [Key]
        [Display(Name = "معرف المادة | Subject ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم المادة مطلوب | Subject name is required")]
        [StringLength(100, ErrorMessage = "يجب ألا يتجاوز اسم المادة 100 حرف | Subject name must not exceed 100 characters")]
        [Display(Name = "اسم المادة | Subject Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "كود المادة مطلوب | Subject code is required")]
        [StringLength(20, ErrorMessage = "يجب ألا يتجاوز كود المادة 20 حرفًا | Subject code must not exceed 20 characters")]
        [Display(Name = "كود المادة | Subject Code")]
        public string Code { get; set; } = string.Empty;

        // Navigation properties
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();
    }
}
