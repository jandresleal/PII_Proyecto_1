
using System.Collections.Generic;

namespace Library
{
    public interface IMediator
    {
        void AddPriceFilter(double min, double max);
        /// <summary>
        /// Estructuramos el código con el patrón de diseño Mediator, con el objetivo de que toda la 
        /// comunicación entre las clases pase por un objeto único llamado mediator, individual para 
        /// cada consulta del usuario. De esta manera buscamos independizar las clases entre sí, para 
        /// poder modificarlas sin alterar el funcionamiento de las demás. Esto nos facilita la implementación
        /// de las diferentes plataformas independientemente del funcionamiento interno del bot.

        /// Buscamos encapsular las clases en grupos de alta cohesión entre sí, para que la complejidad 
        /// de cada tarea sea manejable y por otro lado maximizar la reutilización del código al 
        /// restringir la comunicación entre la clases y forzarla por el Mediator, según el principio 
        /// de Bajo Acoplamiento.
        /// </summary>
        void GetItemsToPrint()
        {
            
        }

        void AddNeighbourhoodFilter(string neighbourhood);

        void AddRoomsFilter(int number);

        void AddBathsFilter(int number);

        void AddHabitableAreaFilter(double area);

        void AddAreaFilter(double area);

        void AddGarageFilter(bool b1);
    
        void AddGardenFilter(bool b1);

        void AddSwimmingPoolFilter(bool b1);

        void AddBarbecueFilter(bool b1);

        void AddGymFilter(bool b1);

        void AddProperty(double price, string neighbourhood, int rooms, int baths, double habitableArea, double area, bool garage, bool garden, bool swimmingPool, bool barbecue, bool gym);

        void Search(IAPIsSearchEngines api);

        void CreateTextToPrint(IPrintFormatter formatter);
    }
}