using System.Collections.Generic;

namespace Library
{
    public class Database
    {
        public List<IFilter> Filters { get; }

        public List<IProperty> Properties { get; }

        public List<IProperty> ExtendedProperties { get; }

        public string Result { get; }

        public IChannelAdapter Adapter { get; }

        public Database(IChannelAdapter adapter)
        {
            this.Result = string.Empty;
            this.Filters = new List<IFilter>();
            this.Properties = new List<IProperty>();
            this.ExtendedProperties = new List<IProperty>();
            this.Adapter = adapter;
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
    }
}