using DataAccessLayer.DataContext;
using DataAccessLayer.Repositories.Interface;
using DomainLayer.Dto;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly EventContext _context;

        public RoleRepository(EventContext context)
        {
            _context = context;
        }
        public void CreateNewRole(GetRoleDTO model)
        {
            try
            {
                var roles = new Roles()
                {
                    Name = model.Name,
                    Description = model.Description,
                    UpdateTime = DateTime.Now,
                    UpdateUserId = 1,
                    IsDeleted = false,
                    UserId = model.UserId
                };
                _context.Roles.Add(roles);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DetailRole(int Id)
        {
            var Role = _context.Roles.Where(I => I.Id == Id).FirstOrDefault();

            var roles = new GetRoleDTO()
            {
                Id = Id,
            };
        }
        public void DeleteRole(int Id)
        {
            try
            {
                var roleData = _context.Roles.Where(x => x.Id == Id).FirstOrDefault();
                roleData.IsDeleted = true;

                _context.Roles.Update(roleData);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateRole(GetRoleDTO model)
        {
            try
            {
                var roles = new Roles()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    UpdateTime = DateTime.Now,
                    UpdateUserId = 1,
                    UserId = model.UserId
                };
                _context.Roles.Update(roles);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GetRoleDTO GetRoleById(int Id)
        {
            var Role = _context.Roles.Where(I => I.Id == Id).FirstOrDefault();
            var roles = new GetRoleDTO()
            {
                Id = Role.Id,
                Name = Role.Name,
                Description = Role.Description,
                UserId = Role.UserId
            };
            return roles;
        }
        public List<GetRoleDTO> GetAllRoles()
        {
            List<GetRoleDTO> Roles = new List<GetRoleDTO>();

            var selectedList = _context.Roles.Where(x => !x.IsDeleted).ToList();

            if (selectedList.Count > 0)
            {
                foreach (var item in selectedList)
                {
                    var roles = new GetRoleDTO()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                    };
                    Roles.Add(roles);
                };
            };
            return Roles;
        }
        //public List<RoleForDropDownListOutput> GetAllRolesForDropDownList()
        //{
        //    var selectedList = from roles in _context.Roles
        //                       select new RoleForDropDownListOutput()
        //                       {
        //                           UserId = roles.Id,
        //                           DisplayName = roles.Name,
        //                       };

        //    return selectedList.ToList();
        //}
    }
}
//    public class RoleRepository : IRoleRepository
//    {
//        private readonly EventContext _context;
//        public RoleRepository(EventContext context)
//        {
//            _context = context;
//        }
//        public void CreateNewRole(GetRoleDTO model)
//        {
//            try
//            {
//                var role = new Roles()
//                {
//                    Name = model.Name,
//                    Description = model.Description,
//                    UpdateTime= DateTime.Now,
//                    IsDeleted = false,
//                    UpdateUserId = 1,
//                    UserId=model.UserId

//                };
//                _context.Roles.Add(role);
//                _context.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//        public void DetailRole(int Id)
//        { 
//        var Role = _context.Roles.Where(I => I.Id == Id).FirstOrDefault();

//             var roles = new GetRoleDTO()
//             {
//                Id = Id,
//             };
//        }
//        public void DeleteRole(int Id)
//        {
//            try
//            {
//                var roleData = _context.Roles.Where(x => x.Id == Id).FirstOrDefault();
//                roleData.IsDeleted = true;

//                _context.Roles.Update(roleData);
//                _context.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//        public void UpdateRole(GetRoleDTO model)
//        {
//            try
//            {
//                var role = new Roles()
//                {
//                    Id = model.Id,
//                    Name = model.Name,
//                    Description = model.Description,
//                    UpdateTime = DateTime.Now,
//                    UpdateUserId = 1,
//                    IsDeleted = false,
//                    UserId=model.UserId,
//                };
//                _context.Roles.Update(role);
//                _context.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//        public GetRoleDTO GetRoleById(int Id)
//        {
//            var Role = _context.Roles.Where(I => I.Id == Id).FirstOrDefault();
//            var ro = new GetRoleDTO()
//            {
//                Id = Role.Id,
//                Name = Role.Name,
//                Description = Role.Description,
//                UserId=Role.UserId,
//            };
//            return ro;

//        }
//        public List<GetRoleDTO> GetAllRoles()
//        {
//            List<GetRoleDTO> Roles = new List<GetRoleDTO>();

//            var selectedList = _context.Roles.Where(x => !x.IsDeleted).ToList();

//            if (selectedList.Count > 0)
//            {
//                foreach (var item in selectedList)
//                {
//                    var role = new GetRoleDTO()
//                    {
//                        Id = item.Id,
//                        Name = item.Name,
//                        Description = item.Description,

//                    };
//                    Roles.Add(role);
//                };
//            };
//            return Roles;
//        }
//        public List<RoleForDropDownListOutput> GetAllRolesForDropDownList()
//        {
//            var selectedList = from Roles in _context.Roles
//                               select new RoleForDropDownListOutput()
//                               {
//                                   Id = Roles.Id,
//                                   DisplayName = Roles.Name,
//                               };

//            return selectedList.ToList();
//        }
//    }
//}
