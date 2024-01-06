using DataAccessLayer.DataContext;
using DomainLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServicesLayer.Services.Interface;
using Web.Models.Customer;

namespace Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult ListCustomer()
        {
            List<CustomerModel> model = new List<CustomerModel>();
            var list = _customerService.GetAllCustomers();
            foreach (var item in list)
            {
                var res = new CustomerModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    MobileNumber = item.MobileNumber,
                    NumberOfPeople = item.NumberOfPeople,
                    Note = item.Note,
                };
                model.Add(res);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateCustomer()
        {
            CustomerModel model = new CustomerModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateCustomer(CustomerModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var customerDto = new GetCustomerDTO()
                {
                    Name = model.Name,
                    Age = model.Age,
                    MobileNumber = model.MobileNumber,
                    NumberOfPeople = model.NumberOfPeople,
                    Note = model.Note,
                    CreaterUserId = 1,
                    CreationTime = DateTime.Now,
                };

                _customerService.CreateNewCustomer(customerDto);

                return RedirectToAction("ListCustomer");
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteCustomer(int Id)
        {
            _customerService.DeleteCustomer(Id);

            return RedirectToAction("ListCustomer");
        }

        [HttpGet]
        public ActionResult DetailCustomer(int Id)
        {
            var data = _customerService.GetCustomerById(Id);
            var customers = new CustomerModel()
            {
                Id = data.Id,
                Name = data.Name,
                Age = data.Age,
                MobileNumber = data.MobileNumber,
                NumberOfPeople = data.NumberOfPeople,
                Note=data.Note
            };
            return View(customers);
        }

        [HttpGet]
        public ActionResult EditCustomer(int Id)
        {
            var data = _customerService.GetCustomerById(Id);
            var customer = new CustomerModel()
            {
                Id = data.Id,
                Name = data.Name,
                Age = data.Age,
                MobileNumber = data.MobileNumber,
                NumberOfPeople = data.NumberOfPeople,
                Note=data.Note

            };
            return View(customer);
        }
        [HttpPost]
        public ActionResult UpdateCustomer(CustomerModel model)
        {
            try
            {
                if (!model.Id.HasValue)
                {
                    View(model);
                }

                var customerDto = new GetCustomerDTO()
                {
                    Id = model.Id.Value,
                    Name = model.Name,
                    Age = model.Age,
                    MobileNumber = model.MobileNumber,
                    NumberOfPeople = model.NumberOfPeople,
                    Note = model.Note,
                    UpdateUserId = 1,
                    UpdateTime = DateTime.Now,
                };
                _customerService.UpdateCustomer(customerDto);
                return RedirectToAction("ListCustomer");
            }
            catch (Exception ex)
            {
                return RedirectToAction("EditCustomer", model);
            }
        }
    }
}

