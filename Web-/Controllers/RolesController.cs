using DomainLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.Interface;
using Web.Models.Role;

namespace Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        public RolesController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }
        public ActionResult ListRole()
        {
            List<RoleModel> model = new List<RoleModel>();
            var list = _roleService.GetAllRoles();
            foreach (var item in list)
            {
                var role = new RoleModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                };
                model.Add(role);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateRole()
        {
            RoleModel model = new RoleModel();
            model.UserList = _userService.GetAllUsersForDropDwonList();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateRole(RoleModel model)
        {
            try
            {
                var roleDto = new GetRoleDTO()
                {
                    Name = model.Name,
                    Description = model.Description,
                    UserId = model.UserId,
                    ////UserId = 1,
                    UpdateUserId = 1,
                    UpdateTime = DateTime.Now,
                };
                _roleService.CreateNewRole(roleDto);
                return RedirectToAction("ListRole");
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DetailRole(int Id)
        {
            var data = _roleService.GetRoleById(Id);
            var roles = new RoleModel()
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,

            };
            return View(roles);
        }
        [HttpGet]
        public ActionResult DeleteRole(int Id)
        {
            _roleService.DeleteRole(Id);

            return RedirectToAction("ListRole");

        }
        [HttpGet]
        public ActionResult EditRole(int Id)
        {
            var data = _roleService.GetRoleById(Id);
            var roles = new RoleModel();
            roles.UserList = _userService.GetAllUsersForDropDwonList();

            roles.Id = data.Id;
            roles.Name = data.Name;
            roles.Description = data.Description;
            //roles.UserId = 1;
            roles.UserId = data.UserId;

            return View(roles);
        }

        [HttpPost]
        public ActionResult UpdateRole(RoleModel model)
        {
            try
            {
                if (!model.Id.HasValue)
                {
                    View(model);
                }

                var roleDto = new GetRoleDTO()
                {
                    Id = model.Id.Value,
                    Name = model.Name,
                    Description = model.Description,
                    UpdateUserId = 1,
                    UpdateTime = DateTime.Now,
                    //UserId = 1,
                    UserId = model.UserId
                };
                _roleService.UpdateRole(roleDto);
                return RedirectToAction("ListRole");
            }
            catch (Exception ex)
            {
                return RedirectToAction("EditRole", model);
            }
        }
    }
}
//    public class RolesController : Controller
//    {
//        private readonly IRoleService _roleService;
//        private readonly IUserService _userService;

//        public RolesController(IRoleService roleService, IUserService userService)
//        {
//            _roleService = roleService;
//            _userService = userService;

//        }
//        public ActionResult ListRole()
//        {
//            List<RoleModel> model = new List<RoleModel>();
//            var list = _roleService.GetAllRoles();
//            foreach (var item in list)
//            {
//                var rol = new RoleModel()
//                {
//                    Id = item.Id,
//                    Name = item.Name,
//                    Description = item.Description,

//                };
//                model.Add(rol);
//            }
//            return View(model);
//        }
//        [HttpGet]
//        public ActionResult CreateRole()
//        {
//            RoleModel model = new RoleModel();
//            model.UserList = _roleService.GetAllRolesForDropDownList();
//            return View(model);
//        }
//        [HttpPost]
//        public ActionResult CreateRole(RoleModel model)
//        {
//            try
//            {
//                var roleDto = new GetRoleDTO()
//                {

//                    Name = model.Name,
//                    Description = model.Description,
//                    UpdateUserId = 1,
//                    UpdateTime = DateTime.Now,
//                    UserId = model.UserId,
//                };
//            _roleService.CreateNewRole(roleDto);
//                return RedirectToAction("ListRole");
//            }
//            catch (Exception)
//            {
//                return View(model);
//            }
//        }
//        [HttpGet]
//        public ActionResult DetailRole(int Id)
//        {
//            var data = _roleService.GetRoleById(Id);
//            var role = new RoleModel()
//            {
//                Id = data.Id,
//                Name = data.Name,
//                Description = data.Description,

//            };
//            return View(role);
//            //RoleModel model = new RoleModel();
//            //return View(model);
//        }
//        [HttpGet]
//        public ActionResult DeleteRole(int Id)
//        {
//            _roleService.DeleteRole(Id);

//            return RedirectToAction("ListRole");

//        }
//        [HttpGet]
//        public ActionResult EditRole(int Id)
//        {
//            var data = _roleService.GetRoleById(Id);
//            var role = new RoleModel();
//            role.RoleList = _roleService.GetAllRolesForDropDownList();

//            role.Id = data.Id;
//            role.Name = data.Name;
//            role.Description = data.Description; 
//            role.UserId = data.UserId;


//            return View(role);
//        }
//        [HttpPost]
//        public ActionResult UpdateRole(RoleModel model)
//        {
//            try
//            {
//                if (!model.Id.HasValue)
//                {
//                    View(model);
//                }
//                var roleDto = new GetRoleDTO()
//                {
//                    Id = (int)model.Id,
//                    Name = model.Name,
//                    Description = model.Description,
//                    UpdateUserId = 1,
//                    UpdateTime = DateTime.Now,
//                    UserId=model.UserId
//                };
//                _roleService.UpdateRole(roleDto);
//                return RedirectToAction("ListRole");
//            }
//            catch (Exception ex)
//            {
//                return RedirectToAction("EditRole", model);
//            }
//        }
//    }
//}