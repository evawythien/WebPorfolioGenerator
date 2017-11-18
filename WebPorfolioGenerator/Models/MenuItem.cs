using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPorfolioGenerator.Models
{
    public class MenuItem
    {
        public int MenuId { get; set; }
        public int MenuItemId { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
    }
}
