using System.Collections.Generic;
using System;

namespace Library
{
    public class SimpleInterpreter : Interpreter
    {
        public SimpleInterpreter() : base() {}
        /// <summary>
        /// El método ParseInput se encarga de interpretar el texto y fijarse si encuentra los diferentes filtros.
        /// En caso de no encontrar ningún filtro le pide al usario otro ingreso mediante Mediator; si encuentra algun filtro llama a Mediator para
        /// realizar la búsqueda
        /// </summary>
        /// <param name="input"> string que recibe por parámetro</param>
        /// <param name="mediator"></param>
        /// <param name="database"></param>
        public override void ParseInput(string input, IMediator mediator, Database database)
        {
            string[] entrada = input.ToLower().Split(",");

            List<string> neighbourhoods = new List<string> { "aguada", "aires puros", "arroyo seco", "atahualpa", "bañados de carrasco", "barra de carrasco", "barrio sur", "bella italia", "bella vista", "belvedere", "bolivar", "brazo oriental", "buceo", "camino maldonado", "capurro", "capurro bella vista", "carrasco", "carrasco este", "carrasco norte", "casabo", "casabo pajas blancas", "casavalle", "centro", "cerrito", "cerro", "ciudad vieja", "colon", "conciliacion", "cordon", "flor de maronas", "goes", "golf", "ituizango", "jacinto vera", "jardines del hipodromo", "la blanqueada", "la caleta", "la colorada", "la comercial", "la figurita", "la paloma tomkinson", "la teja", "larrañaga", "las acacias", "las canteras", "lezica", "malvín", "malvin norte", "manga", "marconi", "maroñas", "melilla", "mercado modelo", "montevideo", "nuevo paris", "pajas blancas", "palermo", "parque batlle", "parque miramar", "parque rodo", "paso de la arena", "paso molino", "peñarol", "peñarol lavalleja", "perez castellanos", "piedas blancas", "pocitos", "pocitos nuevo", "prado", "prado nueva savona", "puerto", "puerto buceo", "punta carretas", "punta espinillo", "punta gorda", "punta rieles", "reducto", "santiago vazquez", "sayago", "tres cruces", "tres ombues pblo victoria", "union", "villa biarritz", "villa dolores", "villa española", "villa garcia manga rural", "villa muños", "zona rural" };

            foreach (string x in entrada)
            {
                if (x.Contains("price"))
                {
                    string[] splitted = x.Split("-");
                    mediator.AddPriceFilter(Int32.Parse(splitted[1]),Int32.Parse(splitted[2]),database);
                }

                else if (neighbourhoods.Contains(x))
                {
                    mediator.AddNeighbourhoodFilter(x,database);
                }

                else if (x.Contains("rooms"))
                {
                    string[] splitted = x.Split("-");
                    mediator.AddRoomsFilter(Int32.Parse(splitted[1]),database);
                }
                
                else if (x.Contains("baths"))
                {
                    string[] splitted = x.Split("-");
                    mediator.AddBathsFilter(Int32.Parse(splitted[1]),database);
                }

                else if (x.Contains("habitablearea"))
                {
                    string[] splitted = x.Split("-");
                    mediator.AddHabitableAreaFilter(Int32.Parse(splitted[1]),database);
                }
                
                else if (x.Contains("area"))
                {
                    string[] splitted = x.Split("-");
                    mediator.AddAreaFilter(Int32.Parse(splitted[1]),database);
                }
                
                else if (x.Contains("garage"))
                {
                    mediator.AddGarageFilter(true,database);
                }

                else if (x.Contains("garden"))
                {
                    mediator.AddGardenFilter(true,database);
                }

                else if (x.Contains("swimmingPool"))
                {
                    mediator.AddSwimmingPoolFilter(true,database);
                }
                else if (x.Contains("barbecue"))
                {
                    mediator.AddBarbecueFilter(true,database);
                }
                
                else if (x.Contains("gym"))
                {
                    mediator.AddGymFilter(true,database);
                } 
            }
        }
    }
}