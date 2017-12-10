using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPorfolioGenerator.Models
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

        [MaxLength(8000)]
        public byte[] BackgroundImage { get; set; }

        [StringLength(8)]
        public string FirstColor { get; set; }

        [StringLength(8)]
        public string SecondColor { get; set; }

        public int FontId { get; set; }

    }
}
