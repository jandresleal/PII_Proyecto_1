using System.Collections.Generic;
using Library.ApiSearchEngine;

namespace Library
{
    public class Mediator : IMediator
    {
        public Mediator(IChannelAdapter adapter)
        {
            this.database = new Database(adapter);
        }

        private Database database { get; }

        public virtual void GetItemsToPrint()
        {
            
        }

        public string Search(IAPIsSearchEngines api)
        {
            return IAPIsSearchEngines.AskAPI(database.Filters);
        }

        public void CreateFiltersList(string input)
        {
            Interpreter interpreter = new SimpleInterpreter();

            interpreter.ParseInput(input);

            if (interpreter.CheckForEmptyFilters())
            {
                SendInfoToAdapter("Por favor, introduzca parámetros válidos para la búsqueda.");
            }
            else
            {
                database.Filters = interpreter.Filters;
            }
        }

        public void CreatePropertyList(IAPIsSearchEngines api)
        {
            database.ExtendedProperties = api.Parse(Search(api));
        }
        public void CreateExtendedPropertyList(string data)
        {
            database.ExtendedProperties = 
        }

        public void CreateTextToPrint(IPrintFormatter formatter)
        {
            database.Result = formatter.FormatMessage(database.Properties);
        }

        public void SendInfoToAdapter()
        {
            database.Adapter.SendTextToUser(database.Result);
        }

        public void SendInfoToAdapter(string question)
        {
            database.Adapter.SendTextToUser(question);
        }
    }
}