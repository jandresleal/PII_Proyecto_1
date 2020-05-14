namespace Library
{
    public class WhatsAppFormatter : PrintFormatter
    {
        public string Message { get; set; }

        public string FormattedMessage { get; set; }

        public WhatsAppFormatter(string message) : base(message) {}

        public override void Print()
        {

        }

        public override void FormatMessage()
        {
            
        }
    }
}