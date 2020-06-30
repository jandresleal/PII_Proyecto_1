using System.Collections.Generic;

namespace Library
{
    public class DatabaseMap
    {
        private Dictionary<long, Database> Map;

        public DatabaseMap()
        {
            this.Map = new Dictionary<long, Database>();
        }

        public Database GetDatabaseInstance(IChannelAdapter adapter, long ID)
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