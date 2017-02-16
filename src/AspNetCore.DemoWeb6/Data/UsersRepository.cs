using System;
using System.Collections.Generic;
using AspNetCore.DemoWeb6.Models;

namespace AspNetCore.DemoWeb6.Data
{
    public class UsersRepository : IUsersRepository
    {
        private string[] names = new string[] {"Andrea","Daniele","Pippo","Pluto","Paperino"};
        private string[] surns = new string[] {"Dottor","Morosinotto","Verdi","Rossi","Giallo"};
        private string[] citys = new string[] {"Milano", "Roma", "Venezia", "Padova", "Treviso"};
        private string[] addrs = new string[] {"Via", "Piazza", "Vicolo"};

        public IEnumerable<UserModel> Users { get; private set; }

        public UsersRepository(int n)
        {
            var list = new List<UserModel>();

            for(var i = 0; i< n; i++)
            {
                var user = new UserModel()
                {
                    Id = i,
                    Name = GetRandom(names) + " " + GetRandom(surns),
                    Addr = GetRandom(addrs),
                    City = GetRandom(citys),
                    Age = 10 + i % 50,
                    Sex = (i % 2) == 0 ? true : false,
                    Cap = rnd.Next(10000, 99999)
                };
                list.Add(user);
            }
            this.Users = list.ToArray();
        }

        static Random rnd = new Random();
        private string GetRandom(string[] list)
        {
            int index = rnd.Next(list.Length);

            return list[index];
        }

    } 
}