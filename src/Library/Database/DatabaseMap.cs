using System.Collections.Generic;

namespace Library
{
    public class DatabaseMap
    {
        /// <summary>
        /// Esta clase se encarga de crear un diccionario y guardar la Database en el.
        /// TKey utiliza el ID del usuario para poder identificar la Database dado a que este valor es único, 
        /// y TValue guarda la Database correspondiente.
        ///  
        /// Si existe una instancia del diccionario(en este caso Map), con el ID de usuario como TKey, lo devuelve, 
        /// sino crea una Database, la agrega al diccionario y finalmente lo devuelve.
        /// Dicho esto último, al tener la capacidad y responsabilidad de instanciar una Database, 
        /// podemos afirmar que utiliza el patron Creator.
        /// 
        /// A DatabaseMap siempre que se la llama se utiliza SingleInstance y esto provoca que tengamos una única instancia 
        /// de DatabaseMap corriendo, por lo tanto, sigue el patron Singleton.
        /// </summary>
        private Dictionary<long, Database> Map;

        public DatabaseMap()
        {
            this.Map = new Dictionary<long, Database>();
        }

        public Database GetDatabaseInstance(long ID)
        {
            Database db;

            if (Map.TryGetValue(ID, out db))
            {
                return db;
            }
            else
            {
                Database database = new Database(ID);
                Map.Add(ID, database);
                return database;
            }
        } 
    }
}