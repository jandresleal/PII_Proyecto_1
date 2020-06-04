namespace Library
{
    public class RoomsFilter : IFilter
    {
        /// <summary>
        /// Filtro independiente creado únicamente para Room
        
        /// Cada filtro, respeta SRP dado que tiene una única razón
        /// para su cambio, cuando se modifican sus atributos.
        /// </summary>
        private int value;

        public RoomsFilter(int number)
        {
            this.value = number;
        }

        public string GetValues()
        {
            string result = $"{this.value}";
            return result;
        }
    }
}