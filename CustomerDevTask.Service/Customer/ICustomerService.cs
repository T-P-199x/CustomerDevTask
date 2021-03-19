using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerDevTask.Service.Customer
{ 
    public interface ICustomerService
    {
        Task<(bool, IEnumerable<Models.Customer.Customer>)> GetAll();

        Task<(bool, Models.Customer.Customer)> Get(int Id);

        Task<bool> Update(Models.Customer.Customer customer);

        Task<bool> Insert(Models.Customer.Customer customer);
    }
}
