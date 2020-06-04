/*


*/

using System.Collections.Generic;

namespace Library
{

    public abstract class Interpreter : IInterpreter
    {
        public Interpreter() {  }

        public abstract void ParseInput(string input, IMediator mediator, Database database);
    }
}