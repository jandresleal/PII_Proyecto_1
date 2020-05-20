namespace Library
{
    public interface IProperty
    {
        string Neighborhood { get; set; }
        int Rooms { get; set; }
        int Baths { get; set; }
        double HabitableArea { get; set; }
        double Area { get; set; }
        bool Garage { get; set; }
        bool Garden { get; set; }
        bool SwimmingPool { get; set; }
        bool Barbecue { get; set; }
    }
}