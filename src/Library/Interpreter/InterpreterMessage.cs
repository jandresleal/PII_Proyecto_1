namespace Library
{
    public class InterpreterMessage
    {
        public string Type { get; set; }
        
        public string Value { get; set; }

        public InterpreterMessage(string type, string value)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}