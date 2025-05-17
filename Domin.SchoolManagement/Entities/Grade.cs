using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.Entities
{
    public class Grade
    {
        [Key]
        [Display(Name = "معرف الدرجة | Grade ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "الطالب مطلوب | Student is required")]
        [Display(Name = "الطالب | Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "المادة مطلوبة | Subject is required")]
        [Display(Name = "المادة | Subject")]
        public int ClassSubjectId { get; set; }

        [Required(ErrorMessage = "الدرجة مطلوبة | Grade value is required")]
        [Range(0, 100, ErrorMessage = "يجب أن تكون الدرجة بين 0 و100 | Grade must be between 0 and 100")]
        [Display(Name = "الدرجة | Grade")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "تاريخ الدرجة مطلوب | Grade date is required")]
        [Display(Name = "التاريخ | Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "ملاحظات | Notes")]
        public string? Notes { get; set; }

        // Navigation properties
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
        [ForeignKey(nameof(ClassSubjectId))]
        public virtual ClassSubject ClassSubject { get; set; } = null!;
    }
}
