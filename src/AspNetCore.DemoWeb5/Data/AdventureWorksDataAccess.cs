using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using AspNetCore.DemoWeb5.Models;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AspNetCore.DemoWeb5.Data
{
    public class AdventureWorksDataAccess : IAdventureWorksDataAccess
    {
        private readonly string _connectrionString;

        public AdventureWorksDataAccess(string connectrionString)
        {
            this._connectrionString = connectrionString;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            using(var connection = new SqlConnection(this._connectrionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<Customer>(@"
SELECT [CustomerID]
      ,[Title]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[Suffix]
      ,[CompanyName]
      ,[EmailAddress]
      ,[Phone]
      ,[ModifiedDate]
  FROM [SalesLT].[Customer]");

                return result;
            }
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            using(var connection = new SqlConnection(this._connectrionString))
            {
                connection.Open();

                var result = await connection.QueryFirstOrDefaultAsync<Customer>(@"
SELECT [CustomerID]
      ,[Title]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[Suffix]
      ,[CompanyName]
      ,[EmailAddress]
      ,[Phone]
      ,[ModifiedDate]
  FROM [SalesLT].[Customer]
  WHERE CustomerID = @id", new { id = customerId});

                return result;
            }
        }
    }
}