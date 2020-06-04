namespace Library
{
    public class AreaFilter : IFilter
    {
        /// <summary>
        /// Filtro independiente creado únicamente para Area
        
        /// Cada filtro, respeta SRP dado que tiene una única razón
        /// para su cambio, cuando se modifican sus atributos.
        /// </summary>
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
