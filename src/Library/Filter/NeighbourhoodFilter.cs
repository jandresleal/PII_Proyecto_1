namespace Library
{
    public class NeighbourhoodFilter : IFilter
    {
        private string neighbourhood;

        public NeighbourhoodFilter(string value)
        {
            this.neighbourhood = value.ToLower();
        }

        public string GetValues()
        {
            string result = this.neighbourhood;
            return result;
        }
    }
}