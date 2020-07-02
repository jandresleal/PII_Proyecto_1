using System.Collections.Generic;

namespace Library
{
    public class DepartmentHandler : BaseHandler
    {
        public override void Handle(InterpreterMessage m)
        {
            List<string> departments = new List<string> { "artigas", "canelones", "cerro largo", "colonia", "durazno", "flores", "florida", "lavalleja", "maldonado", "montevideo", "paysandu", "rio negro", "rivera", "rocha", "salto", "san jose", "soriano", "tacuarembo", "treinta y tres"};

            if (m.MessageType == Type.Department)
            {
                if (departments.Contains(m.Value))
                {
                    SingleInstance<Mediator>.GetInstance.AddFilter(
                    new DepartmentFilter(m.Value),
                    m.ID
                    );
                }
                else
                {
                    throw new InvalidInputException("Por favor, ingrese un departamento válido.");
                }
            }
            base.Handle(m);
        }
    }
}