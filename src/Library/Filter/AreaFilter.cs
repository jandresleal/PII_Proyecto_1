namespace Library
{
    public class AreaFilter : IFilter
    {
        private int  value;

        public AreaFilter(int number)
        {
            this.value = number;
        }

        public string GetValues()
        {
            string result = this.value.ToString();
            return result;
        }
    }
}
