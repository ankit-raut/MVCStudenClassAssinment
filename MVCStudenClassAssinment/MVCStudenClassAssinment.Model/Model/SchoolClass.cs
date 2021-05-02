using System.ComponentModel.DataAnnotations;

namespace MVCStudentClassAssignment.Model.Model
{
    public class SchoolClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
