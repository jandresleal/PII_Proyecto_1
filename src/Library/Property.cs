namespace Library
{
    public abstract class Property : IProperty
    {
        public string Neighborhood { get; set; }
        public int Rooms { get; set; }
        public int Baths { get; set; }
        public double HabitableArea { get; set; }
        public double Area { get; set; }
        public bool Garage { get; set; }
        public bool Garden { get; set; }
        public bool SwimmingPool { get; set; }
        public bool Barbecue { get; set; }
        protected Property(string neighborhood, int rooms, int baths, double habitableArea, double area, bool garage, bool garden, bool swimmingPool, bool barbecue)
        {
            this.Neighborhood = neighborhood;
            this.Rooms = rooms;
            this.Baths = baths;
            this.HabitableArea = habitableArea;
            this.Area = area;
            this.Garage = garage;
            this.Garden = garden;
            this.SwimmingPool = swimmingPool;
            this.Barbecue = barbecue;
        }
        public virtual void LoadProperty( string neighborhood, int rooms, int baths, double habitableArea, double area, bool garage, bool garden, bool swimmingPool, bool barbecue)
        {

        }

    }
}