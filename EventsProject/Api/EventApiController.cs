using Microsoft.AspNetCore.Mvc;
using ServicesLayer.BL;
using Web.Models;
using DataAccessLayer;
namespace Web.Api
{
    [Route("api/[Event]")]
    [ApiController]
    public class EventApiController : ControllerBase
    {
        private EventLogic eventLogic = new EventLogic();
        [Route("add")]
        [HttpGet]
        public async Task<Boolean> AddEvent(string Name, string Description, string From, string To, int Id)
        {
            bool result = await eventLogic.CreateNewEvent(Name, Description, From, To, Id);
            return result;//true
        }
        [Route("all")]
        [HttpGet]
        public async Task<List<EventViewModel>> GetAllEvents()
        {
            List<EventViewModel> EventList = new List<EventViewModel>();
            var Events = await eventLogic.GetAllEvents();
            if (Events.Count > 0)
            {
                foreach (var Event in Events)
                {
                    EventViewModel eventmodel = new EventViewModel()
                    {
                        eventId = Event.Id,
                        eventname=Event.Name,
                        Description=Event.Description,
                        eventFrom=Event.From,
                        eventTo=Event.To

                    };
                    EventList.Add(eventmodel);
                }
            }
            return EventList;
        }
    }
}
