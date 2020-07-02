using System.Diagnostics;
using System;
using System.Text;

namespace Library
{
    public class SimpleInterpreter : IInterpreter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SimpleInterpreter() { }
        /// <summary>
        /// El método ParseInput se encarga de interpretar el texto y fijarse si encuentra los diferentes filtros.
        /// En caso de no encontrar ningún filtro le pide al usario otro ingreso mediante Mediator; si encuentra algun filtro llama a Mediator para
        /// realizar la búsqueda
        /// </summary>
        /// <param name="input"> string que recibe por parámetro</param>
        /// <param name="database"></param>
        public void ParseInput(long id, string input)
        {
            try
            {
                if (input == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (System.NullReferenceException e)
            {
                // si detectamos un string null, pedimos que se nos escriba nuevamente
                // no deberían de ingresarse string nulls y por lo tanto sería un bug
                // pero podemos recuperarnos de él

                Debug.WriteLine(e.Message + id);

                SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Por favor, ingrese el texto nuevamente");
            }

            if (input != string.Empty)
            {
                TransactionTypeHandler transactionTypeHandler = new TransactionTypeHandler();
                NeighbourhoodHandler neighbourhoodHandler = new NeighbourhoodHandler();
                PropertyTypeHandler propertyTypeHandler = new PropertyTypeHandler();
                DepartmentHandler departmentHandler = new DepartmentHandler();

                transactionTypeHandler.Next = neighbourhoodHandler;
                neighbourhoodHandler.Next = propertyTypeHandler;
                propertyTypeHandler.Next = departmentHandler;

                switch (SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).State)
                {
                    case Status.Init:

                        SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Bienvenid@! Mi nombre es Pepe, estoy aquí para ayudarte a encontrar la casa de tus sueños." + Environment.NewLine + "Por favor, ingresa 1 para buscar una propiedad en alquiler o 2 para buscar una propiedad a la venta.");

                        SingleInstance<Mediator>.GetInstance.SetState(id, Status.WaitingTransactionType);

                        break;

                    case Status.WaitingTransactionType:

                        if(input.Replace(" ", "") == "1")
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Transaction, "alquiler", id));
                            
                            SingleInstance<Mediator>.GetInstance.SetState(id, Status.WaitingDepartment);

                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Ingrese el departamento por favor.");
                        }
                        else if (input.Replace(" ", "") == "2")
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Transaction, "compra", id));
                        
                            SingleInstance<Mediator>.GetInstance.SetState(id, Status.WaitingDepartment);

                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Ingrese el departamento por favor.");
                        }
                        else
                        {
                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Por favor, ingrese 1 o 2.");
                        }

                        break;

                     case Status.WaitingDepartment:

                        try
                        {
                            StringBuilder sb = new StringBuilder (input);

                            sb.Replace(",", "");
                            sb.Replace(".", "");

                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Department, sb.ToString(), id));

                            if (sb.ToString() == "montevideo")
                            {
                                SingleInstance<Mediator>.GetInstance.SetState(id, Status.WaitingNeighbourhood);

                                SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Ingrese el barrio por favor.");
                            }
                            else
                            {
                                SingleInstance<Mediator>.GetInstance.SetState(id, Status.WaitingPropertyType);

                                SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Ingrese 1 para buscar una casa o ingrese 2 para buscar un apartamento.");
                            }
                        }
                        catch (InvalidInputException e)
                        {  
                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, e.Message);
                        }

                        catch (ArgumentNullException e)
                        {
                            Debug.WriteLine(e.Message + id);

                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Por favor ingrese el departamento nuevamente.");
                        }
                        break;
                    

                    case Status.WaitingNeighbourhood:

                        try
                        {
                            StringBuilder sb1 = new StringBuilder (input.ToLower());
                        
                            sb1.Replace(",", "");
                            sb1.Replace(".", "");

                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Neighbourhood, sb1.ToString(), id));
                        
                            SingleInstance<Mediator>.GetInstance.SetState(id, Status.WaitingPropertyType);

                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Ingrese 1 para buscar una casa o ingrese 2 para buscar un apartamento.");
                        }
                        catch (InvalidInputException e)
                        {  
                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, e.Message);
                        }

                        catch (ArgumentNullException e)
                        {
                            Debug.WriteLine(e.Message + id);

                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Por favor ingrese el barrio nuevamente.");
                        }

                        break;

                    case Status.WaitingPropertyType:

                        if(input.Replace(" ", "") == "1")
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Property, "casa", id));
                            
                            SingleInstance<Mediator>.GetInstance.SetState(id, Status.Searching);

                            SingleInstance<Mediator>.GetInstance.Search(id);
                        }
                        else if (input.Replace(" ", "") == "2")
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Property, "apartamento", id));
                            
                            SingleInstance<Mediator>.GetInstance.SetState(id, Status.Searching);

                            SingleInstance<Mediator>.GetInstance.Search(id);
                        }
                        else
                        {
                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Por favor, ingrese 1 o 2.");
                        }
                        break;

                    case Status.SearchDone:

                        string input2 = input.Replace(" ", "");

                        if (input2 == "1")
                        {
                            SingleInstance<Mediator>.GetInstance.SetState(id, Status.NewSearch);

                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Por favor, ingresa 1 para buscar una propiedad en alquiler o 2 para buscar una propiedad a la venta.");
                        }
                        else if (input2 == "chau" | input2 == "chauu" | input2 == "nos vemos" | input2 == "nos vemos!" | input2 == "muchas gracias!" | input2 == "muchas gracias" | input2 == "gracias" | input2 == "gracias!")
                        {
                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Muchas gracias por la visita!");

                            SingleInstance<Mediator>.GetInstance.SetState(id, Status.Init);
                        }
                        else
                        {
                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Por favor ingrese 1 si desea realizar una nueva búsqueda");
                        }

                        break;

                    default:
                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Aun estamos procesando su búsqueda!");
                        break;
                }
            }
        }

        public void SetState(long id, Status state)
        {
            SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).SetState(state);
        }
    }
}
