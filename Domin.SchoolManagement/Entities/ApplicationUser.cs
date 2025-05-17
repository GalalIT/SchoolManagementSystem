using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "اسم المستخدم مطلوب | Full name is required")]
        [StringLength(100, MinimumLength = 2,
            ErrorMessage = "يجب أن يكون الاسم بين 2 و100 حرف | Name must be between 2 and 100 characters")]
        [Display(Name = "الاسم الكامل | Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "الصورة الشخصية | Profile Picture")]
        public byte[]? ProfilePicture { get; set; }

        [Required(ErrorMessage = "حالة التفعيل مطلوبة | Activation status is required")]
        [Display(Name = "مفعل | Is Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "تاريخ الإنشاء | Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Teacher? Teacher { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Parent? Parent { get; set; }
        public virtual Parent? Parents { get; set; }

    }
}
