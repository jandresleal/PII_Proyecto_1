using System.Collections.Generic;
using System;

namespace Library
{
    public interface IInterpreter
    {
        /// <summary>
        /// Se implementan un método polimórfico - ParseInput
        /// que será sobrescribile por las clases que heredan para darle 
        /// flexibilidad al entorno y permitir la futura extensión a diferentes
        /// plataformas. Se utiliza el patrón polymorphism y se apunta a que se
        /// respete LSP con una implementación dónde no haya interferencia.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="mediator"></param>
        /// <param name="database"></param>
        void ParseInput(string input, IMediator mediator, Database database);
    }
}