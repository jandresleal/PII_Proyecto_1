using System.Collections.Generic;

namespace Library
{
    public class DatabaseMap
    {
        private Dictionary<string, Database> Map;

        public DatabaseMap()
        {
            this.Map = new Dictionary<string, Database>();
        }

        public Database GetDatabaseInstance(IChannelAdapter adapter, string ID)
        {
            Database db;

            if (Map.TryGetValue(ID, out db))
            {
                return db;
            }
            else
            {
                Database database = new Database(adapter, ID);
                Map.Add(ID, database);
                return database;
            }
        } 
    }
}