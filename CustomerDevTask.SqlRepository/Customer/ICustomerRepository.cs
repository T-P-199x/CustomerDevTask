using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerDevTask.SqlRepository.Customer
{
    public interface ICustomerRepository
    {
        Task<(bool, IEnumerable<Models.Customer.Customer>)> GetAll();

        Task<(bool, Models.Customer.Customer)> Get(int Id);

        Task<bool> Save(Models.Customer.Customer customer, SaveType saveType);
    }
}
