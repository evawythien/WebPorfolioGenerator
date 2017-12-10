using System;
using System.Linq;
using WebPorfolioGenerator.Models;

namespace WebPorfolioGenerator.DAL
{
    public class WebPortfolioInitializer
    {
        public static void Initialize(WebPortfolioContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var students = new User[]
            {
            new User{ UserId= 1, UserName = "Peggy", Name = "Justice",Surname = "Barzdukas", Password = "abcd123",RolId = 1, Email = "",Birth=DateTime.Parse("2002-09-01"), MovilePhone = "666666666", Phone = "999999999"},

            };
            foreach (User s in students)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();


        }
    }
}


