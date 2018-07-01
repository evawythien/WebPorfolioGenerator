using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPortfolioGenerator.Domain.Entity
{
    [Table("Fonts")]
    public class Font
    {
        [Key]
        public int Id { get; set; }

        public string FontName { get; set; }

        public string Link { get; set; }

        public string FontFamily { get; set; }

        public string Style { get; set; }
    }
}
