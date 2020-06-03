namespace Library
{
    public class SwimmingPoolFilter : IFilter
    {
        /// <summary>
        ///
        
        /// Cada filtro, respeta SRP dado que tiene una única razón
        /// para su cambio, cuando se modifican sus atributos.  
        /// </summary>
        private bool value;

        public SwimmingPoolFilter(bool b1)
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