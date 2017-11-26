using System.ComponentModel.DataAnnotations;

namespace WebPorfolioGenerator.Models
{
    public class Client : User
    {
        private int _id;
        [Key]
        public int ClientId
        {
            get { return _id; }
        }
        public string BussinesName { get; set; }
        public string PortfolioId { get; set; }
    }
}
