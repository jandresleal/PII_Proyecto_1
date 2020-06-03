namespace Library
{
    public class RoomsFilter : IFilter
    {
        private int value;

        public RoomsFilter(int number)
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