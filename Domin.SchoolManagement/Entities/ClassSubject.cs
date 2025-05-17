using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.Entities
{
    public class ClassSubject
    {
        [Key]
        [Display(Name = "معرف | ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "الصف مطلوب | Class is required")]
        [Display(Name = "الصف | Class")]
        public int ClassId { get; set; }

        [Required(ErrorMessage = "المادة مطلوبة | Subject is required")]
        [Display(Name = "المادة | Subject")]
        public int SubjectId { get; set; }

        [Display(Name = "المعلم | Teacher")]
        public int? TeacherId { get; set; }

        // Navigation properties
        [ForeignKey(nameof(ClassId))]
        public virtual Class Class { get; set; } = null!;
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; } = null!;
        [ForeignKey(nameof(TeacherId))]
        public virtual Teacher? Teacher { get; set; }
        //public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
        //public virtual ICollection<Schedule> Schedule { get; set; } = new List<Schedule>();
        //public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
