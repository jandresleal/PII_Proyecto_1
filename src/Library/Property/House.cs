using System;
using System.Collections.Generic;

namespace ProyectoBot
{
    public class House : Property
    {
       public House(string neighborhood, int rooms, int baths, double habitableArea, double area, bool garage, bool garden, bool swimmingPool, bool barbecue) : base(neighborhood, rooms, baths, habitableArea, area, garage, garden, swimmingPool, barbecue)
       {

       } 
       public override void LoadProperty(string neighborhood, int rooms, int baths, double habitableArea, double area, bool garage, bool garden, bool swimmingPool, bool barbecue)
       {
           
       }
    }
}