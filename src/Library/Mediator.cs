using System.Collections.Generic;
using System;

namespace Library
{
    public abstract class Mediator : IMediator
    {
        public IList<IFilter> Filters {get; set;}

        public IList<IProperty> Properties {get; set;}

        public IList<IProperty> ExtendedProperties {get; set;}

        public string Message {get; set;}

        public virtual void GetItemsToPrint()
        {
            
        }

        public string Search(IAPIsSearchEngines api)
        {

        }

        public IList<IProperty> CreatePropertyList(string data)
        {

        }
        public IList<IProperty> CreateExtendedPropertyList(string data)
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