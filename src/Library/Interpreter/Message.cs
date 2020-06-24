namespace Library
{
    public class Message
    {
        public string Type { get; set; }
        
        public string Value { get; set; }

        public Message(string type, string value)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}