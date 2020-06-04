using System.Collections.Generic;

namespace Library
{
    public class Mediator : IMediator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adapter"></param>
        public Mediator()
        {
            this.database = new Database();
        }

        private Database database { get; }

        public void AddPriceFilter(double min, double max)
        {
            database.AddPriceFilter(min, max);
        }

        public void AddNeighbourhoodFilter(string neighbourhood)
        {
            database.AddNeighbourhoodFilter(neighbourhood);
        }

        public void AddRoomsFilter(int number)
        {
            database.AddRoomsFilter(number);
        }

        public void AddBathsFilter(int number)
        {
            database.AddBathsFilter(number);
        }

        public void AddHabitableAreaFilter(double area)
        {
            database.AddHabitableAreaFilter(area);
        }

        public void AddAreaFilter(double area)
        {
            database.AddAreaFilter(area);
        }

        public void AddGarageFilter(bool b1)
        {
            database.AddGarageFilter(b1);
        }
    
        public void AddGardenFilter(bool b1)
        {
            database.AddGardenFilter(b1);
        }

        public void AddSwimmingPoolFilter(bool b1)
        {
            database.AddSwimmingPoolFilter(b1);
        }

        public void AddBarbecueFilter(bool b1)
        {
            database.AddBarbecueFilter(b1);
        }

        public void AddGymFilter(bool b1)
        {
            database.AddGymFilter(b1);
        }

        public void AddProperty(
            double price, 
            string neighbourhood, 
            int rooms, int baths, 
            double habitableArea, 
            double area, 
            bool garage, 
            bool garden, 
            bool swimmingPool, 
            bool barbecue, 
            bool gym)
        {
            database.AddProperty(price, neighbourhood, rooms, baths, habitableArea, area, garage, garden, swimmingPool, barbecue, gym);
        }

        public void Search(IAPIsSearchEngines api)
        {
            api.AskAPI(database.GetFilters());
        }

        public void CreateTextToPrint(IPrintFormatter formatter)
        {
            database.SetResult(formatter.FormatMessage(database.GetPropertyList()));
        }

        public void SendInfoToAdapter()
        {
            database.Adapter.SendTextToUser(database.SendResult());
        }

        public void SendInfoToAdapter(string question)
        {
            database.Adapter.SendTextToUser(question);
        }
    }
}