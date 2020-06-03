namespace Library
{
    public class BathsFilter : IFilter
    {
        private int value;

        public BathsFilter(int number)
        {
            this.value = number;
        }

        public string GetValues()
        {
            string result = $"{this.value}";
            return result;
        }
    }
}