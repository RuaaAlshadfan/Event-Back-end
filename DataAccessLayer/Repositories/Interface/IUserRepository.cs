using DomainLayer.Dto;

namespace DataAccessLayer.Repositories.Interface
{
    public interface IUserRepository
    {
        void CreateNewUser(GetUserDTO model);
        void DeleteUser(int Id);
        void UpdateUser(GetUserDTO model);
        void DetailUser(int Id);
        GetUserDTO GetUserById(int Id);
        List<GetUserDTO> GetAllUsers();
        List<UserForDropDwonListOutput> GetAllUsersForDropDwonList();
    }
}
