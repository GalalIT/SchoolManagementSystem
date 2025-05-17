using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.DTO
{
    public class TeacherDto
    {
        public int Id { get; set; }

        [Display(Name = "معرف المستخدم | User ID")]
        public string UserId { get; set; } = string.Empty;

        [Display(Name = "التخصص | Specialization")]
        public string? Specialization { get; set; }

        [Display(Name = "تاريخ التعيين | Hire Date")]
        public DateTime HireDate { get; set; }
    }
    public class CreateTeacherDto
    {
        [Required(ErrorMessage = "معرف المستخدم مطلوب | User ID is required")]
        [Display(Name = "معرف المستخدم | User ID")]
        public string UserId { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "يجب ألا تتجاوز التخصص 100 حرف | Specialization must not exceed 100 characters")]
        [Display(Name = "التخصص | Specialization")]
        public string? Specialization { get; set; }

        [Required(ErrorMessage = "تاريخ التعيين مطلوب | Hire date is required")]
        [Display(Name = "تاريخ التعيين | Hire Date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
    public class UpdateTeacherDto
    {
        [Required(ErrorMessage = "معرف المعلم مطلوب | Teacher ID is required")]
        [Display(Name = "معرف المعلم | Teacher ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "معرف المستخدم مطلوب | User ID is required")]
        [Display(Name = "معرف المستخدم | User ID")]
        public string UserId { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "يجب ألا تتجاوز التخصص 100 حرف | Specialization must not exceed 100 characters")]
        [Display(Name = "التخصص | Specialization")]
        public string? Specialization { get; set; }

        [Required(ErrorMessage = "تاريخ التعيين مطلوب | Hire date is required")]
        [Display(Name = "تاريخ التعيين | Hire Date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
    public class DeleteTeacherDto
    {
        [Required(ErrorMessage = "معرف المعلم مطلوب | Teacher ID is required")]
        public int Id { get; set; }
    }

}
