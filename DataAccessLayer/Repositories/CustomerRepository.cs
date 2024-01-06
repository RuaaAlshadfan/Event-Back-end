using DataAccessLayer.DataContext;
using DataAccessLayer.Repositories.Interface;
using DomainLayer.Dto;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EventContext _context;

        public CustomerRepository(EventContext context)
        {
            _context = context;
        }
        public void CreateNewCustomer(GetCustomerDTO model)
        {
            try
            {
                var customer = new Customers()
                {
                    Name = model.Name,
                    Age = model.Age,
                    MobileNumber = model.MobileNumber,
                    NumberOfPeople = model.NumberOfPeople,
                    Note = model.Note,
                    CreationTime = DateTime.Now,
                    CreaterUserId = 1,
                    IsDeleted = false,
                };
                _context.Customers.Add(customer);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DetailCustomer(int Id)
        {
            var Customer = _context.Customers.Where(I => I.Id == Id).FirstOrDefault();

            var customers = new GetCustomerDTO()
            {
                Id = Id,
            };
        }
        public void DeleteCustomer(int Id)
        {
            try
            {
                var customerData = _context.Customers.Where(x => x.Id == Id).FirstOrDefault();
                customerData.IsDeleted = true;

                _context.Customers.Update(customerData);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateCustomer(GetCustomerDTO model)
        {
            try
            {
                var customer = new Customers()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Age = model.Age,
                    MobileNumber = model.MobileNumber,
                    NumberOfPeople = model.NumberOfPeople,
                    Note = model.Note,
                    UpdateTime = DateTime.Now,
                    UpdateUserId = 1
                };
                _context.Customers.Update(customer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GetCustomerDTO GetCustomerById(int Id)
        {
            var Customer = _context.Customers.Where(I => I.Id == Id).FirstOrDefault();
            var customer = new GetCustomerDTO()
            {
                Id = Customer.Id,
                Name = Customer.Name,
                Age = Customer.Age,
                NumberOfPeople = Customer.NumberOfPeople,
                MobileNumber = Customer.MobileNumber,
                Note = Customer.Note
            };
            return customer;
        }
        public List<GetCustomerDTO> GetAllCustomers()
        {
            List<GetCustomerDTO> Customers = new List<GetCustomerDTO>();

            var selectedList = _context.Customers.Where(x => !x.IsDeleted).ToList();

            if (selectedList.Count > 0)
            {
                foreach (var item in selectedList)
                {
                    var customer = new GetCustomerDTO()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Age = item.Age,
                        MobileNumber = item.MobileNumber,
                        NumberOfPeople = item.NumberOfPeople,
                        Note = item.Note,
                    };
                    Customers.Add(customer);
                };
            };
            return Customers;
        }
    }
}
    

