using System.ComponentModel.DataAnnotations;

namespace Web.Models.Customer
{
    public class CustomerModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public int MobileNumber { get; set; }

        public int NumberOfPeople { get; set; }

        public string Note { get; set; }
    }
}

