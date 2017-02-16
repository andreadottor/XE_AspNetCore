using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.DemoWeb5.Models;

namespace AspNetCore.DemoWeb5.Data
{
    public interface IAdventureWorksDataAccess
    {
        Task<IEnumerable<Customer>> GetAllCustomer();

        Task<Customer> GetCustomer(int id);
    }
}