using DomainLayer.Dto;

namespace ServicesLayer.Services.Interface
{
    public interface ICustomerService
    {
        void CreateNewCustomer(GetCustomerDTO dto);
        void DeleteCustomer(int Id);
        void UpdateCustomer(GetCustomerDTO customerDto);
        void DetailCustomer(int Id);
        GetCustomerDTO GetCustomerById(int Id);
        List<GetCustomerDTO> GetAllCustomers();
    }

}