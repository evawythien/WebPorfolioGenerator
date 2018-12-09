using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPortfolioGenerator.Infrastructure.Model
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Body { get; set; }

        public int PostId { get; set; }

        public DateTime Published { get; set; }
    }
}
