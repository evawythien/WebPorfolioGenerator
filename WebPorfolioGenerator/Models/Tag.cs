using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPorfolioGenerator.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public int PostId { get; set; }
        public int Name { get; set; }
    }
}
