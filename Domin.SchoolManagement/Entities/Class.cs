using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.Entities
{
    public class Class
    {
        [Key]
        [Display(Name = "معرف الصف | Class ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم الصف مطلوب | Class name is required")]
        [StringLength(50, ErrorMessage = "يجب ألا يتجاوز اسم الصف 50 حرفًا | Class name must not exceed 50 characters")]
        [Display(Name = "اسم الصف | Class Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "كود الصف مطلوب | Class code is required")]
        [StringLength(20, ErrorMessage = "يجب ألا يتجاوز كود الصف 20 حرفًا | Class code must not exceed 20 characters")]
        [Display(Name = "كود الصف | Class Code")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "السنة الدراسية مطلوبة | Academic year is required")]
        [Display(Name = "السنة الدراسية | Academic Year")]
        public string AcademicYear { get; set; } = string.Empty;

        // Navigation properties
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();
    }
}
