using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPorfolioGenerator.Models
{
    public class Client : User
    {
        public string BussinesName { get; set; }
        public string PortfolioId { get; set; }
    }
}
