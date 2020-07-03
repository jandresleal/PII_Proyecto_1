namespace Library
{
    public class TransactionTypeHandler : BaseHandler
    {
        public override void Handle(InterpreterMessage m)
        {
            if (m.MessageType == Type.Transaction)
            {
                SingleInstance<Mediator>.GetInstance.AddFilter(
                    new TransactionTypeFilter(m.Value),
                    m.ID
                );
            }

            base.Handle(m);
        }
    }
}