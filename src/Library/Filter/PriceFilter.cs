using System;

namespace Library
{

    public class PriceFilter : IFilter
    {
        /// <summary>
        /// 
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
            string result = string.Empty;
            result += $"{this.MaxPrice},";
            result += $"{this.MinPrice},";
            result += $"{this.ExtendedRange}";

            return result;
        }

        public string CalculateExtendedRange(double min, double max)
        {
            string result = $"{min * 0.8},{max * 1.25}";
            return result;
        }
    }
}