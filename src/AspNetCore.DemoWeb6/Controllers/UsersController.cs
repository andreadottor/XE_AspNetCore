using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.DemoWeb6.Models;
using AspNetCore.DemoWeb6.Data;

namespace AspNetCore.DemoWeb6.Controllers
{

    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _userRepository;
        public UsersController(IUsersRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return this._userRepository.Users;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = this._userRepository.Users.FirstOrDefault(u => u.Id == id);
            if(user == null)
                return NotFound($"Not found user with id={id}");

            return new ObjectResult(user);
        }
        
    }
}
