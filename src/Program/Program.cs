using System;
using Library;

namespace Program
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SingleInstance<TelegramBot>.GetInstance.Run();

            SingleInstance<ConsoleChannel>.GetInstance.Run();
        }
    }
}
