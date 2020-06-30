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
        /// <param name="mediator"></param>
        /// <param name="database"></param>
        public void ParseInput(string input, Database database)
        {
            if (input != string.Empty)
            {
                TransactionTypeHandler transactionTypeHandler = new TransactionTypeHandler();
                PriceHandler priceHandler = new PriceHandler();
                NeighbourhoodHandler neighbourhoodHandler = new NeighbourhoodHandler();
                
                transactionTypeHandler.Next = priceHandler;
                priceHandler.Next = neighbourhoodHandler;

                switch (database.State)
                {
                    case Status.WaitingTransactionType:
                        if(input.Replace(" ", "") == "1")
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage ("propiedad", "alquiler", database.UserID));
                        }
                        else if (input.Replace(" ", "") == "2")
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage ("propiedad", "compra", database.UserID));
                        }
                        else
                        {
                            throw new Exception();
                        }

                        break;

                    case Status.WaitingPrice:
                        StringBuilder sb = new StringBuilder (input);

                        sb.Replace(" ", "");
                        sb.Replace(",", "");
                        sb.Replace(".", "");

                        transactionTypeHandler.Handle(new InterpreterMessage ("precio", sb.ToString(), database.UserID));

                        break;

                    case Status.WaitingNeighbourhood:
                        StringBuilder sb1 = new StringBuilder (input.ToLower());
                        
                        sb1.Replace(",", "");
                        sb1.Replace(".", "");

                        try
                        {
                            transactionTypeHandler.Handle(new InterpreterMessage ("barrio", sb1.ToString(), database.UserID));
                        }
                        catch (Exception e)
                        {
                                Console.WriteLine(e.Message);
                        }

                        break;

                    default:
                        if (database.Adapter == SingleInstance<TelegramBot>.GetInstance)
                        {
                            SingleInstance<TelegramBot>.GetInstance.SendTextToUser(database.UserID, "Aun estamos procesando su búsqueda!");
                        }
                        else if (database.Adapter == SingleInstance<ConsoleChannel>.GetInstance)
                        {
                            SingleInstance<ConsoleChannel>.GetInstance.SendTextToUser(database.UserID, "Aun estamos procesando su búsqueda!");
                        }
                        break;
                }
            }
        }
    }
}
