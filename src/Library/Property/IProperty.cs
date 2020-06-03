namespace Library
{
    public interface IProperty
    {
        double Price { get; }

        string Neighborhood { get; }

        int Rooms { get; }

        int Baths { get; }

        double HabitableArea { get; }

        double Area { get; }

        bool Garage { get; }

        bool Garden { get; }

        bool SwimmingPool { get; }

        bool Barbecue { get; }

        bool Gym { get; }
    }
}