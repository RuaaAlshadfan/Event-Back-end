using DomainLayer.Dto;

namespace DataAccessLayer.Repositories.Interface
{
    public interface IRoleRepository
    {
        void CreateNewRole(GetRoleDTO model);
        void DeleteRole(int Id);
        void UpdateRole(GetRoleDTO model);
        void DetailRole(int Id);
        GetRoleDTO GetRoleById(int Id);
        List<GetRoleDTO> GetAllRoles();
        ////List<UserForDropDwonListOutput> GetAllUsersForDropDwonList();

    }
}