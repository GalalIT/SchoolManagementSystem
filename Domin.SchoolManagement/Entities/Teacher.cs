using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.Entities
{
    public class Teacher
    {
        [Key]
        [Display(Name = "معرف المعلم | Teacher ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم المستخدم مطلوب | User Name is required")]
        [Display(Name = "معرف المستخدم | User ID")]
        public string UserId { get; set; } = string.Empty;
        [Required(ErrorMessage = "اسم المستخدم مطلوب | User Name is required")]
        [Display(Name = "اسم المستخدم | User Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "يجب ألا تتجاوز التخصص 100 حرف | Specialization must not exceed 100 characters")]
        [Display(Name = "التخصص | Specialization")]
        public string? Specialization { get; set; }

        [Required(ErrorMessage = "تاريخ التعيين مطلوب | Hire date is required")]
        [Display(Name = "تاريخ التعيين | Hire Date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        // Navigation properties
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();
        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
