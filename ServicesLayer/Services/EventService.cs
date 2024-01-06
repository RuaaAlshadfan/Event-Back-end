using ServicesLayer.Services.Interface;
using DomainLayer.Dto;
using DataAccessLayer.Repositories.Interface;


namespace ServicesLayer.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
          _eventRepository = eventRepository;
        }
        public void CreateNewEvent(GetEventDTO dto)
        {
          _eventRepository.CreateNewEvent(dto);
        }
        public void DetailEvent(int Id)
        {
            _eventRepository.DetailEvent(Id);
        }
        public void DeleteEvent(int Id)
        {
          _eventRepository.DeleteEvent(Id);
        }
        public void UpdateEvent(GetEventDTO dto)
        {
          _eventRepository.UpdateEvent(dto);
        }
        public GetEventDTO GetEventById(int Id)
        {
            return _eventRepository.GetEventById(Id);
        }
        public List<GetEventDTO> GetAllEvents()
        {
            return _eventRepository.GetAllEvents();
        }
        public List<EventForDropDownListOutput> GetAllEventsForDropDwonList()
        {
            return _eventRepository.GetAllEventsForDropDwonList();
        }
    }
}
