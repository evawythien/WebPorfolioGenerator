using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPorfolioGenerator.Models;

namespace WebPorfolioGenerator.DAL
{
    public class WebPortfolioInitializer : DropCreateDatabaseIfModelChanges<WebPortfolioContext>
    {
        protected override void Seed(WebPortfolioContext context)
        {

            List<User> users = new List<User>
            {
            new User{ UserId = 1,  UserName = "", Name = "", Surname = "", Password = "", RolId = "", Email = "mmm@mm.com", Birth = DateTime.Parse("2005-09-01"), MovilePhone="666666666", Phone = "999999999"},
            };

            users.ForEach(s => context.users.Add(users));
            context.SaveChanges();
        }
    }
}


