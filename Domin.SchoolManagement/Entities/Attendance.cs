using Domin.SchoolManagement.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.Entities
{
    public class Attendance
    {
        [Key]
        [Display(Name = "معرف الحضور | Attendance ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "الطالب مطلوب | Student is required")]
        [Display(Name = "الطالب | Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "المادة مطلوبة | Class subject is required")]
        [Display(Name = "المادة | Subject")]
        public int ClassSubjectId { get; set; }

        [Required(ErrorMessage = "التاريخ مطلوب | Date is required")]
        [Display(Name = "التاريخ | Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "حالة الحضور مطلوبة | Attendance status is required")]
        [Display(Name = "الحالة | Status")]
        public AttendanceStatus Status { get; set; }

        [Display(Name = "ملاحظات | Notes")]
        public string? Notes { get; set; }

        // Navigation properties
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
        [ForeignKey(nameof(ClassSubjectId))]
        public virtual ClassSubject ClassSubject { get; set; } = null!;
    }
}
