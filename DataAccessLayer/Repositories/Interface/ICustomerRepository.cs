using DomainLayer.Dto;

namespace DataAccessLayer.Repositories.Interface
{
    public interface ICustomerRepository
    {
        void CreateNewCustomer(GetCustomerDTO model);
        void DeleteCustomer(int Id);
        void UpdateCustomer(GetCustomerDTO model);
        void DetailCustomer(int Id);
        GetCustomerDTO GetCustomerById(int Id);
        List<GetCustomerDTO> GetAllCustomers();
    }
}
