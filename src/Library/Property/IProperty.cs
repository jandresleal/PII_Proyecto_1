namespace Library
{
    public interface IProperty
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        int Price { get; }

        string Neighbourhood { get; }

        int Rooms { get; }

        int Baths { get; }

        int HabitableArea { get; }

        int Area { get; }

        bool Garage { get; }

        bool Garden { get; }

        bool SwimmingPool { get; }

        bool Barbecue { get; }

        bool Gym { get; }

        string GetPropertyValues();
    }
}