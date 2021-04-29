using System.ComponentModel.DataAnnotations;

namespace MVCStudenClassAssinment.Model.Model
{
    public class SchoolClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
