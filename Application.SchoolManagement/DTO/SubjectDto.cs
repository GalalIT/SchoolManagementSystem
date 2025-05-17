using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.DTO
{
    public class SubjectDto
    {
        public int Id { get; set; }

        [Display(Name = "اسم المادة | Subject Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "كود المادة | Subject Code")]
        public string Code { get; set; } = string.Empty;
    }

    public class CreateSubjectDto
    {
        [Required(ErrorMessage = "اسم المادة مطلوب | Subject name is required")]
        [StringLength(100, ErrorMessage = "يجب ألا يتجاوز اسم المادة 100 حرف | Subject name must not exceed 100 characters")]
        [Display(Name = "اسم المادة | Subject Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "كود المادة مطلوب | Subject code is required")]
        [StringLength(20, ErrorMessage = "يجب ألا يتجاوز كود المادة 20 حرفًا | Subject code must not exceed 20 characters")]
        [Display(Name = "كود المادة | Subject Code")]
        public string Code { get; set; } = string.Empty;
    }
    public class UpdateSubjectDto
    {
        [Required(ErrorMessage = "معرف المادة مطلوب | Subject ID is required")]
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
    }
    public class DeleteSubjectDto
    {
        [Required(ErrorMessage = "معرف المادة مطلوب | Subject ID is required")]
        public int Id { get; set; }
    }

}
