using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.DTO
{
    public class ScheduleDto
    {
        public int Id { get; set; }

        [Display(Name = "المادة", Description = "Subject")]
        public int ClassSubjectId { get; set; }

        [Display(Name = "اسم المادة", Description = "Subject Name")]
        public string SubjectName { get; set; } = string.Empty;

        [Display(Name = "اليوم", Description = "Day of Week")]
        public DayOfWeek DayOfWeek { get; set; }

        [Display(Name = "وقت البدء", Description = "Start Time")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "وقت الانتهاء", Description = "End Time")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "رقم القاعة", Description = "Room Number")]
        public string? RoomNumber { get; set; }
    }

    public class CreateScheduleDto
    {
        [Required(ErrorMessage = "المادة مطلوبة | Class subject is required")]
        [Display(Name = "المادة", Description = "Subject")]
        public int ClassSubjectId { get; set; }

        [Required(ErrorMessage = "اليوم مطلوب | Day is required")]
        [Display(Name = "اليوم", Description = "Day of Week")]
        public DayOfWeek DayOfWeek { get; set; }

        [Required(ErrorMessage = "وقت البدء مطلوب | Start time is required")]
        [Display(Name = "وقت البدء", Description = "Start Time")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "وقت الانتهاء مطلوب | End time is required")]
        [Display(Name = "وقت الانتهاء", Description = "End Time")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "رقم القاعة", Description = "Room Number")]
        public string? RoomNumber { get; set; }
    }
    public class UpdateScheduleDto
    {
        [Required(ErrorMessage = "المعرف مطلوب | ID is required")]
        [Display(Name = "المعرف", Description = "Schedule ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "المادة مطلوبة | Class subject is required")]
        [Display(Name = "المادة", Description = "Subject")]
        public int ClassSubjectId { get; set; }

        [Required(ErrorMessage = "اليوم مطلوب | Day is required")]
        [Display(Name = "اليوم", Description = "Day of Week")]
        public DayOfWeek DayOfWeek { get; set; }

        [Required(ErrorMessage = "وقت البدء مطلوب | Start time is required")]
        [Display(Name = "وقت البدء", Description = "Start Time")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "وقت الانتهاء مطلوب | End time is required")]
        [Display(Name = "وقت الانتهاء", Description = "End Time")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "رقم القاعة", Description = "Room Number")]
        public string? RoomNumber { get; set; }
    }
    public class DeleteScheduleDto
    {
        [Required(ErrorMessage = "المعرف مطلوب | ID is required")]
        [Display(Name = "المعرف", Description = "Schedule ID")]
        public int Id { get; set; }
    }

}
