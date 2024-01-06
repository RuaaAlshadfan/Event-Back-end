using Microsoft.AspNetCore.Mvc;
using ServicesLayer.BL;
using Web.Models;
using DataAccessLayer;

namespace Web.Api
{
    [Route("api/[Role]")]
    [ApiController]
    public class RoleApiController : ControllerBase
    {
            private RoleLogic roleLogic = new RoleLogic();
            [Route("add")]
            [HttpGet]
            public async Task<Boolean> AddRole(string Name,string Description, int Id) 
            { 
                bool result = await roleLogic.CreateNewRole(Name, Description, Id);
                return result;//true
            }
            [Route("all")]
            [HttpGet]
            public async Task<List<RoleViewModel>> GetAllRoles()
            {
                List<RoleViewModel> RoleList = new List<RoleViewModel>();
                var Roles = await roleLogic.GetAllRoles();
                if (Roles.Count > 0)
                {
                    foreach (var Role in Roles)
                    {
                        RoleViewModel rolemodel = new RoleViewModel()
                        {
                            rolename = Role.Name,
                            Description = Role.Description,
                            roleId = Role.Id

                        };
                        RoleList.Add(rolemodel);
                    }
                }
                return RoleList;
            }
        }
    }


