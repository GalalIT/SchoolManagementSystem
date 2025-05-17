using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.Entities
{
    public class Student
    {
        [Key]
        [Display(Name = "معرف الطالب | Student ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "معرف المستخدم مطلوب | User ID is required")]
        [Display(Name = "معرف المستخدم | User ID")]
        public string UserId { get; set; } = string.Empty;

        [Display(Name = "الصف | Class")]
        public int? ClassId { get; set; }

        [Required(ErrorMessage = "رقم التسجيل مطلوب | Enrollment number is required")]
        [StringLength(20, ErrorMessage = "يجب ألا يتجاوز رقم التسجيل 20 حرفًا | Enrollment number must not exceed 20 characters")]
        [Display(Name = "رقم التسجيل | Enrollment Number")]
        public string EnrollmentNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "تاريخ التسجيل مطلوب | Enrollment date is required")]
        [Display(Name = "تاريخ التسجيل | Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [Required(ErrorMessage = "تاريخ الميلاد مطلوب | Date of birth is required")]
        [Display(Name = "تاريخ الميلاد | Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        // Navigation properties
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;
        [ForeignKey(nameof(ClassId))]
        public virtual Class? Class { get; set; }
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
        //public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public virtual ICollection<ParentStudent> ParentStudents { get; set; } = new List<ParentStudent>();
        public virtual ICollection<Attendance> Attendance { get; set; } = new List<Attendance>();
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
