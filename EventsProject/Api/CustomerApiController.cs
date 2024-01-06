using Microsoft.AspNetCore.Mvc;
using ServicesLayer.BL;
using Web.Models;
using DataAccessLayer;

namespace Web.Api
{
    [Route("api/[Customer]")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
            private CustomerLogic customerLogic = new CustomerLogic();
            [Route("add")]
            [HttpGet]
            public async Task<Boolean> AddCustomer(string Name, int Age, int Mobilephone, int Noofpeople, string Note, int Id)
            {
                bool result = await customerLogic.CreateNewCustomer(Name, Age, Mobilephone, Noofpeople,Note, Id);
                return result;//true
            }
            [Route("all")]
            [HttpGet]
            public async Task<List<CustomerViewModel>> GetAllCustomers()
            {
                List<CustomerViewModel> CustomerList = new List<CustomerViewModel>();
                var Customers = await customerLogic.GetAllCustomers();
                if (Customers.Count > 0)
                {
                    foreach (var Customer in Customers)
                    {
                        CustomerViewModel customermodel = new CustomerViewModel()
                        {
                            customername = Customer.Name,
                            customerage = Customer.Age,
                            customermobilephone = Customer.Mobilephone,
                            Noofpeople = Customer.Noofpeople,
                            Note=Customer.Note,
                            customerId=Customer.Id

                        };
                        CustomerList.Add(customermodel);
                    }
                }
                return CustomerList;
            }
        }
    }

