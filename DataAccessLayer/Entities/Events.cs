using DataAccessLayer.AuditModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("Events")]
    public class Events : AuditModelClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [ForeignKey("CustomersId")]
        public ICollection<Customers> CustomerFk { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Users UserFk { get; set; }
    }
}
