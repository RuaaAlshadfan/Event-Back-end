using DomainLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.Interface;
using Web.Models.User;

namespace Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult ListUser()
        {
            List<UserModel> model = new List<UserModel>();
            var list = _userService.GetAllUsers();
            foreach (var item in list)
            {
                var use = new UserModel()
                {
                   Id=item.Id,
                   Name = item.Name,
                   Emailaddress=item.Emailaddress,
                   Password=item.Password,
                   MobileNumber=item.MobileNumber,
                };
                model.Add(use);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            UserModel model = new UserModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateUser(UserModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var userDto = new GetUserDTO()
                {
                    Name = model.Name,
                    Emailaddress = model.Emailaddress,
                    Password = model.Password,
                    MobileNumber = model.MobileNumber,
                    UpdateUserId = 1,
                    UpdateTime = DateTime.Now,
                };
                _userService.CreateNewUser(userDto);
                return RedirectToAction("ListUser");
            }
            catch (Exception)
            {
                return View(model);
            }
        }
      
        [HttpGet]
        public ActionResult DetailUser(int Id)
        {
            var data = _userService.GetUserById(Id);
            var users = new UserModel();

            users.Id = data.Id;
            users.Name = data.Name;
            users.Emailaddress = data.Emailaddress;
            users.Password = data.Password;
            users.MobileNumber = data.MobileNumber;
            return View(users);

            //UserModel model = new UserModel();
            //return View(model);
        }
        [HttpGet]

        public ActionResult DeleteUser(int Id)
        {
            _userService.DeleteUser(Id);

            return RedirectToAction("ListUser");
        }

        [HttpGet]
        public ActionResult EditUser(int Id)
        {
            var data = _userService.GetUserById(Id);
            var users = new UserModel()
            { 
            Id = data.Id,
            Name = data.Name,
            Emailaddress = data.Emailaddress,
            Password = data.Password,
            MobileNumber = data.MobileNumber,
            };
            return View(users);

        }

        [HttpPost]
        public ActionResult UpdateUser(UserModel model)
        {
            try
            {
                if (!model.Id.HasValue)
                {
                    View(model);
                }

                var userDto = new GetUserDTO()
                {
                    Id = model.Id.Value,
                    Name = model.Name,
                    Emailaddress= model.Emailaddress,
                    Password = model.Password,
                    MobileNumber = model.MobileNumber,
                    UpdateUserId = 1,
                    UpdateTime = DateTime.Now,
                };
                _userService.UpdateUser(userDto);
                return RedirectToAction("ListUser");
            }
            catch (Exception ex)
            {
                return RedirectToAction("EditUser", model);
            }
        }
    }
}


