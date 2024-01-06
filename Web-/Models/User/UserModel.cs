using System.ComponentModel.DataAnnotations;

namespace Web.Models.User
{
    public class UserModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Emailaddress { get; set; }

        [Required]
        public string Password { get; set; }

        public int MobileNumber { get; set; }
       

    }
}
