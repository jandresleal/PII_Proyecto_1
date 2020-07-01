using System.Collections.Generic;

namespace Library
{
    public class DepartmentHandler : BaseHandler
    {
        public override void Handle(InterpreterMessage m)
        {
            List<string> departments = new List<string> { "artigas", "canelones", "cerro largo", "colonia", "durazno", "flores", "florida", "internacional", "lavalleja", "maldonado", "montevideo", "paysandu", "rio negro", "rivera", "rocha", "salto", "san jose", "soriano", "tacuarembo", "treinta y tres"};

            if (m.MessageType == Type.Department)
            {
                SingleInstance<Mediator>.GetInstance.AddFilter(
                    new DepartmentFilter(m.Value),
                    SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(m.ID)
                );
            }

            base.Handle(m);
        }
    }
}