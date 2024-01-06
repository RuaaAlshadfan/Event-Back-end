using DomainLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServicesLayer.Services.Interface;
using Web.Models.Event;

namespace Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;
        public EventsController(IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }
        public ActionResult ListEvent()
        {
            List<EventModel> model = new List<EventModel>();
            var list = _eventService.GetAllEvents();
            foreach (var item in list)
            {
                var ev = new EventModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    From = item.From,
                    To = item.To,
                };
                model.Add(ev);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateEvent()
        {
            EventModel model = new EventModel();
            model.UserList = _userService.GetAllUsersForDropDwonList();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateEvent(EventModel model)
        {
            try
            {
                var eventDto = new GetEventDTO();
                eventDto.Name = model.Name;
                eventDto.Description = model.Description;
                eventDto.From = model.From;
                eventDto.To = model.To;
                eventDto.CreaterUserId = 1;
                eventDto.CreationTime = DateTime.Now;
                eventDto.UserId = model.UserId;

                _eventService.CreateNewEvent(eventDto);
                return RedirectToAction("ListEvent");
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DetailEvent(int Id)
        {
            var data = _eventService.GetEventById(Id);
            var events = new EventModel()
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,
                From = data.From,
                To = data.To
            };
            return View(events);
            //EventModel model = new EventModel();
            //return View(model);
        }
        [HttpGet]
        public ActionResult DeleteEvent(int Id)
        {
             _eventService.DeleteEvent(Id);
          
            return RedirectToAction("ListEvent");

        }
        [HttpGet]
        public ActionResult EditEvent(int Id)
        {
            var data = _eventService.GetEventById(Id);
            var events = new EventModel();
            events.UserList = _userService.GetAllUsersForDropDwonList();


            events.Id = data.Id;
            events.Name = data.Name;
            events.Description = data.Description;
            events.From = data.From;
            events.To = data.To;
            events.UserId = data.UserId;
            
            return View(events);
        }

        [HttpPost]
        public ActionResult UpdateEvent(EventModel model)
        {
            try
            {
                if (!model.Id.HasValue)
                {
                    View(model);
                }

                var eventDto = new GetEventDTO()
                {
                    Id = model.Id.Value,
                    Name = model.Name,
                    Description = model.Description,
                    From = model.From,
                    To = model.To,
                    UpdateUserId = 1,
                    UpdateTime = DateTime.Now,
                    UserId = model.UserId
                };
                _eventService.UpdateEvent(eventDto);
                return RedirectToAction("ListEvent");
            }
            catch (Exception ex)
            {
                return RedirectToAction("EditEvent", model);
            }
        }
    }
}


