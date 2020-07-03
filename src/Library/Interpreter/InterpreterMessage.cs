namespace Library
{
    public enum Type { Department, Neighbourhood, Property, Transaction }

    /// <summary>
    /// Es la clase encargada de persistir el mensaje interpretado por el interpreter
    /// este mensaje se irá pasando por los handles y será utilizado
    /// por el indicado, generando así, el filtro correspondiente
    /// </summary>
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