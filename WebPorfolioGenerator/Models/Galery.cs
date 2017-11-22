using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPorfolioGenerator.Models
{
    public class Galery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PortfolioId { get; set; }
        public List<String> Photos { get; set; }
    }
}
