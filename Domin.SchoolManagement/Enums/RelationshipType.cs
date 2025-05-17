using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.Enums
{
    public enum RelationshipType
    {
        [Display(Name = "أب | Father")]
        Father,

        [Display(Name = "أم | Mother")]
        Mother,

        [Display(Name = "وصي | Guardian")]
        Guardian
    }
}
