using System.Collections.Generic;

namespace Library
{
    public enum Status { WaitingTransactionType, WaitingPrice, WaitingNeighbourhood, SearchDone, MoreResults }

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

        public IChannelAdapter Adapter { get; }

        public string UserID { get; }

        public Status State { get; private set; }

        // permite ser configurable la api de búsqueda
        // sirve en el caso de que tengamos más
        // de una implementada
        public IAPIsSearchEngines API { get; private set; }

        public Database(IChannelAdapter adapter, string id)
        {
            this.Adapter = adapter;
            this.UserID = id;
            this.Result = string.Empty;
            this.Filters = new List<IFilter>();
            this.Properties = new List<IProperty>();
            this.State = Status.WaitingTransactionType;
        }

        public void AddFilter (IFilter filter)
        {
            this.Filters.Add(filter);
        }

        public void AddProperty(IProperty property)
        {
            this.Properties.Add(property);
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

        // si tuviéramos más de una integrada
        // podríamos dar la opción de cambiar sitio de búsqueda
        public void SetAPI(IAPIsSearchEngines api)
        {
            this.API = api;
        }

        public void SetState(Status x)
        {
            this.State = x;
        }
    }
}