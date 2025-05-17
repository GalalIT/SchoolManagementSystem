using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.DTO
{
    public class GradeDto
    {
        public int Id { get; set; }

        [Display(Name = "الطالب", Description = "Student")]
        public int StudentId { get; set; }

        [Display(Name = "اسم الطالب", Description = "Student Name")]
        public string StudentName { get; set; } = string.Empty;

        [Display(Name = "المادة", Description = "Subject")]
        public int ClassSubjectId { get; set; }

        [Display(Name = "اسم المادة", Description = "Subject Name")]
        public string ClassSubjectName { get; set; } = string.Empty;

        [Display(Name = "الدرجة", Description = "Grade")]
        public decimal Value { get; set; }

        [Display(Name = "التاريخ", Description = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "ملاحظات", Description = "Notes")]
        public string? Notes { get; set; }
    }

    public class CreateGradeDto
    {
        [Required(ErrorMessage = "الطالب مطلوب | Student is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف الطالب غير صالح | Invalid student ID")]
        [Display(Name = "الطالب", Description = "Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "المادة مطلوبة | Subject is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف المادة غير صالح | Invalid subject ID")]
        [Display(Name = "المادة", Description = "Class Subject")]
        public int ClassSubjectId { get; set; }

        [Required(ErrorMessage = "الدرجة مطلوبة | Grade value is required")]
        [Range(0, 100, ErrorMessage = "يجب أن تكون الدرجة بين 0 و100 | Grade must be between 0 and 100")]
        [Display(Name = "الدرجة", Description = "Grade Value")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "تاريخ الدرجة مطلوب | Grade date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "التاريخ", Description = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "ملاحظات", Description = "Notes")]
        public string? Notes { get; set; }
    }
    public class UpdateGradeDto
    {
        [Required(ErrorMessage = "المعرف مطلوب | ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف غير صالح | Invalid ID")]
        [Display(Name = "المعرف", Description = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "الطالب مطلوب | Student is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف الطالب غير صالح | Invalid student ID")]
        [Display(Name = "الطالب", Description = "Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "المادة مطلوبة | Subject is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف المادة غير صالح | Invalid subject ID")]
        [Display(Name = "المادة", Description = "Class Subject")]
        public int ClassSubjectId { get; set; }

        [Required(ErrorMessage = "الدرجة مطلوبة | Grade value is required")]
        [Range(0, 100, ErrorMessage = "يجب أن تكون الدرجة بين 0 و100 | Grade must be between 0 and 100")]
        [Display(Name = "الدرجة", Description = "Grade Value")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "تاريخ الدرجة مطلوب | Grade date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "التاريخ", Description = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "ملاحظات", Description = "Notes")]
        public string? Notes { get; set; }
    }
    public class DeleteGradeDto
    {
        [Required(ErrorMessage = "المعرف مطلوب | ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف غير صالح | Invalid ID")]
        [Display(Name = "المعرف", Description = "ID")]
        public int Id { get; set; }
    }

}
