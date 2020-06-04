namespace Library
{
    public class HabitableAreaFilter : IFilter
    {
        private int value;

        public HabitableAreaFilter(int number)
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