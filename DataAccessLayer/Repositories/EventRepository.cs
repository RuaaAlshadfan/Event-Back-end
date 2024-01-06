using DataAccessLayer.DataContext;
using DataAccessLayer.Repositories.Interface;
using DomainLayer.Dto;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext _context;

        public EventRepository(EventContext context)
        {
            _context = context;
        }
        public void CreateNewEvent(GetEventDTO model)
        {
           try
              {
               var events = new Events()
               {
                        Name = model.Name,
                        Description = model.Description,
                        From = model.From,
                        To = model.To,
                        UpdateTime = DateTime.Now,
                        UpdateUserId = 1,
                        IsDeleted = false,
                        UserId = model.UserId
               };
                    _context.Events.Add(events);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        public void DetailEvent(int Id)
        {
            var Event = _context.Events.Where(I => I.Id == Id).FirstOrDefault(); 

                var events = new GetEventDTO()
                {
                    Id =Id,
                };
        }
        public void DeleteEvent(int Id)
        {
           
                try
                {
                var eventData = _context.Events.Where(x => x.Id == Id).FirstOrDefault();
                eventData.IsDeleted = true;
               
                    _context.Events.Update(eventData);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }
        public void UpdateEvent(GetEventDTO model)
            {
                try
                {
                    var events = new Events()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Description = model.Description,
                        From = model.From,
                        To = model.To,
                        UpdateTime = DateTime.Now,
                        UpdateUserId = 1,
                        UserId = model.UserId
                    };
                    _context.Events.Update(events);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        public GetEventDTO GetEventById(int Id )
        {
            var Event = _context.Events.Where(I => I.Id == Id).FirstOrDefault();
            var ev = new GetEventDTO()
            {
                Id = Event.Id,
                Name = Event.Name,
                Description = Event.Description,
                From = Event.From,
                To = Event.To,
                UserId=Event.UserId
            };
            return ev;
        }
        public List<GetEventDTO> GetAllEvents()
            {
                List<GetEventDTO> Events = new List<GetEventDTO>();

                var selectedList = _context.Events.Where(x => !x.IsDeleted).ToList();

                if (selectedList.Count > 0)
                {
                    foreach (var item in selectedList)
                    {
                        var events = new GetEventDTO()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Description = item.Description,
                            From = item.From,
                            To = item.To,
                        };
                        Events.Add(events);
                    };
                };
                return Events;
            }
    public List<EventForDropDownListOutput> GetAllEventsForDropDwonList()
        {
            var selectedList = from events in _context.Events
                               select new EventForDropDownListOutput()
                               {
                                   UserId = events.Id,
                                   DisplayName = events.Name,
                               };

            return selectedList.ToList();
        }
    }
}
