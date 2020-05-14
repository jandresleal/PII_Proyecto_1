using System;

namespace Library
{

    public class PriceFilter : IFilter
    {

        public double MinPrice {get; set; }
        public double MaxPrice {get; set; }

        public void CreteFilter()
        {
            
        }
    }
}