using System;

namespace Library
{
    public class PriceHandler : BaseHandler
    {
        public override void Handle(InterpreterMessage m)
        {
            if (m.Type == "price")
            {
                string[] split = m.Value.Split("-");

                PriceFilter price = new PriceFilter(Int32.Parse(split[1]),Int32.Parse(split[2]));
            }
        }
    }
}