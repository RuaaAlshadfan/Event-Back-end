using DomainLayer.Dto;

namespace ServicesLayer.Services.Interface
{
    public interface IEventService
    {
        void CreateNewEvent(GetEventDTO dto);
        void DeleteEvent(int Id);
        void UpdateEvent(GetEventDTO eventDto);
        //void UpdateEvent(int Id);
        void DetailEvent(int Id);
        GetEventDTO GetEventById(int Id);
        List<GetEventDTO> GetAllEvents();
        List<EventForDropDownListOutput> GetAllEventsForDropDwonList();

    }
}