namespace Library
{
    public class HabitableAreaFilter : IFilter
    {
        /// <summary>
        /// Filtro independiente creado únicamente para HabitableArea
        
        /// Cada filtro, respeta SRP dado que tiene una única razón
        /// para su cambio, cuando se modifican sus atributos.
        /// </summary>

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