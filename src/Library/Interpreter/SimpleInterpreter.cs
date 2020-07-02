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
        public void ParseInput(string input, Database database)
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

                Debug.WriteLine(e.Message + database.UserID);

                SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(database.UserID, "Por favor, ingrese el texto nuevamente");
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

                switch (database.State)
                {
                    case Status.WaitingTransactionType:

                        if(input.Replace(" ", "") == "1")
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Transaction, "alquiler", database.UserID));
                            
                            database.SetState(Status.WaitingDepartment);

                            database.Adapter.SendTextToUser(database.UserID, "Ingrese el departamento por favor.");
                        }
                        else if (input.Replace(" ", "") == "2")
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Transaction, "compra", database.UserID));
                        
                            database.SetState(Status.WaitingDepartment);

                            database.Adapter.SendTextToUser(database.UserID, "Ingrese el departamento por favor.");
                        }
                        else
                        {
                            database.Adapter.SendTextToUser(database.UserID, "Por favor, ingrese 1 o 2.");
                        }

                        break;

                     case Status.WaitingDepartment:

                        try
                        {
                            StringBuilder sb = new StringBuilder (input);

                            sb.Replace(",", "");
                            sb.Replace(".", "");

                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Department, sb.ToString(), database.UserID));

                            if (sb.ToString() == "montevideo")
                            {
                                database.SetState(Status.WaitingNeighbourhood);

                                database.Adapter.SendTextToUser(database.UserID, "Ingrese el barrio por favor.");
                            }
                            else
                            {
                                database.SetState(Status.WaitingPropertyType);

                                database.Adapter.SendTextToUser(database.UserID, "Ingrese 1 para buscar una casa o ingrese 2 para buscar un apartamento.");
                            }
                        }
                        catch (InvalidInputException e)
                        {  
                            database.Adapter.SendTextToUser(database.UserID, e.Message);
                        }

                        catch (ArgumentNullException e)
                        {
                            Debug.WriteLine(e.Message + database.UserID);

                            database.Adapter.SendTextToUser(database.UserID, "Por favor ingrese el departamento nuevamente.");
                        }
                        break;
                    

                    case Status.WaitingNeighbourhood:

                        try
                        {
                            StringBuilder sb1 = new StringBuilder (input.ToLower());
                        
                            sb1.Replace(",", "");
                            sb1.Replace(".", "");

                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Neighbourhood, sb1.ToString(), database.UserID));
                        
                            database.SetState(Status.WaitingPropertyType);

                            database.Adapter.SendTextToUser(database.UserID, "Ingrese 1 para buscar una casa o ingrese 2 para buscar un apartamento.");
                        }
                        catch (InvalidInputException e)
                        {  
                            database.Adapter.SendTextToUser(database.UserID, e.Message);
                        }

                        catch (ArgumentNullException e)
                        {
                            Debug.WriteLine(e.Message + database.UserID);

                            database.Adapter.SendTextToUser(database.UserID, "Por favor ingrese el barrio nuevamente.");
                        }

                        break;

                    case Status.WaitingPropertyType:

                        if(input.Replace(" ", "") == "1")
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Property, "casa", database.UserID));
                            
                            database.SetState(Status.Searching);

                            SingleInstance<Mediator>.GetInstance.Search(database);
                        }
                        else if (input.Replace(" ", "") == "2")
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Property, "apartamento", database.UserID));
                            
                            database.SetState(Status.Searching);

                            SingleInstance<Mediator>.GetInstance.Search(database);
                        }
                        else
                        {
                            database.Adapter.SendTextToUser(database.UserID, "Por favor, ingrese 1 o 2.");
                        }
                        break;

                    case Status.SearchDone:

                        string input2 = input.Replace(" ", "");

                        if (input2 == "1")
                        {
                            database.SetState(Status.NewSearch);

                            database.Adapter.SendTextToUser(database.UserID, "Por favor, ingresa 1 para buscar una propiedad en alquiler o 2 para buscar una propiedad a la venta.");
                        }
                        else if (input2 == "chau" | input2 == "chauu" | input2 == "nos vemos" | input2 == "nos vemos!" | input2 == "muchas gracias!" | input2 == "muchas gracias" | input2 == "gracias" | input2 == "gracias!")
                        {
                            database.Adapter.SendTextToUser(database.UserID, "Muchas gracias por la visita!");

                            database.SetState(Status.Init);
                        }
                        else
                        {
                            database.Adapter.SendTextToUser(database.UserID, "Por favor ingrese 1 si desea realizar una nueva búsqueda");
                        }

                        break;

                    default:
                            database.Adapter.SendTextToUser(database.UserID, "Aun estamos procesando su búsqueda!");
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
