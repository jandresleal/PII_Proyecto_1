namespace Library
{
    public abstract class Mediator : IMediator
    {
        public IList<IFilter> Filters {get; set;}

        public IList<IProperty> properties {get; set;}

        public String message {get; set;}

        public virtual void GetItemsToPrint()
        {
            
        }

        public string Search(APIsSearchEngines api)
        {

        }

        public IList<IProperty> CreatePropertyList(string data)
        {

        }

        public virtual string CreateTextToPrint()
        {

        }

        public void SendSearchResults(string message)
        {

        }
    }
}