namespace Library
{
    public class GymFilter : IFilter
    {
        private bool value;

        public GymFilter(bool b1)
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

