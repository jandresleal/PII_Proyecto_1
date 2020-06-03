namespace Library
{
    public class BarbecueFilter : IFilter
    {
        private bool value;

        public BarbecueFilter(bool b1)
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