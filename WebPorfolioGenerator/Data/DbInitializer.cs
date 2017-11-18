using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPorfolioGenerator.Models;

namespace WebPorfolioGenerator.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {

            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Client.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Client[]
            {
                new Client{UserId = 1,  UserName ="evena",  Name ="eva",  Surname ="devena",  Password ="",  RolId =1,  Email ="",  Birth =DateTime.Parse("2002-09-01"),  MovilePhone ="",  Phone ="" },
                new Client{UserId = 2,  UserName ="pgarcia",  Name ="paco",  Surname ="garcia",  Password ="",  RolId =2,  Email ="",  Birth =DateTime.Parse("2002-09-01"),  MovilePhone ="",  Phone ="" },
                new Client{UserId = 3,  UserName ="psanchez",  Name ="pepe",  Surname ="sanchez",  Password ="",  RolId =1,  Email ="",  Birth =DateTime.Parse("2002-09-01"),  MovilePhone ="",  Phone ="" },
                new Client{UserId = 4,  UserName ="plopez",  Name ="pedro",  Surname ="lopez",  Password ="",  RolId =2,  Email ="",  Birth =DateTime.Parse("2002-09-01"),  MovilePhone ="",  Phone ="" },
            };
            foreach (Client s in students)
            {
                context.Client.Add(s);
            }
            context.SaveChanges();

            context.Database.EnsureCreated();

        }
    }
}
