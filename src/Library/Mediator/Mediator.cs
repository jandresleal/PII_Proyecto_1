using System.Collections.Generic;
using Library.ApiSearchEngine;

namespace Library
{
    public class Mediator : IMediator
    {
        public Mediator(IChannelAdapter adapter)
        {
            this.database = new Database(adapter);
        }

        private Database database { get; }

        public void AddPriceFilter(double min, double max)
        {
            database.AddPriceFilter(min, max);
        }

        public void AddNeighbourhoodFilter(string neighbourhood)
        {
            database.AddNeighbourhoodFilter(neighbourhood));
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

        public virtual void GetItemsToPrint()
        {
            
        }

        public string Search(IAPIsSearchEngines api)
        {
            return IAPIsSearchEngines.AskAPI(database.Filters);
        }

        public void CreatePropertyList(IAPIsSearchEngines api)
        {
            database.ExtendedProperties = api.Parse(Search(api));
        }
        public void CreateExtendedPropertyList(string data)
        {
            database.ExtendedProperties = 
        }

        public void CreateTextToPrint(IPrintFormatter formatter)
        {
            database.Result = formatter.FormatMessage(database.Properties);
        }

        public void SendInfoToAdapter()
        {
            database.Adapter.SendTextToUser(database.Result);
        }

        public void SendInfoToAdapter(string question)
        {
            database.Adapter.SendTextToUser(question);
        }
    }
}