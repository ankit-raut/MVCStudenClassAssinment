using System.ComponentModel.DataAnnotations;

namespace MVCStudenClassAssinment.Model.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserTypes UserType { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
    }
}
