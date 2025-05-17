using Domin.SchoolManagement.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.DTO
{
    public class AttendanceDto
    {
        public int Id { get; set; }

        [Display(Name = "الطالب", Description = "Student")]
        public int StudentId { get; set; }

        [Display(Name = "اسم الطالب", Description = "Student Name")]
        public string StudentName { get; set; } = string.Empty;

        [Display(Name = "المادة", Description = "Class Subject")]
        public int ClassSubjectId { get; set; }

        [Display(Name = "اسم المادة", Description = "Class Subject Name")]
        public string ClassSubjectName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "التاريخ", Description = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "الحالة", Description = "Status")]
        public AttendanceStatus Status { get; set; }

        [Display(Name = "ملاحظات", Description = "Notes")]
        public string? Notes { get; set; }
    }

    public class CreateAttendanceDto
    {
        [Required(ErrorMessage = "معرف الطالب مطلوب | Student ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف الطالب غير صالح | Invalid student ID")]
        [Display(Name = "الطالب", Description = "Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "معرف المادة مطلوب | Class Subject ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف المادة غير صالح | Invalid class subject ID")]
        [Display(Name = "المادة", Description = "Class Subject")]
        public int ClassSubjectId { get; set; }

        [Required(ErrorMessage = "التاريخ مطلوب | Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "التاريخ", Description = "Attendance Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "حالة الحضور مطلوبة | Attendance status is required")]
        [EnumDataType(typeof(AttendanceStatus), ErrorMessage = "حالة الحضور غير صالحة | Invalid attendance status")]
        [Display(Name = "الحالة", Description = "Attendance Status")]
        public AttendanceStatus Status { get; set; }

        [StringLength(500, ErrorMessage = "يجب ألا تتجاوز الملاحظات 500 حرف | Notes must not exceed 500 characters")]
        [Display(Name = "ملاحظات", Description = "Notes")]
        public string? Notes { get; set; }
    }
    public class UpdateAttendanceDto
    {
        [Required(ErrorMessage = "معرف الحضور مطلوب | Attendance ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "معرف الحضور غير صالح | Invalid attendance ID")]
        [Display(Name = "معرف الحضور", Description = "Attendance ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "معرف الطالب مطلوب | Student ID is required")]
        [Display(Name = "الطالب", Description = "Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "معرف المادة مطلوب | Class Subject ID is required")]
        [Display(Name = "المادة", Description = "Class Subject")]
        public int ClassSubjectId { get; set; }

        [Required(ErrorMessage = "التاريخ مطلوب | Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "التاريخ", Description = "Attendance Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "حالة الحضور مطلوبة | Attendance status is required")]
        [Display(Name = "الحالة", Description = "Attendance Status")]
        public AttendanceStatus Status { get; set; }

        [StringLength(500)]
        [Display(Name = "ملاحظات", Description = "Notes")]
        public string? Notes { get; set; }
    }
    public class DeleteAttendanceDto
    {
        [Required(ErrorMessage = "معرف الحضور مطلوب | Attendance ID is required")]
        [Display(Name = "معرف الحضور", Description = "Attendance ID")]
        public int Id { get; set; }
    }

}
