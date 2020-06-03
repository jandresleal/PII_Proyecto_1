namespace Library
{
    public class HabitableAreaFilter : IFilter
    {
        private double value;

        public HabitableAreaFilter(double number)
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