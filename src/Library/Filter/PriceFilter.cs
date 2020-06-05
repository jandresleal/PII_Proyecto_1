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
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string ExtendedRange { get; }

        public PriceFilter(int minPrice, int maxPrice)
        {
            this.MinPrice = minPrice;
            this.MaxPrice = maxPrice;
            this.ExtendedRange = this.CalculateExtendedRange(minPrice,maxPrice);
        }

        public string GetValues()
        {
            string result = $"{this.MinPrice},";
            result += $"{this.MaxPrice}";
            
            return result;
        }

        public string GetExtendedRangeValue()
        {
            string result = $"{this.ExtendedRange}";
            return result;
        }
        /// <summary>
        /// Este método realiza un cálculo para mostrar un rango 
        /// extendido de los precios.
        /// </summary>
        /// <param name="min">Precio mínimo ingresado</param>
        /// <param name="max">Precio máximo ingresado</param>
        /// <returns></returns>
        public string CalculateExtendedRange(int min, int max)
        {
            string result = $"{(min * 80 / 100)},{(max * 125 / 100)}";
            return result;
        }
    }
}