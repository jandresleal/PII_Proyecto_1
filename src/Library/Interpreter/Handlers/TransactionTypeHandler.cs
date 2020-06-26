using System;
using System.Collections.Generic;

namespace Library
{
    public class TransactionTypeHandler : BaseHandler
    {
        public override void Handle(Message m)
        {
            if (m.Type == "propiedad")
            {
                TransactionTypeFilter property = new TransactionTypeFilter(m.Value);

                base.Handle(m);
            }
        }
    }
}