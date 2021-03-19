using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerDevTask.SqlRepository;
using CustomerDevTask.SqlRepository.Customer;

namespace CustomerDevTask.Service.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<(bool, IEnumerable<Models.Customer.Customer>)> GetAll()
        {
            return await _customerRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<(bool, Models.Customer.Customer)> Get(int Id)
        {
            return await _customerRepository.Get(Id).ConfigureAwait(false);
        }

        public async Task<bool> Update(Models.Customer.Customer customer)
        {
            return await _customerRepository.Save(customer, SaveType.Update).ConfigureAwait(false);
        }

        public async Task<bool> Insert(Models.Customer.Customer customer)
        {
            return await _customerRepository.Save(customer, SaveType.Insert).ConfigureAwait(false);
        }
    }
}
