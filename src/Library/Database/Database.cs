using System.Collections.Generic;
using System;
using System.IO;

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

        public string UserID { get; }

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

        public void SetAPI(IAPIsSearchEngines api)
        {
            this.API = api;
        }

        public void SetAdapter(IChannelAdapter adapter)
        {
            this.Adapter = adapter;
        }
        public void SaveFile(Database database, long chatId)
        {
            string ruta = @"C:\RutaArchivos\" + chatId + ".txt";

            //En vez de actualizar el archivo lo elimino y lo creo de nuevo
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }

            //Se crea un txt por cada sesion de chat.
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(ruta))
            {
                //Recorro la lista de filtros de la database y guardo el tipo y el valor de los mismos
                //Cada linea queda de la forma: minimo=15000
                foreach (string filter in database.Filters)
                {
                    file.WriteLine(filter.Type + "=" + filter.Value );
                }
            }
        }
        public Database ReadFile(long chatId)
        {
            string ruta = @"C:\RutaArchivos\" + chatId + ".txt";
            string[] lines = File.ReadAllLines(ruta);
            Database database = new Database();

            foreach (string line in lines)
            {
                string[] filtro = line.Split("=");
                string tipo = filtro[0];
                string valor = filtro[1];
                //Aca tengo que determinar que tipo de filtro es para poder crearlo y agregarlo a la database

                database.Filters.Add(filter);
            }
            return database;

        }  
    }
}