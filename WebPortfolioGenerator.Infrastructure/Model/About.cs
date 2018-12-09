using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebPortfolioGenerator.Domain.Abstract;

namespace WebPortfolioGenerator.Infrastructure.Model
{
    [Table("Abouts")]
    public class About : Entity<About>
    {
        [Key]
        public int AboutId { get; set; }

        public int PortfolioId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Facebook { get; set; }
    }
}
