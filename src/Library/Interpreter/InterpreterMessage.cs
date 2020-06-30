namespace Library
{
    public enum Type { Department, Neighbourhood, Property, Transaction }

    public class InterpreterMessage
    {
        public Type MessageType { get; }
        
        public string Value { get; }

        public long ID { get; }

        public InterpreterMessage(Type type, string value, long id)
        {
            this.MessageType = type;
            this.Value = value;
            this.ID = id;
        }
    }
}