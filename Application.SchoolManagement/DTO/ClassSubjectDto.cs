using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.DTO
{
    public class ClassSubjectDto
    {
        public int Id { get; set; }

        [Display(Name = "الصف", Description = "Class")]
        public int ClassId { get; set; }

        [Display(Name = "اسم الصف", Description = "Class Name")]
        public string ClassName { get; set; } = string.Empty;

        [Display(Name = "المادة", Description = "Subject")]
        public int SubjectId { get; set; }

        [Display(Name = "اسم المادة", Description = "Subject Name")]
        public string SubjectName { get; set; } = string.Empty;

        [Display(Name = "المعلم", Description = "Teacher")]
        public int? TeacherId { get; set; }

        [Display(Name = "اسم المعلم", Description = "Teacher Name")]
        public string? TeacherName { get; set; }
    }

    public class CreateClassSubjectDto
    {
        [Required(ErrorMessage = "الصف مطلوب | Class is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف الصف غير صالح | Invalid class ID")]
        [Display(Name = "الصف", Description = "Class")]
        public int ClassId { get; set; }

        [Required(ErrorMessage = "المادة مطلوبة | Subject is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف المادة غير صالح | Invalid subject ID")]
        [Display(Name = "المادة", Description = "Subject")]
        public int SubjectId { get; set; }

        [Display(Name = "المعلم", Description = "Teacher")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف المعلم غير صالح | Invalid teacher ID")]
        public int? TeacherId { get; set; }
    }
    public class UpdateClassSubjectDto
    {
        [Required(ErrorMessage = "المعرف مطلوب | ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف غير صالح | Invalid ID")]
        [Display(Name = "المعرف", Description = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "الصف مطلوب | Class is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف الصف غير صالح | Invalid class ID")]
        [Display(Name = "الصف", Description = "Class")]
        public int ClassId { get; set; }

        [Required(ErrorMessage = "المادة مطلوبة | Subject is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف المادة غير صالح | Invalid subject ID")]
        [Display(Name = "المادة", Description = "Subject")]
        public int SubjectId { get; set; }

        [Display(Name = "المعلم", Description = "Teacher")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف المعلم غير صالح | Invalid teacher ID")]
        public int? TeacherId { get; set; }
    }

    public class DeleteClassSubjectDto
    {
        [Required(ErrorMessage = "المعرف مطلوب | ID is required")]
        [Display(Name = "المعرف", Description = "ID")]
        public int Id { get; set; }
    }

}
