using CustomerDevTask.Web.Models;
using CustomerDevTask.Models.Customer;
using System.Collections.Generic;

namespace CustomerDevTask.Web
{
    public static class Mappers
    {
        public static Customer Map(EditableCustomerViewModel value)
        {
            return new Customer
            {
                Id = value.Id,
                FirstName = value.FirstName,
                Surname = value.Surname,
                DateOfBirth = value.DateOfBirth.Value,
                TelephoneNumber = value.TelephoneNumber,
            };
        }

        public static EditableCustomerViewModel Map(Customer value)
        {
            return new EditableCustomerViewModel
            {
                FirstName = value.FirstName,
                Surname = value.Surname,
                DateOfBirth = value.DateOfBirth,
                TelephoneNumber = value.TelephoneNumber,
            };
        }

        public static CustomersViewModel Map(IEnumerable<Customer> value)
        {
            return new CustomersViewModel
            {
                Customers = value,
            };
        }
    }
}
