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
        public List<IFilter> Filters { get; set;}
        
        public double IdUsuario { get; set; }

        public List<IProperty> Properties { get; }

        public string Result { get; private set; }

        //public IChannelAdapter Adapter { get; private set; }

        //public IAPIsSearchEngines API { get; private set; }

        public Database(double idUsuario)
        {
            this.IdUsuario = idUsuario;
            this.Result = string.Empty;
            this.Filters = new List<IFilter>();
            this.Properties = new List<IProperty>();
        }

        // Metodo para guardar la database
        // Recorro una lista de database, en caso de que no exista la creo y la guardo en una lista para poder tenerla a futuro 
        public static void SaveDatabase(Database database)
        {         
            //Metodo para simular el guardado de la database. No se tiene q crear una nueva lista sino obtener la ya creada.
            List<Database> databaseList = new List<Database>();
            databaseList.Add(database);
        }

        
    }
}