using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.DemoWeb4.Models;
using AspNetCore.DemoWeb4.Data;
using Microsoft.Extensions.Logging;

namespace AspNetCore.DemoWeb4.Controllers
{

    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger _logger;
        private readonly IUsersRepository _userRepository;
        public UsersController(IUsersRepository userRepository, ILogger<UsersController> logger)
        {
            this._userRepository = userRepository;
            this._logger = logger;
        }

        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            this._logger.LogInformation("Enter on method Get");

            return this._userRepository.Users;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            this._logger.LogInformation($"Enter on method Get({id})");

            var user = this._userRepository.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound($"Not found user with id={id}");

            return new ObjectResult(user);
        }

    }
}
