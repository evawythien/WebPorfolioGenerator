using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPorfolioGenerator.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public int PortfolioId { get; set; }
        public List<MenuItem> ItemList { get; set; }
    }
}
