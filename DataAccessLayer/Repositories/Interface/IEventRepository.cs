using DomainLayer.Dto;

namespace DataAccessLayer.Repositories.Interface
{
    public interface IEventRepository
    {
        void CreateNewEvent(GetEventDTO model);
        void DeleteEvent(int Id);
        void UpdateEvent(GetEventDTO model);
        void DetailEvent(int Id);
        GetEventDTO GetEventById(int Id);
        List<GetEventDTO> GetAllEvents();
        List<EventForDropDownListOutput> GetAllEventsForDropDwonList();
    }
}