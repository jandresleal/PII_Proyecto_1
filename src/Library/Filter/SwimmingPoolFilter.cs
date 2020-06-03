namespace Library
{
    public class SwimmingPoolFilter : IFilter
    {
        private bool value;

        public SwimmingPoolFilter(bool b1)
        {
            this.value = b1;
        }

        public string GetValues()
        {
            string result = $"{this.value}";
            return result;
        }
    }
}