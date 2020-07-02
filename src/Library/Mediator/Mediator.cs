namespace Library
{
    public class Mediator : IMediator
    {
        /// <summary>
        /// Es la clase encargada de implementar el Mediator
        /// Explicamos las razones de su uso en la interfaz IMediator
        /// </summary>
        /// <param name=></param>
        public Mediator() {  }

        public void AddFilter(IFilter filter, Database database)
        {
            database.AddFilter(filter);
        }

        public void AddProperty(IProperty property, Database database)
        {
            database.AddProperty(property);
        }

        public void Search(Database database)
        {
            database.API.AskAPI(database.GetFilters(), database.UserID);
        }

        public void CreateTextToPrint(IPrintFormatter formatter, Database database)
        {
          formatter.FormatMessage(database.GetPropertyList(), database.UserID);
        }

        public void SendInfoToAdapter(long id, string input)
        {
            SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).Adapter.SendTextToUser(id, input);
        }

        public void SetState(long id, Status state)
        {
            SingleInstance<SimpleInterpreter>.GetInstance.SetState(id, state);
        }
    }
}