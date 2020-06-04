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
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public string ExtendedRange { get; }

        public PriceFilter(double minPrice, double maxPrice)
        {
            this.MinPrice = minPrice;
            this.MaxPrice = maxPrice;
            this.ExtendedRange = this.CalculateExtendedRange(minPrice,maxPrice);
        }

        public string GetValues()
        {
            string result = $"{this.MaxPrice},";
            result += $"{this.MinPrice},";
            
            return result;
        }

        public string GetExtendedRangeValue()
        {
            string result = $"{this.ExtendedRange}";
            return result;
        }

        public string CalculateExtendedRange(double min, double max)
        {
            string result = $"{min * 0.8},{max * 1.25}";
            return result;
        }
    }
}