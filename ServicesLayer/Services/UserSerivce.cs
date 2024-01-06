using ServicesLayer.Services.Interface;
using DomainLayer.Dto;
using DataAccessLayer.Repositories.Interface;

namespace ServicesLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void CreateNewUser(GetUserDTO dto)
        {
             _userRepository.CreateNewUser(dto);
        }
        public void DetailUser(int Id)
        {
            _userRepository.DetailUser(Id);
        }
        public void DeleteUser(int Id)
        {
             _userRepository.DeleteUser(Id);
        }
        public void UpdateUser(GetUserDTO dto)
        {
            _userRepository.UpdateUser(dto);
        }
        public GetUserDTO GetUserById(int Id)
        {
            return _userRepository.GetUserById(Id);
        }
        public List<GetUserDTO> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public List<UserForDropDwonListOutput> GetAllUsersForDropDwonList()
        {
            return _userRepository.GetAllUsersForDropDwonList();
        }
    }
}
