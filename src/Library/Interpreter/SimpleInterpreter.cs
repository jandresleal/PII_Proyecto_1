using System.Collections.Generic;
using System;

namespace Library
{
    public class SimpleInterpreter : Interpreter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SimpleInterpreter() : base() {}
        /// <summary>
        /// El método ParseInput se encarga de interpretar el texto y fijarse si encuentra los diferentes filtros.
        /// En caso de no encontrar ningún filtro le pide al usario otro ingreso mediante Mediator; si encuentra algun filtro llama a Mediator para
        /// realizar la búsqueda
        /// </summary>
        /// <param name="input"> string que recibe por parámetro</param>
        /// <param name="mediator"></param>
        /// <param name="database"></param>
        public override Database ParseInput(string input)
        {
            //IMediator mediator;
            string[] entrada = input.ToLower().Split(",");
            double idUsuario;
            
            try
            {
                // En caso de que el usuario venga en la posicion 0 del string ej "123,aires puros, 300"
                idUsuario = double.Parse(entrada[0]);
            }
            catch (Exception)
            {
                //Se tiene que devolver algo para indicar que hay un error
                throw;
            }

            Database database = new Database(idUsuario);
            List<string> neighbourhoods = new List<string> { "aguada", "aires puros", "arroyo seco", "atahualpa", "bañados de carrasco", "barra de carrasco", "barrio sur", "bella italia", "bella vista", "belvedere", "bolivar", "brazo oriental", "buceo", "camino maldonado", "capurro", "capurro bella vista", "carrasco", "carrasco este", "carrasco norte", "casabo", "casabo pajas blancas", "casavalle", "centro", "cerrito", "cerro", "ciudad vieja", "colon", "conciliacion", "cordon", "flor de maronas", "goes", "golf", "ituizango", "jacinto vera", "jardines del hipodromo", "la blanqueada", "la caleta", "la colorada", "la comercial", "la figurita", "la paloma tomkinson", "la teja", "larrañaga", "las acacias", "las canteras", "lezica", "malvín", "malvin norte", "manga", "marconi", "maroñas", "melilla", "mercado modelo", "montevideo", "nuevo paris", "pajas blancas", "palermo", "parque batlle", "parque miramar", "parque rodo", "paso de la arena", "paso molino", "peñarol", "peñarol lavalleja", "perez castellanos", "piedas blancas", "pocitos", "pocitos nuevo", "prado", "prado nueva savona", "puerto", "puerto buceo", "punta carretas", "punta espinillo", "punta gorda", "punta rieles", "reducto", "santiago vazquez", "sayago", "tres cruces", "tres ombues pblo victoria", "union", "villa biarritz", "villa dolores", "villa española", "villa garcia manga rural", "villa muños", "zona rural" };

            foreach (string x in entrada)
            {
                if (x.Contains("price"))
                {
                    string[] splitted = x.Split("-");
                    //mediator.AddPriceFilter(Int32.Parse(splitted[1]),Int32.Parse(splitted[1])),database);
                    database.Filters.Add(new PriceFilter(Int32.Parse(splitted[1]), Int32.Parse(splitted[1])));
                }

                else if (neighbourhoods.Contains(x))
                {
                    database.Filters.Add(new NeighbourhoodFilter(x));
                    //mediator.AddNeighbourhoodFilter(x,database);
                }

                else if (x.Contains("rooms"))
                {
                    string[] splitted = x.Split("-");
                    database.Filters.Add(new RoomsFilter(Int32.Parse(splitted[1])));
                    //mediator.AddRoomsFilter(Int32.Parse(splitted[1]),database);
                }
                
                else if (x.Contains("baths"))
                {
                    string[] splitted = x.Split("-");
                    database.Filters.Add(new BathsFilter(Int32.Parse(splitted[1])));
                    //mediator.AddBathsFilter(Int32.Parse(splitted[1]),database);
                }

                else if (x.Contains("habitablearea"))
                {
                    string[] splitted = x.Split("-");
                    database.Filters.Add(new HabitableAreaFilter(Int32.Parse(splitted[1])));
                    //mediator.AddHabitableAreaFilter(Int32.Parse(splitted[1]),database);
                }
                
                else if (x.Contains("area"))
                {
                    string[] splitted = x.Split("-");
                    database.Filters.Add(new AreaFilter(Int32.Parse(splitted[1])));
                    //mediator.AddAreaFilter(Int32.Parse(splitted[1]),database);
                }
                
                else if (x.Contains("garage"))
                {
                    database.Filters.Add(new GarageFilter(true));
                    //mediator.AddGarageFilter(true,database);
                }

                else if (x.Contains("garden"))
                {
                    database.Filters.Add(new GarageFilter(true));
                    //mediator.AddGardenFilter(true,database);
                }

                else if (x.Contains("swimmingPool"))
                {
                    database.Filters.Add(new SwimmingPoolFilter(true));
                    //mediator.AddSwimmingPoolFilter(true,database);
                }
                else if (x.Contains("barbecue"))
                {
                    database.Filters.Add(new BarbecueFilter(true));
                    //mediator.AddBarbecueFilter(true,database);
                }
                
                else if (x.Contains("gym"))
                {
                    database.Filters.Add(new GymFilter(true));
                    //mediator.AddGymFilter(true,database);
                } 
            }

            return database;
        }
    }
}