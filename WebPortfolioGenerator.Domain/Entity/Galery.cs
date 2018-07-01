using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPortfolioGenerator.Domain.Entity
{
    [Table("Galerys")]
    public class Galery
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int PortfolioId { get; set; }

    }
}
