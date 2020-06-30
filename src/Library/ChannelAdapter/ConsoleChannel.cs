using System;

namespace Library
{
    public class ConsoleChannel : IChannelAdapter
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("corriendo");
                this.ReadUserInput(1, Console.ReadLine());
            }
        }

        public void ReadUserInput(long id, string input)
        {
            Database db = SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id);

            db.SetAdapter(this);

            SingleInstance<SimpleInterpreter>.GetInstance.ParseInput(input, db);
        }

        public void SendTextToUser(long id, string response)
        {
            Console.WriteLine(response);
        }
    }
}