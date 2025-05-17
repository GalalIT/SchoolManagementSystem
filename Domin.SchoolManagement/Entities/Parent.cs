using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.Entities
{
    public class Parent
    {
        [Key]
        [Display(Name = "معرف ولي الأمر | Parent ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "معرف المستخدم مطلوب | User ID is required")]
        [Display(Name = "معرف المستخدم | User ID")]
        public string UserId { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "يجب ألا يتجاوز رقم الهاتف 20 رقمًا | Phone number must not exceed 20 digits")]
        [Display(Name = "رقم الهاتف | Phone Number")]
        public string? PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "يجب ألا تتجاوز المهنة 100 حرف | Occupation must not exceed 100 characters")]
        [Display(Name = "المهنة | Occupation")]
        public string? Occupation { get; set; }

        // Navigation properties
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!; 
        public virtual ICollection<ParentStudent> ParentStudents { get; set; } = new List<ParentStudent>();
    }
}
