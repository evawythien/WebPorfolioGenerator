using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPorfolioGenerator.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int PortfolioId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public List<Tag> TagList { get; set; }
    }
}
