using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.DTO
{
    public class ParentDto
    {
        public int Id { get; set; }

        [Display(Name = "معرف المستخدم", Description = "User ID")]
        public string UserId { get; set; } = string.Empty;

        [Display(Name = "اسم المستخدم", Description = "User Name")]
        public string UserName { get; set; } = string.Empty;

        [Display(Name = "رقم الهاتف", Description = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "المهنة", Description = "Occupation")]
        public string? Occupation { get; set; }
    }

    public class CreateParentDto
    {
        [Required(ErrorMessage = "معرف المستخدم مطلوب | User ID is required")]
        [Display(Name = "معرف المستخدم", Description = "User ID")]
        public string UserId { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "يجب ألا يتجاوز رقم الهاتف 20 رقمًا | Phone number must not exceed 20 digits")]
        [Display(Name = "رقم الهاتف", Description = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "يجب ألا تتجاوز المهنة 100 حرف | Occupation must not exceed 100 characters")]
        [Display(Name = "المهنة", Description = "Occupation")]
        public string? Occupation { get; set; }
    }
    public class UpdateParentDto
    {
        [Required(ErrorMessage = "المعرف مطلوب | ID is required")]
        [Display(Name = "المعرف", Description = "Parent ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "معرف المستخدم مطلوب | User ID is required")]
        [Display(Name = "معرف المستخدم", Description = "User ID")]
        public string UserId { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "يجب ألا يتجاوز رقم الهاتف 20 رقمًا | Phone number must not exceed 20 digits")]
        [Display(Name = "رقم الهاتف", Description = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "يجب ألا تتجاوز المهنة 100 حرف | Occupation must not exceed 100 characters")]
        [Display(Name = "المهنة", Description = "Occupation")]
        public string? Occupation { get; set; }
    }
    public class DeleteParentDto
    {
        [Required(ErrorMessage = "المعرف مطلوب | ID is required")]
        [Display(Name = "المعرف", Description = "Parent ID")]
        public int Id { get; set; }
    }

}
