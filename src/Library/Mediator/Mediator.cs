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
            database.SetResult(formatter.FormatMessage(database.GetPropertyList()));
            
            this.SendInfoToAdapter(database, database.GetResult());

            database.SetState(Status.SearchDone);
        }

        public void SendInfoToAdapter(Database database, string input)
        {
            database.Adapter.SendTextToUser(database.UserID, input);
        }
    }
}