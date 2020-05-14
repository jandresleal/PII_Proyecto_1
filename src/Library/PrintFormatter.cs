namespace Library
{
    public abstract class PrintFormatter : IPrintFormatter
    {
        public string Message { get; set; }

        public string FormattedMessage { get; set; }

        public PrintFormatter(string message)
        {
            this.Message = message;
        }

        public virtual void Print()
        {

        }

        public virtual void FormatMessage()
        {

        }

        public void SendMessageToMediator()
        {

        }
    }
}