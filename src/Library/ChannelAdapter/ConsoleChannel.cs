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
            Database db = SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id);

            db.SetAdapter(this);

            if (db.State == Status.Init)
            {
                this.SendTextToUser(id, "Bienvenid@! Mi nombre es Pepe, estoy aquí para ayudarte a encontrar la casa de tus sueños." + Environment.NewLine + "Por favor, ingresa 1 para buscar una propiedad en alquiler o 2 para buscar una propiedad a la venta.");

                db.SetState(Status.WaitingTransactionType);
            }

            else
            {
                SingleInstance<SimpleInterpreter>.GetInstance.ParseInput(input, db);
            }
        }

        public void SendTextToUser(long id, string response)
        {
            Console.WriteLine(response);
        }
    }
}