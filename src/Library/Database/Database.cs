using System.Collections.Generic;

namespace Library
{
    public enum Status { Init, WaitingTransactionType, WaitingDepartment, WaitingNeighbourhood, WaitingPropertyType, Searching, SearchDone, NewSearch }

    public class Database
    {
        /// <summary>
        /// Esta clase es la encargada de almacenar los filtros y las propiedades.
        /// Database conoce con qué API trabajará, el ID del usuario y el adapter al cual corresponde.
        ///
        /// Para cada usario que se comunique con el bot se crea una Database.
        /// 
        /// Se respeta OCP dado que Database no está abierto a la modificación pero sí
        /// a la extensión, se le podrían agregar nuevos componentes.
        /// Las instancias de Database conocen la información de la sesión y la persisten, por lo tanto
        /// le otorgamos esta responsabilidad dado que es la experta en la información, sigue el patron Expert.
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