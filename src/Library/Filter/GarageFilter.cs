namespace Library
{
    public class GarageFilter : IFilter
    {
        private bool value;

        public GarageFilter(bool b1)
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