namespace Library
{
        public interface IMediator
    {
        void GetItemsToPrint()
        {
            
        }

        string Search(IAPIsSearchEngines api)
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