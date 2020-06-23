namespace Library
{
    public class Mediator : IMediator
    {
        /// <summary>
        /// Es la clase encargada de implementar el Mediator
        /// Explicamos las razones de su uso en la interfaz IMediator
        /// </summary>
        /// <param name=></param>
        public Mediator() {  }

        public void AddPriceFilter(int min, int max, Database database)
        {
            database.AddPriceFilter(min, max);
        }

        public void AddNeighbourhoodFilter(string neighbourhood, Database database)
        {
            database.AddNeighbourhoodFilter(neighbourhood);
        }

        public void AddRoomsFilter(int number, Database database)
        {
            database.AddRoomsFilter(number);
        }

        public void AddBathsFilter(int number, Database database)
        {
            database.AddBathsFilter(number);
        }

        public void AddHabitableAreaFilter(int area, Database database)
        {
            database.AddHabitableAreaFilter(area);
        }

        public void AddAreaFilter(int area, Database database)
        {
            database.AddAreaFilter(area);
        }

        public void AddGarageFilter(bool b1, Database database)
        {
            database.AddGarageFilter(b1);
        }
    
        public void AddGardenFilter(bool b1, Database database)
        {
            database.AddGardenFilter(b1);
        }

        public void AddSwimmingPoolFilter(bool b1, Database database)
        {
            database.AddSwimmingPoolFilter(b1);
        }

        public void AddBarbecueFilter(bool b1, Database database)
        {
            database.AddBarbecueFilter(b1);
        }

        public void AddGymFilter(bool b1, Database database)
        {
            database.AddGymFilter(b1);
        }

        public void AddProperty(
            int price, 
            string neighbourhood, 
            int rooms, int baths, 
            int habitableArea, 
            int area, 
            bool garage, 
            bool garden, 
            bool swimmingPool, 
            bool barbecue, 
            bool gym,
            Database database)
        {
            database.AddProperty(price, neighbourhood, rooms, baths, habitableArea, area, garage, garden, swimmingPool, barbecue, gym);
        }

        public void Search(Database database)
        {
            database.API.Parse(database.API.AskAPI(database.GetFilters()), this, database);
        }

        public void CreateTextToPrint(IPrintFormatter formatter, Database database)
        {
            database.SetResult(formatter.FormatMessage(database.GetPropertyList()));
        }

        public void SendInfoToAdapter(Database database)
        {
            database.Adapter.SendTextToUser(database.SendResult());
        }

        public void SendInfoToAdapter(string question, Database database)
        {
            database.Adapter.SendTextToUser(question);
        }
    }
}