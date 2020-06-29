using System;
using System.Collections.Generic;

namespace Library
{
    public class TransactionTypeHandler : BaseHandler
    {
        public override void Handle(InterpreterMessage m)
        {
            if (m.Type == "propiedad")
            {
                TransactionTypeFilter property = new TransactionTypeFilter(m.Value);

                base.Handle(m);
            }
        }
    }
}