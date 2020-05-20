namespace Library
{
    public class House : Property
    {
       public House(string neighborhood, int rooms, int baths, double habitableArea, double area, bool garage, bool garden, bool swimmingPool, bool barbecue) : base(neighborhood, rooms, baths, habitableArea, area, garage, garden, swimmingPool, barbecue)
       {

       } 
    }
}