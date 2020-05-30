namespace Library
{
    public class ConsoleFormatter : PrintFormatter
    {

        public ConsoleFormatter(string message) : base(message) {}

        public override string FormatMessage(string data)
        {
            return data;
        }
    }
}