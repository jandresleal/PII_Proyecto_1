using System.Collections.Generic;

namespace Library
{
    public class Database
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<IFilter> Filters {get; set;}

        public List<IProperty> Properties { get; }

        public string Result { get; private set; }

        public IChannelAdapter Adapter { get; }

        public Database()
        {
            this.Result = string.Empty;
            this.Filters = new List<IFilter>();
            this.Properties = new List<IProperty>();
        }

        public void AddPriceFilter(double min, double max)
        {
            Filters.Add(new PriceFilter(min, max));
        }

        public void AddNeighbourhoodFilter(string neighbourhood)
        {
            Filters.Add(new NeighbourhoodFilter(neighbourhood));
        }

        public void AddRoomsFilter(int number)
        {
            Filters.Add(new RoomsFilter(number));
        }

        public void AddBathsFilter(int number)
        {
            Filters.Add(new BathsFilter(number));
        }

        public void AddHabitableAreaFilter(double area)
        {
            Filters.Add(new HabitableAreaFilter(area));
        }

        public void AddAreaFilter(double area)
        {
            Filters.Add(new AreaFilter(area));
        }

        public void AddGarageFilter(bool b1)
        {
            Filters.Add(new GarageFilter(b1));
        }
    
        public void AddGardenFilter(bool b1)
        {
            Filters.Add(new GardenFilter(b1));
        }

        public void AddSwimmingPoolFilter(bool b1)
        {
            Filters.Add(new SwimmingPoolFilter(b1));
        }

        public void AddBarbecueFilter(bool b1)
        {
            Filters.Add(new BarbecueFilter(b1));
        }

        public void AddGymFilter(bool b1)
        {
            Filters.Add(new GymFilter(b1));
        }

        public void AddProperty(
            double price, 
            string neighbourhood, 
            int rooms, 
            int baths, 
            double habitableArea, 
            double area, 
            bool garage, 
            bool garden, 
            bool swimmingPool, 
            bool barbecue, 
            bool gym)
        {
            Properties.Add(new Property(
                price,
                neighbourhood,
                rooms,
                baths,
                habitableArea,
                area,
                garage,
                garden,
                swimmingPool,
                barbecue,
                gym
            ));
        }

        public void SetResult(string data)
        {
            this.Result = data;
        }

        public string SendResult()
        {
            return Result;
        }

        public List<IProperty> GetPropertyList()
        {
            return Properties;
        }

        public List<IFilter> GetFilters()
        {
            return Filters;
        }
    }
}