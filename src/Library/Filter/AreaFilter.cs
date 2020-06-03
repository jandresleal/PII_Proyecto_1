namespace Library
{
    public class AreaFilter : IFilter
    {
        private double  value;

        public AreaFilter(double number)
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
