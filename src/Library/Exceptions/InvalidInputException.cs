using System;

namespace Library
{
    public class InvalidInputException : ArgumentException
    {
        /// <summary>
        /// Esta excepción es utilizada para enviar un mensaje obligatoriamente 
        /// y custom de cuando un valor no es acorde a las posibilidades que manejan los handlers
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public InvalidInputException (string message) : base (message) {}
    }
}