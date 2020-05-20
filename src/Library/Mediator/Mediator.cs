using System.Collections.Generic;

namespace Library
{
    public abstract class Mediator : IMediator
    {
        public Mediator()
        {
            this.database = new Database();
        }

        private Database database { get; }

        public virtual void GetItemsToPrint()
        {
            
        }

        public string Search(IAPIsSearchEngines api)
        {
            return IAPIsSearchEngines.AskAPI(database.Filters);
        }

        public void CreatePropertyList(IAPIsSearchEngines api)
        {
            database.ExtendedProperties = api.Parse(Search(api))
        }
        public void CreateExtendedPropertyList(string data)
        {
            database.ExtendedProperties = 
        }

        public void CreateTextToPrint(IPrintFormatter formatter)
        {
            database.Result = formatter.FormatMessage(database.Properties);
        }

        public void SendSearchResults(IChannelAdapter adapter)
        {
            adapter.SendTextToUser(database.Result);
        }
    }
}