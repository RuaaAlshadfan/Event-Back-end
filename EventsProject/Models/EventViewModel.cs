using Web.Api;
namespace Web.Models
{
    public class EventViewModel
    {
            public string? eventname { get; set; }
            public string? Description { get; set; }
            public string? eventFrom { get; set; }
            public string? eventTo { get; set; }
            public int eventId { get; set; } 
    }
}
