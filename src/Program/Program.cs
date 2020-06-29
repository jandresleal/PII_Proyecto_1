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
            TelegramBot telegram = new TelegramBot();
            
            telegram.StartBot();
        }
    }
}
