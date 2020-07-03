using System;

namespace Library
{
    public class ConsoleChannel : IChannelAdapter
    {
        /// <summary>
        /// Esta clase representa al bot de la consola, se encarga de ejecutar el bot. 
        /// 
        /// Tiene dos responsabilidades, por un lado leer de consola las entradas del usuario y por otro, 
        /// brindar la respuesta del core del bot por consola.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                this.ReadUserInput(1, Console.ReadLine());
            }
        }

        /// <summary>
        /// Pasa la entrada al core del sistema
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
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