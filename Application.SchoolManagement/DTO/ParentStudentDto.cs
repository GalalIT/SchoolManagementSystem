using Domin.SchoolManagement.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.DTO
{
    public class ParentStudentDto
    {
        public int Id { get; set; }

        [Display(Name = "ولي الأمر", Description = "Parent")]
        public int ParentId { get; set; }

        [Display(Name = "اسم ولي الأمر", Description = "Parent Name")]
        public string ParentName { get; set; } = string.Empty;

        [Display(Name = "الطالب", Description = "Student")]
        public int StudentId { get; set; }

        [Display(Name = "اسم الطالب", Description = "Student Name")]
        public string StudentName { get; set; } = string.Empty;

        [Display(Name = "صلة القرابة", Description = "Relationship")]
        public RelationshipType Relationship { get; set; }
    }

    public class CreateParentStudentDto
    {
        [Required(ErrorMessage = "معرف ولي الأمر مطلوب | Parent ID is required")]
        [Display(Name = "ولي الأمر", Description = "Parent")]
        public int ParentId { get; set; }

        [Required(ErrorMessage = "معرف الطالب مطلوب | Student ID is required")]
        [Display(Name = "الطالب", Description = "Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "صلة القرابة مطلوبة | Relationship is required")]
        [Display(Name = "صلة القرابة", Description = "Relationship")]
        public RelationshipType Relationship { get; set; }
    }
    public class UpdateParentStudentDto
    {
        [Required(ErrorMessage = "المعرف مطلوب | ID is required")]
        [Display(Name = "المعرف", Description = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "معرف ولي الأمر مطلوب | Parent ID is required")]
        [Display(Name = "ولي الأمر", Description = "Parent")]
        public int ParentId { get; set; }

        [Required(ErrorMessage = "معرف الطالب مطلوب | Student ID is required")]
        [Display(Name = "الطالب", Description = "Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "صلة القرابة مطلوبة | Relationship is required")]
        [Display(Name = "صلة القرابة", Description = "Relationship")]
        public RelationshipType Relationship { get; set; }
    }
    public class DeleteParentStudentDto
    {
        [Required(ErrorMessage = "المعرف مطلوب | ID is required")]
        [Display(Name = "المعرف", Description = "ID")]
        public int Id { get; set; }
    }

}
