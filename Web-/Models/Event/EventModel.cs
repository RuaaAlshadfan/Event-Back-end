using DomainLayer.Dto;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Event
{
    public class EventModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string From { get; set; }
        
        public string To { get; set; }

        public int UserId { get; set; }

        public List<UserForDropDwonListOutput> UserList { get; set; }

    }
}

