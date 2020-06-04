namespace Library
{
    public class GarageFilter : IFilter
    {
        /// <summary>
        /// Filtro independiente creado únicamente para Garage
        
        /// Cada filtro, respeta SRP dado que tiene una única razón
        /// para su cambio, cuando se modifican sus atributos.
        /// </summary>
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