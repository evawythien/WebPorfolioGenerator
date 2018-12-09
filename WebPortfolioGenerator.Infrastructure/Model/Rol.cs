using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPortfolioGenerator.Infrastructure.Model
{
    [Table("Rols")]
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
    }
}


