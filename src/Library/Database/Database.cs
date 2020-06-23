using System.Collections.Generic;

namespace Library
{
    public class Database
    {
        /// <summary>
        /// Esta clase es la encargada de almacenar y crear todos los filtros y propiedades.
        /// También es la encargada de guardar un texto que es el que se irá modificando con el
        /// fin de culminar entregando el resultado final al usuario.
        /// Esta clase también conoce con qué API trabajará y de cuál adapter fue llamada, con el fin
        /// de saber dónde buscar una vez ensamblados los filtros y también saber responderle al usuario,
        /// es decir, saber ubicarlo.
        /// 
        /// Database almacena las listas de filtros y propiedades. Al tener esa responsabilidad y
        /// conocerlos, también creemos que tiene la capacidad y responsabilidad de instanciarlos
        /// De esta forma, aplicamos el patrón Creator, los métodos de database para la creación
        /// de filtros y propiedades, reciben todos los argumentos necesarios para su ensamblado.
        /// Se respeta OCP dado que Database no está abierto a la modificación pero sí
        /// a la extensión, se le podrían agregar nuvos componentes.  
        /// </summary>
        /// <value></value>
        public List<IFilter> Filters {get; private set; }

        public List<IProperty> Properties { get; private set; }

        public string Result { get; private set; }

        public IChannelAdapter Adapter { get; private set; }

        public IAPIsSearchEngines API { get; private set; }

        public Database()
        {
            this.Result = string.Empty;
            this.Filters = new List<IFilter>();
            this.Properties = new List<IProperty>();
        }

        public void AddPriceFilter(int min, int max)
        {
            Filters.Add(new PriceFilter(min, max));
        }

        public void AddNeighbourhoodFilter(string neighbourhood)
        {
            Filters.Add(new NeighbourhoodFilter(neighbourhood));
        }

        public void AddRoomsFilter(int number)
        {
            Filters.Add(new RoomsFilter(number));
        }

        public void AddBathsFilter(int number)
        {
            Filters.Add(new BathsFilter(number));
        }

        public void AddHabitableAreaFilter(int area)
        {
            Filters.Add(new HabitableAreaFilter(area));
        }

        public void AddAreaFilter(int area)
        {
            Filters.Add(new AreaFilter(area));
        }

        public void AddGarageFilter(bool b1)
        {
            Filters.Add(new GarageFilter(b1));
        }
    
        public void AddGardenFilter(bool b1)
        {
            Filters.Add(new GardenFilter(b1));
        }

        public void AddSwimmingPoolFilter(bool b1)
        {
            Filters.Add(new SwimmingPoolFilter(b1));
        }

        public void AddBarbecueFilter(bool b1)
        {
            Filters.Add(new BarbecueFilter(b1));
        }

        public void AddGymFilter(bool b1)
        {
            Filters.Add(new GymFilter(b1));
        }

        public void AddProperty(
            int price, 
            string neighbourhood, 
            int rooms, 
            int baths, 
            int habitableArea, 
            int area, 
            bool garage, 
            bool garden, 
            bool swimmingPool, 
            bool barbecue, 
            bool gym)
        {
            Properties.Add(new Property(
                price,
                neighbourhood,
                rooms,
                baths,
                habitableArea,
                area,
                garage,
                garden,
                swimmingPool,
                barbecue,
                gym
            ));
        }

        public void SetResult(string data)
        {
            this.Result = data;
        }

        public string SendResult()
        {
            return Result;
        }

        public List<IProperty> GetPropertyList()
        {
            return Properties;
        }

        public List<IFilter> GetFilters()
        {
            return Filters;
        }

        public void SetAPI(IAPIsSearchEngines api)
        {
            this.API = api;
        }

        public void SetAdapter(IChannelAdapter adapter)
        {
            this.Adapter = adapter;
        }
    }
}