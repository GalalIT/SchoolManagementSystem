using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.Entities
{
    public class Schedule
    {
        [Key]
        [Display(Name = "معرف الجدول | Schedule ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "المادة مطلوبة | Class subject is required")]
        [Display(Name = "المادة | Subject")]
        public int ClassSubjectId { get; set; }

        [Required(ErrorMessage = "اليوم مطلوب | Day is required")]
        [Display(Name = "اليوم | Day")]
        public DayOfWeek DayOfWeek { get; set; }

        [Required(ErrorMessage = "وقت البدء مطلوب | Start time is required")]
        [Display(Name = "وقت البدء | Start Time")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "وقت الانتهاء مطلوب | End time is required")]
        [Display(Name = "وقت الانتهاء | End Time")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "رقم القاعة | Room Number")]
        public string? RoomNumber { get; set; }

        // Navigation properties
        [ForeignKey(nameof(ClassSubjectId))]
        public virtual ClassSubject ClassSubject { get; set; } = null!;
    }
}
