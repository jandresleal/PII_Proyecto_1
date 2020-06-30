namespace Library
{
    public class DepartmentFilter : IFilter
    {
        public string Value { get; }

        public DepartmentFilter(string value)
        {
            this.Value = value;
        }
    }
}