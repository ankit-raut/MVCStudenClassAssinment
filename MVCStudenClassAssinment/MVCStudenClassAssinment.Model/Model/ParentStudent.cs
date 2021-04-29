using System.ComponentModel.DataAnnotations;

namespace MVCStudenClassAssinment.Model.Model
{
    public class ParentStudent
    {
        [Key]
        public int Id { get; set; }
        public virtual User Parent { get; set; }
        public virtual User Student { get; set; }
    }
}
