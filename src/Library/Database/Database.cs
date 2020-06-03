using System.Collections.Generic;

namespace Library
{
    public class Database
    {
        public List<IFilter> Filters {get; set;}

        public List<IProperty> Properties {get; set;}

        public List<IProperty> ExtendedProperties {get; set;}

        public string Result {get; set;}

        public IChannelAdapter Adapter { get; }

        public Database(IChannelAdapter adapter)
        {
            this.Result = string.Empty;
            this.Filters = new List<IFilter>();
            this.Properties = new List<IProperty>();
            this.ExtendedProperties = new List<IProperty>();
            this.Adapter = adapter;
        }
    }
}