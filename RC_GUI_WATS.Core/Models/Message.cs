namespace RC_GUI_WATS.Core.Models
{
    public class Message
    {
        public int SequenceNumber { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}