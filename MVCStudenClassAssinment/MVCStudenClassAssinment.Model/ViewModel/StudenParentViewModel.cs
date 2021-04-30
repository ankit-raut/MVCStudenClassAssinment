using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCStudenClassAssinment.Model
{
    public class StudenParentViewModel
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DisplayName("Student First Name")]
        public string StudentFirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DisplayName("Student Last Name")]
        public string StudentLastName { get; set; }


        public int? ParentId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DisplayName("Parent First Name")]
        public string ParentFirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DisplayName("Parent Last Name")]
        public string ParentLastName { get; set; }


        public int StudentClassId { get; set; }

        [Required]
        [DisplayName("Student Email")]
        [EmailAddress]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string StudentEmail { get; set; }

        [Required]
        [DisplayName("Parent Email")]
        [EmailAddress]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string ParentEmail { get; set; }

        [Required]
        [DisplayName("Parent Mobile")]
        [StringLength(10, ErrorMessage = "The {0} must contains 10 number", MinimumLength = 10)]
        public string ParentMobile { get; set; }

        [DisplayName("Status")]
        public bool Active { get; set; }

        public UserTypes UserType { get; set; }

        [DisplayName("Class")]
        public string StudentClass { get; set; }

        public List<SchoolClassViewModel> StudentClassList { get; set; }
    }

}
