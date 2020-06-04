/*


*/

using System.Collections.Generic;

namespace Library
{

    public abstract class Interpreter : IInterpreter
    {
        public Interpreter(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected IMediator mediator;

        public abstract void ParseInput(string input);
    }
}