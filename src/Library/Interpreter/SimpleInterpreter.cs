using System.Diagnostics;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Library
{
    public class SimpleInterpreter : IInterpreter
    {
        public SimpleInterpreter() { }
        /// <summary>
        /// El método ParseInput se encarga de interpretar el texto y generar el Objeto InterpreterMessage
        /// que posteriormente será pasado a los handlers con el fin de generar el filtro correspondiente
        /// En caso de no encontrar ningún filtro le pide al usario otro ingreso mediante Mediator;
        /// una vez ensamblados todos los filtros, llama a Mediator para realizar la búsqueda
        /// 
        /// Conoce el estado de la base de datos y en base a él se encarga de interpretar
        /// información enviada por el usuario
        /// 
        /// Sigue el patrón creator a la hora de instanciar los mensajes y los handlers
        /// Son los objetos necesarios para luego crear los filtros
        /// El interpreter message se envía a la cadena de responsabilidad instanciada por él.
        /// </summary>

        /// <summary>
        /// Parse input, método clave del intérprete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
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

                        if(this.WithoutAccents(input).Replace(" ", "") == "1")
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Transaction, "alquiler", id));
                            
                            SingleInstance<Mediator>.GetInstance.SetState(id, Status.WaitingDepartment);

                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Ingrese el departamento por favor.");
                        }
                        else if (this.WithoutAccents(input).Replace(" ", "") == "2")
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
                            StringBuilder sb = new StringBuilder (this.WithoutAccents(input));

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
                            StringBuilder sb1 = new StringBuilder (this.WithoutAccents(input));
                        
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

                        if(this.WithoutAccents(input).Replace(" ", "") == "1")
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage (Type.Property, "casa", id));
                            
                            SingleInstance<Mediator>.GetInstance.SetState(id, Status.Searching);

                            SingleInstance<Mediator>.GetInstance.Search(id);
                        }
                        else if (this.WithoutAccents(input).Replace(" ", "") == "2")
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

                        string input2 = this.WithoutAccents(input).Replace(" ", "");

                        if (input2 == "1")
                        {
                            SingleInstance<Mediator>.GetInstance.SetState(id, Status.NewSearch);

                            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Por favor, ingresa 1 para buscar una propiedad en alquiler o 2 para buscar una propiedad a la venta.");
                        }
                        else if (input == "chau" | input == "chauu" | input == "nos vemos" | input == "nos vemos!" | input == "muchas gracias!" | input == "muchas gracias" | input == "gracias" | input == "gracias!")
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

        private string WithoutAccents(string input)
        {
            string wordWithoutAccents = Regex.Replace(input.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");

            return wordWithoutAccents;
        }  
    }
}
