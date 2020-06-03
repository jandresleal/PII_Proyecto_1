namespace Library
{
    public class GardenFilter : IFilter
    {
        private bool value;

        public GardenFilter(bool b1)
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