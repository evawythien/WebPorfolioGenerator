using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPorfolioGenerator.Models
{
    [Table("Menus")]
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        public int PortfolioId { get; set; }

    }
}
