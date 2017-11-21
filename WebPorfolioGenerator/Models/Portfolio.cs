namespace WebPorfolioGenerator.Models
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public int PortfolioName { get; set; }
        public int PortfolioSurname { get; set; }
        public string UrlBackgroundImage { get; set; }
        public string FirstColor { get; set; }
        public string SecondColor { get; set; }
        public Font Fuente { get; set; }
    }
}
