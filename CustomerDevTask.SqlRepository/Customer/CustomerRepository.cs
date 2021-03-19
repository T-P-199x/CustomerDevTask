using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace CustomerDevTask.SqlRepository.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Models.Customer.Customer>> GetAll()
        {
            IEnumerable<Models.Customer.Customer> customers = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                customers = await connection.QueryAsync<Models.Customer.Customer>(
                    "[dbo].[Customer_GetAll]",
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return customers;
        }

        public async Task<Models.Customer.Customer> Get(int Id)
        {
            Models.Customer.Customer customer = null;

            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", Id, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString))
            {
                customer = await connection.QuerySingleAsync<Models.Customer.Customer>(
                    "[dbo].[Customer_GetById]",
                    parameters,
                    commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }

            return customer;
        }

        public async Task<bool> Save(Models.Customer.Customer customer, SaveType saveType)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@FirstName", customer.FirstName);
            parameters.Add("@Surname", customer.Surname);
            parameters.Add("@DateOfBirth", customer.DateOfBirth);
            parameters.Add("@TelephoneNumber", customer.TelephoneNumber);

            var storedProcedure = string.Empty;
            switch(saveType)
            {
                case SaveType.Insert:
                    storedProcedure = "[dbo].[Customer_Insert]";
                    break;
                case SaveType.Update:
                    parameters.Add("@CustomerId", customer.Id);
                    storedProcedure = "[dbo].[Customer_Update]";
                    break;
            }
                
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.QueryAsync(
                        storedProcedure,
                        parameters,
                        commandType: CommandType.StoredProcedure)
                        .ConfigureAwait(false);
                }
            }
            catch (SqlException ex)
            {
                return false;
            }

            return true;
        }
    }
}
