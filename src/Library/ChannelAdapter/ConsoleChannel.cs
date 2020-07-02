using System;

namespace Library
{
    public class ConsoleChannel : IChannelAdapter
    {
        public void Run()
        {
            while (true)
            {
                this.ReadUserInput(1, Console.ReadLine());
            }
        }

        public void ReadUserInput(long id, string input)
        {
            SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id);

            SingleInstance<Mediator>.GetInstance.SetAdapter(id, this);

            SingleInstance<Mediator>.GetInstance.ToInterpreter(id, input);
        }

        public void SendTextToUser(long id, string response)
        {
            Console.WriteLine(response);
        }
    }
}