using System.Collections.Generic;
using System;

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
                switch (database.State)
                {
                    case Status.WaitingTransactionType:
                        if(input.Replace(" ", "") == "1")
                        {
                            InterpreterMessage message = new InterpreterMessage("propiedad", "alquiler");
                        }
                        else if (input.Replace(" ", "") == "2")
                        {
                            InterpreterMessage message = new InterpreterMessage("propiedad", "compra");
                        }
                        else
                        {
                            throw new Exception();
                        }
                    break;

                    case Status.WaitingPrice:

                    break;

                    case Status.WaitingNeighbourhood:

                    break;

                    case Status.SearchDone:

                    break;

                    case Status.MoreResults:

                    break;
                }

                List<string> neighbourhoods = new List<string> { "aguada", "aires puros", "arroyo seco", "atahualpa", "bañados de carrasco", "barra de carrasco", "barrio sur", "bella italia", "bella vista", "belvedere", "bolivar", "brazo oriental", "buceo", "camino maldonado", "capurro", "capurro bella vista", "carrasco", "carrasco este", "carrasco norte", "casabo", "casabo pajas blancas", "casavalle", "centro", "cerrito", "cerro", "ciudad vieja", "colon", "conciliacion", "cordon", "flor de maronas", "goes", "golf", "ituizango", "jacinto vera", "jardines del hipodromo", "la blanqueada", "la caleta", "la colorada", "la comercial", "la figurita", "la paloma tomkinson", "la teja", "larrañaga", "las acacias", "las canteras", "lezica", "malvín", "malvin norte", "manga", "marconi", "maroñas", "melilla", "mercado modelo", "montevideo", "nuevo paris", "pajas blancas", "palermo", "parque batlle", "parque miramar", "parque rodo", "paso de la arena", "paso molino", "peñarol", "peñarol lavalleja", "perez castellanos", "piedas blancas", "pocitos", "pocitos nuevo", "prado", "prado nueva savona", "puerto", "puerto buceo", "punta carretas", "punta espinillo", "punta gorda", "punta rieles", "reducto", "santiago vazquez", "sayago", "tres cruces", "tres ombues pblo victoria", "union", "villa biarritz", "villa dolores", "villa española", "villa garcia manga rural", "villa muños", "zona rural" };

                TransactionTypeHandler transactionTypeHandler = new TransactionTypeHandler();
                PriceHandler priceHandler = new PriceHandler();
                NeighbourhoodHandler neighbourhoodHandler = new NeighbourhoodHandler();
                
                transactionTypeHandler.Next = priceHandler;
                priceHandler.Next = neighbourhoodHandler;
            }
        }
    }
}
