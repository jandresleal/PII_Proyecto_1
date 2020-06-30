namespace Library
{
    public class DepartmentHandler : BaseHandler
    {
        public override void Handle(InterpreterMessage m)
        {
            if (m.MessageType == Type.Department)
            {
                SingleInstance<Mediator>.GetInstance.AddFilter(
                    new DepartmentFilter(m.Value),
                    SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(m.ID)
                ); 
            }

            base.Handle(m);
        }
    }
}