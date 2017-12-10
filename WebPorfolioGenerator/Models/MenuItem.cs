using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPorfolioGenerator.Models
{
    [Table("MenuItems")]
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }

        public int PortfolioId { get; set; }

        public int MenuOrder { get; set; }

        public string MenuName { get; set; }

        public string Url { get; set; }
    }
}
