namespace Library
{
    public class TransactionTypeHandler : BaseHandler
    {
        /// <summary>
        /// Esta clase implementa la interfaz BaseHandler, tiene como única responsabilidad reconocer
        /// el type correspondiente al tipo de Transacción(compra o alquiler)
        /// para luego ensamblar el filtro del type con ese valor. Cumple con SRP
        ///         
        /// También sigue el patrón creator dado que son responsables de crear los filtros. Para esto
        /// utilizan el mensaje interpetado en primera instancia por el interpreter
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