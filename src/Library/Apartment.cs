namespace Library
{
    public class Apartment : Property
    {
        public bool Gym { get; set; }
        public Apartment(string neighborhood, int rooms, int baths, double habitableArea, double area, bool garage, bool garden, bool swimmingPool, bool barbecue, bool gym) : base(neighborhood, rooms, baths, habitableArea, area, garage, garden, swimmingPool, barbecue)
        {
            this.Gym = gym;
        }
        public override void LoadProperty(string neighborhood, int rooms, int baths, double habitableArea, double area, bool garage, bool garden, bool swimmingPool, bool barbecue, bool gym)
        {

        }
    }
}