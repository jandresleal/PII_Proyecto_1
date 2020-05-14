namespace Library
{

    public class PriceFilter : IFilter
    {

        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }

        public PriceFilter()
        {
            this.MinPrice = 0;
            this.MaxPrice = 0;
        }

        public void SetValues(string data)
        {

        }
    }
}