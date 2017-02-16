using System;
using System.Collections.Generic;
using AspNetCore.DemoWeb4.Models;

namespace AspNetCore.DemoWeb4.Data
{

    public interface IUsersRepository
    {
         IEnumerable<UserModel> Users { get; }
    }

}