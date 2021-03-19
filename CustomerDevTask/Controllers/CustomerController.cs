using Microsoft.AspNetCore.Mvc;
using CustomerDevTask.Service.Customer;
using System.Threading.Tasks;
using CustomerDevTask.Web;
using CustomerDevTask.Web.Models;

namespace CustomerDevTask.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> List()
        {
            var (success, customers) = await _customerService.GetAll().ConfigureAwait(false);

            var viewModel = Mappers.Map(customers);

            viewModel.Success = success;

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var (sucess, customer) = await _customerService.Get(id).ConfigureAwait(false);

            var viewModel = Mappers.Map(customer);
            viewModel.Success = sucess;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditableCustomerViewModel model)
        {
            var validPhoneNumber = TelephoneValidator.Validate(model.TelephoneNumber);
            if (!validPhoneNumber)
            {
                ModelState.AddModelError(nameof(model.TelephoneNumber), "Telephone Number can only be numeric");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customer = Mappers.Map(model);

            model.IsSaved = await _customerService.Update(customer).ConfigureAwait(false);

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new EditableCustomerViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(EditableCustomerViewModel model)
        {
            var validPhoneNumber = TelephoneValidator.Validate(model.TelephoneNumber);
            if (!validPhoneNumber)
            {
                ModelState.AddModelError(nameof(model.TelephoneNumber), "Telephone Number can only be numeric");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customer = Mappers.Map(model);

            model.IsSaved = await _customerService.Insert(customer).ConfigureAwait(false);

            return View(model);
        }
    }
}
