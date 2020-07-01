using System.Collections.Generic;
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
                            // throw new Exception();
                        }

                        break;

                     case Status.WaitingDepartment:

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

                        break;
                    

                    case Status.WaitingNeighbourhood:

                        StringBuilder sb1 = new StringBuilder (input.ToLower());
                        
                        sb1.Replace(",", "");
                        sb1.Replace(".", "");

                        try
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Neighbourhood, sb1.ToString(), database.UserID));
                        
                            database.SetState(Status.WaitingPropertyType);

                            database.Adapter.SendTextToUser(database.UserID, "Ingrese 1 para buscar una casa o ingrese 2 para buscar un apartamento.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
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
                            throw new Exception();
                        }
                        break;

                    default:
                            database.Adapter.SendTextToUser(database.UserID, "Aun estamos procesando su búsqueda!");
                        break;
                }
            }
        }
    }
}
