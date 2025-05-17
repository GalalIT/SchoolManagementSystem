using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.DTO
{
    public class ClassDto
    {
        public int Id { get; set; }

        [Display(Name = "اسم الصف", Description = "Class Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "كود الصف", Description = "Class Code")]
        public string Code { get; set; } = string.Empty;

        [Display(Name = "السنة الدراسية", Description = "Academic Year")]
        public string AcademicYear { get; set; } = string.Empty;

        // Optionally include related counts
        [Display(Name = "عدد الطلاب", Description = "Number of Students")]
        public int StudentCount { get; set; }

        [Display(Name = "عدد المواد", Description = "Number of Subjects")]
        public int SubjectCount { get; set; }
    }

    public class CreateClassDto
    {
        [Required(ErrorMessage = "اسم الصف مطلوب | Class name is required")]
        [StringLength(50, ErrorMessage = "يجب ألا يتجاوز اسم الصف 50 حرفًا | Class name must not exceed 50 characters")]
        [Display(Name = "اسم الصف", Description = "Class Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "كود الصف مطلوب | Class code is required")]
        [StringLength(20, ErrorMessage = "يجب ألا يتجاوز كود الصف 20 حرفًا | Class code must not exceed 20 characters")]
        [Display(Name = "كود الصف", Description = "Class Code")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "السنة الدراسية مطلوبة | Academic year is required")]
        [StringLength(20, ErrorMessage = "يجب ألا تتجاوز السنة الدراسية 20 حرفًا | Academic year must not exceed 20 characters")]
        [Display(Name = "السنة الدراسية", Description = "Academic Year")]
        public string AcademicYear { get; set; } = string.Empty;
    }
    public class UpdateClassDto
    {
        [Required(ErrorMessage = "معرف الصف مطلوب | Class ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف الصف غير صالح | Invalid class ID")]
        [Display(Name = "معرف الصف", Description = "Class ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم الصف مطلوب | Class name is required")]
        [StringLength(50, ErrorMessage = "يجب ألا يتجاوز اسم الصف 50 حرفًا | Class name must not exceed 50 characters")]
        [Display(Name = "اسم الصف", Description = "Class Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "كود الصف مطلوب | Class code is required")]
        [StringLength(20, ErrorMessage = "يجب ألا يتجاوز كود الصف 20 حرفًا | Class code must not exceed 20 characters")]
        [Display(Name = "كود الصف", Description = "Class Code")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "السنة الدراسية مطلوبة | Academic year is required")]
        [StringLength(20, ErrorMessage = "يجب ألا تتجاوز السنة الدراسية 20 حرفًا | Academic year must not exceed 20 characters")]
        [Display(Name = "السنة الدراسية", Description = "Academic Year")]
        public string AcademicYear { get; set; } = string.Empty;
    }
    public class DeleteClassDto
    {
        [Required(ErrorMessage = "معرف الصف مطلوب | Class ID is required")]
        [Display(Name = "معرف الصف", Description = "Class ID")]
        public int Id { get; set; }
    }

}
