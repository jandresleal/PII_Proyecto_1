namespace Library
{
    public class InterpreterMessage
    {
        public string Type { get; }
        
        public string Value { get; }

        public long ID { get; }

        public InterpreterMessage(string type, string value, long id)
        {
            this.Type = type;
            this.Value = value;
            this.ID = id;
        }
    }
}