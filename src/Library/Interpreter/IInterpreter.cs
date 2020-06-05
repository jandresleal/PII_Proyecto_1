using System.Collections.Generic;
using System;

namespace Library
{
    public interface IInterpreter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="mediator"></param>
        /// <param name="database"></param>
        void ParseInput(string input, IMediator mediator, Database database);
    }
}