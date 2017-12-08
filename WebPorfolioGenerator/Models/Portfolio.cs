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

        [StringLength(200)]
        public string PortfolioName { get; set; }

        [StringLength(200)]
        public string PortfolioSurname { get; set; }

        [StringLength(500)]
        public string UrlBackgroundImage { get; set; }

        [StringLength(8)]
        public string FirstColor { get; set; }

        [StringLength(8)]
        public string SecondColor { get; set; }
               
        public int FontId { get; set; }

        //public List<Font> fontList { get; set; }

      
    }
}
