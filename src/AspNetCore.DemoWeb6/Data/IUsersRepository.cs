using System;
using System.Collections.Generic;
using AspNetCore.DemoWeb6.Models;

namespace AspNetCore.DemoWeb6.Data
{

    public interface IUsersRepository
    {
         IEnumerable<UserModel> Users { get; }
    }

}