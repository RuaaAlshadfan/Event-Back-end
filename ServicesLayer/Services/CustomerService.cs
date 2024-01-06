using ServicesLayer.Services.Interface;
using DomainLayer.Dto;
using DataAccessLayer.Repositories.Interface;

namespace ServicesLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void CreateNewCustomer(GetCustomerDTO dto)
        {
           _customerRepository.CreateNewCustomer(dto);
        }
        public void DetailCustomer(int Id)
        {
            _customerRepository.DetailCustomer(Id);
        }
        public void DeleteCustomer(int Id)
        {
            _customerRepository.DeleteCustomer(Id);
        }
        public void UpdateCustomer(GetCustomerDTO dto)
        {
           _customerRepository.UpdateCustomer(dto);
        }
        public GetCustomerDTO GetCustomerById(int Id)
        {
            return _customerRepository.GetCustomerById(Id);
        }
        public List<GetCustomerDTO> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }
    }
}
