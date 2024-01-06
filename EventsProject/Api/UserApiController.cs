using Microsoft.AspNetCore.Mvc;
using ServicesLayer.BL;
using Web.Models;
using DataAccessLayer;

namespace Web.Api
{
    [Route("api/[User]")]
    [ApiController]
    public class UserApiController : ControllerBase
    { 
            private UserLogic userLogic = new UserLogic();
            [Route("add")]
            [HttpGet]
            public async Task<Boolean> AddUser(string Name, string Emailaddress, string Password, int Mobilephone, int Id)
            {
                bool result = await userLogic.CreateNewUser(Name, Emailaddress, Password,  Mobilephone, Id);
                return result;//true
            }
            [Route("all")]
            [HttpGet]
            public async Task<List<UserViewModel>> GetAllUsers()
            {
                List<UserViewModel> UserList = new List<UserViewModel>();
                var Users = await userLogic.GetAllUsers();
                if (Users.Count > 0)
                {
                    foreach (var User in Users)
                    {
                        UserViewModel usermodel = new UserViewModel()
                        {
                            username = User.Name,
                            emailaddress = User.Emailaddress,
                            passwrd=User.Password,
                            usermobilephone=User.Mobilephone,
                            userId = User.Id
                        };
                        UserList.Add(usermodel);
                    }
                }
                return UserList;
            }
    }
}


