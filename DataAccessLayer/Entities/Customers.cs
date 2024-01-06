using DataAccessLayer.AuditModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccessLayer.Entities
{
    [Table("Customers")]
    public class Customers : AuditModelClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int MobileNumber { get; set; }

        [Required]
        public int NumberOfPeople { get; set; }

        public string Note { get; set; }


        [ForeignKey("EventId")]
        public virtual ICollection<Events> Events { get; set; }
    }
}
