using System;

namespace Library
{
    public class PriceHandler : BaseHandler
    {
        public override void Handle(InterpreterMessage m)
        {
            if (m.Type == "precio")
            {
                int number;

                if (Int32.TryParse(m.Value, out number))
                {
                    SingleInstance<Mediator>.GetInstance.AddFilter(new PriceFilter(m.Value), SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(m.ID));
                }
                else
                {
                    throw new Exception();
                }    
            }

            base.Handle(m);
        }
    }
}