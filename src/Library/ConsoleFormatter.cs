namespace Library
{
    public class ConsoleFormatter : PrintFormatter
    {
        public string Message { get; set; }

        public string FormattedMessage { get; set; }

        public ConsoleFormatter(string message) : base(message) {}

        public override void Print()
        {

        }

        public override void FormatMessage()
        {

        }
    }
}