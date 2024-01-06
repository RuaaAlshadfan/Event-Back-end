using DataAccessLayer.AuditModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("Roles")]
    public class Roles : AuditModelClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Users UserFk { get; set; }

    }
}
