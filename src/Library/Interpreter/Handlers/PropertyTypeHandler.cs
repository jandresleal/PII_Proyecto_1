namespace Library
{
    public class PropertyTypeHandler : BaseHandler
    {
        public override void Handle(InterpreterMessage m)
        {
            if (m.MessageType == Type.Property)
            {
                SingleInstance<Mediator>.GetInstance.AddFilter(
                    new PropertyTypeFilter(m.Value),
                    m.ID
                );
            }

            base.Handle(m);
        }
    }
}