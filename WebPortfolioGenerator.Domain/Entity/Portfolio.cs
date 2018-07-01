using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPortfolioGenerator.Domain.Entity
{
    [Table("Portfolios")]
    public class Portfolio
    {
        [Key]
        public int PortfolioId { get; set; }

        public int UserId { get; set; }

        [StringLength(200)]
        public string PortfolioName { get; set; }

        [StringLength(200)]
        public string PortfolioSurname { get; set; }

        [StringLength(6)]
        public string ExtBackgroundImage { get; set; }

        [NotMapped]
        public string ImageName => PortfolioId + ExtBackgroundImage;

        [StringLength(8)]
        public string FirstColor { get; set; }

        [StringLength(8)]
        public string SecondColor { get; set; }

        public int FontId { get; set; }

    }
}
