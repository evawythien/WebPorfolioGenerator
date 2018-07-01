using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPortfolioGenerator.Domain.Entity
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        public int PostId { get; set; }

        [StringLength(200)]
        public int Name { get; set; }
    }
}
