namespace Library
{
    public class TransactionTypeFilter
    {
        public string Value { get; private set; }

        public TransactionTypeFilter(string value)
        {
            this.Value = value;
        }
    }
}