using CustomerDevTask.Models.Customer;
using System.Collections.Generic;

namespace CustomerDevTask.Web.Models
{
    public class CustomersViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
