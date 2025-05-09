namespace RC_GUI_WATS.Core.Models
{
    public class Instrument
    {
        public string ISIN { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal TickSize { get; set; }
    }
}