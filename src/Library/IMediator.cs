namespace Library
{
        public interface IMediator
    {
        void GetItemsToPrint()
        {
            
        }

        string Search(APIsSearchEngines api)
        {
            
        }

        IList<IProperty> CreatePropertyList(string data)
        {

        }

        string CreateTextToPrint(IList<IProperty> lista)
        {

        }
    }
}