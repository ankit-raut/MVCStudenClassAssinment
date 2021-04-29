using MVCStudenClassAssinment.Model.Model;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCStudenClassAssinment.Model
{
    public class StudenParentViewModel
    {
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Student First Name Should be under 100 Characters.")]
        [DisplayName("Student First Name")]
        public string StudentFirstName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Student Last Name Should be under 100 Characters.")]
        [DisplayName("Student Last Name")]
        public string StudentLastName { get; set; }


        public int? ParentId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Parent Name Should be under 100 Characters.")]
        [DisplayName("Parent Name")]
        public string ParentFullName { get; set; }

        public int StudentClassId { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Student Email")]
        public string StudentEmail { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Parent Email")]
        public string ParentEmail { get; set; }

        [Phone]
        [DisplayName("Parent Mobile")]
        public string ParentMobile { get; set; }

        [DisplayName("Status")]
        public bool Active { get; set; }

        public UserTypes UserType { get; set; }

        [DisplayName("Classes")]
        public string StudentClass { get; set; }

        public List<SchoolClassViewModel> StudentClassList { get; set; }
    }

}
