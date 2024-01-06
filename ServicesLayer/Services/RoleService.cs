using ServicesLayer.Services.Interface;
using DomainLayer.Dto;
using DataAccessLayer.Repositories.Interface;

namespace ServicesLayer.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public void CreateNewRole(GetRoleDTO dto)
        {
            _roleRepository.CreateNewRole(dto);
        }
        public void DetailRole(int Id)
        {
            _roleRepository.DetailRole(Id);
        }
        public void DeleteRole(int Id)
        {
             _roleRepository.DeleteRole(Id);
        }
        public void UpdateRole(GetRoleDTO dto)
        {
             _roleRepository.UpdateRole(dto);
        }
        public GetRoleDTO GetRoleById(int Id)
        {
            return _roleRepository.GetRoleById(Id);
        }
        public List<GetRoleDTO> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }
        //public List<UserForDropDwonListOutput> GetAllUsersForDropDwonList()
        //{
        //    return _roleRepository.GetAllUsersForDropDwonList();
        //}
    }
}
