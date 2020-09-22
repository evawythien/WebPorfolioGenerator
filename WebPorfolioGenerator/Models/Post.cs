using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPorfolioGenerator.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public int PortfolioId { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(200)]
        public string Subtitle { get; set; }
        
        public string Body { get; set; }
        
        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

    }
}
