namespace Library
{
    public class WhatsAppFormatter : PrintFormatter
    {

        public WhatsAppFormatter(string message) : base(message) {}

        public override string FormatMessage(string data)
        {
            return data;
        }
    }
}