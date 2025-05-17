using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.Enums
{
    public enum AttendanceStatus
    {
        [Display(Name = "حاضر | Present")]
        Present,

        [Display(Name = "غائب | Absent")]
        Absent,

        [Display(Name = "متأخر | Late")]
        Late,

        [Display(Name = "معذور | Excused")]
        Excused
    }
}
