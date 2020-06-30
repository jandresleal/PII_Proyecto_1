namespace Library
{
    public class PropertyTypeFilter : IFilter
    {
        public string Value { get; }

        public PropertyTypeFilter(string value)
        {
            this.Value = value;
        }
    }
}