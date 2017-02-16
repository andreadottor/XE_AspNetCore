using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.DemoWeb5.Models;
using AspNetCore.DemoWeb5.Data;

namespace AspNetCore.DemoWeb5.Controllers
{

    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IAdventureWorksDataAccess _adventureWorksDataAccess;
        public CustomersController(IAdventureWorksDataAccess adventureWorksDataAccess)
        {
            this._adventureWorksDataAccess = adventureWorksDataAccess;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await this._adventureWorksDataAccess.GetAllCustomer();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await this._adventureWorksDataAccess.GetCustomer(id);
            if(customer == null)
                return NotFound($"Not found customer with id={id}");

            return new ObjectResult(customer);
        }


        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            if(ModelState.IsValid){
                // Salvo su database
                
                return Ok();
            }

            return BadRequest(ModelState);
        }
        
    }
}
