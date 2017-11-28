using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPorfolioGenerator.Models
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        public int IdLocation { get; set; }

        public string Street { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string PostalCode { get; set; }
    }
}
