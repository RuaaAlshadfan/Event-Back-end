using DataAccessLayer.DataContext;
using DataAccessLayer.Repositories.Interface;
using DomainLayer.Dto;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EventContext _context;

        public UserRepository(EventContext context)
        {
            _context = context;
        }
        public void CreateNewUser(GetUserDTO model)
        {
            try
            {
                var user = new Users()
                {
                    Name = model.Name,
                    EmailAddress= model.Emailaddress,
                    MobileNumber = model.MobileNumber,
                    Password = model.Password,
                    UpdateTime = DateTime.Now,
                    UpdateUserId = 1,
                    IsDeleted = false,
                };
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DetailUser(int Id)
        {
            var User = _context.Users.Where(I => I.Id == Id).FirstOrDefault();

            var users = new GetUserDTO()
            {
                Id = Id,
            };
        }
        public void DeleteUser(int Id)
        {
             try
             {
                  var userData = _context.Users.Where(x => x.Id == Id).FirstOrDefault();
                  userData.IsDeleted = true;

                  _context.Users.Update(userData);
                  _context.SaveChanges();
             }
             catch (Exception ex)
             {
                    throw ex;
             }
        }
        public void UpdateUser(GetUserDTO model)
        {
            try
            {
                var user = new Users()
                {
                    Id = model.Id,
                    Name = model.Name,
                    MobileNumber = model.MobileNumber,
                    EmailAddress = model.Emailaddress,
                    Password = model.Password,
                    UpdateTime = DateTime.Now,
                    UpdateUserId = 1
                };
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GetUserDTO GetUserById(int Id)
        {
            var User = _context.Users.Where(I => I.Id == Id).FirstOrDefault();
            var us = new GetUserDTO()
            { 
            Id = User.Id,
            Name = User.Name,
            Emailaddress = User.EmailAddress,
            Password = User.Password,
            MobileNumber = User.MobileNumber,
              
            };
            return us;
        }
        public List<GetUserDTO> GetAllUsers()
        {
            List<GetUserDTO> Users = new List<GetUserDTO>();

            var selectedList = _context.Users.Where(x => !x.IsDeleted).ToList();

            if (selectedList.Count > 0)
            {
                foreach (var item in selectedList)
                {
                    var user = new GetUserDTO()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        MobileNumber = item.MobileNumber,
                        Emailaddress = item.EmailAddress,
                        Password = item.Password,
                    };
                    Users.Add(user);
                };
            };
            return Users;
        }
        public List<UserForDropDwonListOutput> GetAllUsersForDropDwonList()
        {
            var selectedList = from Users in _context.Users
                               select new UserForDropDwonListOutput()
                               {
                                   Id = Users.Id,
                                   DisplayName = Users.Name,
                               };

            return selectedList.ToList();
        }
    }
}


