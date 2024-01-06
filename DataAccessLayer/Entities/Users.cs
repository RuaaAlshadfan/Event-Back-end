using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.AuditModel;
namespace DataAccessLayer.Entities
{
    [Table("Users")]

    public class Users : AuditModelClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int MobileNumber { get; set; }
    }
}
