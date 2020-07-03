namespace Library
{
    public class TransactionTypeHandler : BaseHandler
    {
        /// <summary>
        /// Esta clase implementa la interfaz BaseHandler, tiene como única responsabilidad reconocer
        /// el type correspondiente al tipo de Transacción(compra o alquiler)
        /// para luego ensamblar el filtro del type con ese valor. Cumple con SRP
        /// </summary>
        /// <param name="m"></param>
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