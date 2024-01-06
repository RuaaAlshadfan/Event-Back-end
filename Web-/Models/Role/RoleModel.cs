using DomainLayer.Dto;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Role
{
    public class RoleModel
    {
        public int? Id { get; set; }
       
        public string Name { get; set; }
        [Required]

        public string Description { get; set; }
        public int UserId { get; set; }
        public List<UserForDropDwonListOutput> UserList { get; set; }

    }
}
