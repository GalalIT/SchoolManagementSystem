using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.DTO
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        [Display(Name = "اسم الطالب | Student Name")]
        public string FullName { get; set; } = string.Empty; // from ApplicationUser

        [Display(Name = "الصف | Class")]
        public int? ClassId { get; set; }

        [Display(Name = "اسم الصف | Class Name")]
        public string? ClassName { get; set; }

        [Display(Name = "رقم التسجيل | Enrollment Number")]
        public string EnrollmentNumber { get; set; } = string.Empty;

        [Display(Name = "تاريخ التسجيل | Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "تاريخ الميلاد | Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }

    public class CreateStudentDto
    {
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
    }
    public class UpdateStudentDto
    {
        [Required(ErrorMessage = "المعرف مطلوب | Student ID is required")]
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
    }
    public class DeleteStudentDto
    {
        [Required(ErrorMessage = "معرف الطالب مطلوب | Student ID is required")]
        public int Id { get; set; }
    }

}
