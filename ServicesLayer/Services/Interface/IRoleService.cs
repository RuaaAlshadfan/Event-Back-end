using DomainLayer.Dto;

namespace ServicesLayer.Services.Interface
{
    public interface IRoleService
    {
        void CreateNewRole(GetRoleDTO dto);
        void DeleteRole(int Id);
        void UpdateRole(GetRoleDTO roleDto);
        void DetailRole(int Id);
        GetRoleDTO GetRoleById(int Id);
        List<GetRoleDTO> GetAllRoles();
        ////List<UserForDropDwonListOutput> GetAllUsersForDropDwonList();

    }
}