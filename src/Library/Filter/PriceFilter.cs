using System;

namespace Library
{

    public class PriceFilter : IFilter
    {
        /// <summary>
        /// Filtro independiente creado únicamente para Price
        
        /// Cada filtro, respeta SRP dado que tiene una única razón
        /// para su cambio, cuando se modifican sus atributos.
        /// </summary>
        /// <value></value>
        
        public string Value { get; }

        public PriceFilter(string price)
        {
            this.Value = price;
        }
    }
}