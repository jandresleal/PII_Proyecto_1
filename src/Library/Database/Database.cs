using System.Collections.Generic;

namespace Library
{
    public enum Status { Init, WaitingTransactionType, WaitingDepartment, WaitingNeighbourhood, WaitingPropertyType, Searching, SearchDone, NewSearch }

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
        public List<IFilter> Filters { get; }

        public List<IProperty> Properties { get; }

        public IChannelAdapter Adapter { get; private set; }

        public long UserID { get; }

        public Status State { get; private set; }

        // permite ser configurable la api de búsqueda
        // sirve en el caso de que tengamos más
        // de una implementada
        public IAPIsSearchEngines API { get; private set; }

        public Database(long id)
        {
            this.UserID = id;
            this.Filters = new List<IFilter>();
            this.Properties = new List<IProperty>();
            this.State = Status.Init;
            this.API = SingleInstance<APIInfoCasas>.GetInstance;
        }

        public void AddFilter (IFilter filter)
        {
            this.Filters.Add(filter);
        }

        public void AddProperty(IProperty property)
        {
            this.Properties.Add(property);
        }

        public List<IProperty> GetPropertyList()
        {
            return Properties;
        }

        public List<IFilter> GetFilters()
        {
            return Filters;
        }

        // si tuviéramos más de una integrada
        // podríamos dar la opción de cambiar sitio de búsqueda
        public void SetAPI(IAPIsSearchEngines api)
        {
            this.API = api;
        }

        public void SetState(Status x)
        {
            if (x == Status.NewSearch)
            {
                this.State = Status.WaitingTransactionType;

                this.Properties.Clear();
            }
            else
            {
                this.State = x;
            }  
        }

        public void SetAdapter(IChannelAdapter adapter)
        {
            this.Adapter = adapter;
        }
    }
}