using DomainLayer.Dto;

namespace ServicesLayer.Services.Interface
{
    public interface IUserService
    {
        void CreateNewUser(GetUserDTO dto);
        void DeleteUser(int Id);
        void UpdateUser(GetUserDTO userDto);
        void DetailUser(int Id);
        GetUserDTO GetUserById(int Id);
        List<GetUserDTO> GetAllUsers();
        List<UserForDropDwonListOutput> GetAllUsersForDropDwonList();
    }

}