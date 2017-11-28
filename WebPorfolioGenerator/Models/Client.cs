using System.ComponentModel.DataAnnotations.Schema;

namespace WebPorfolioGenerator.Models
{
    [Table("Clients")]
    public class Client : User
    {
        public string BussinesName { get; set; }

        public int PortfolioId { get; set; }

        public int EmployeeId { get; set; }

        public string PortfolioInfo { get; set; }
    }
}
