using System;

namespace Library
{
    public class InvalidInputException : ArgumentException
    {
        // esta excepción es utilizada para enviar un mensaje obligatoriamente
        // y custom de cuando un valor no es acorde a las posibilidades que manejan
        // los handlers
        public InvalidInputException (string message) : base (message) {}
    }
}