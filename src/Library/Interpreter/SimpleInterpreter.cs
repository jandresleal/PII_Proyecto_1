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

        public override List<IFilter> ParseInput(string input)
        {
            string[] entrada = input.Split(",");

            IList<string> neighbourhoods = new List<string> { "aguada", "aires puros", "arroyo seco", "atahualpa", "bañados de carrasco", "barra de carrasco", "barrio sur", "bella italia", "bella vista", "belvedere", "bolivar", "brazo oriental", "buceo", "camino maldonado", "capurro", "capurro bella vista", "carrasco", "carrasco este", "carrasco norte", "casabo", "casabo pajas blancas", "casavalle", "centro", "cerrito", "cerro", "ciudad vieja", "colon", "conciliacion", "cordon", "flor de maronas", "goes", "golf", "ituizango", "jacinto vera", "jardines del hipodromo", "la blanqueada", "la caleta", "la colorada", "la comercial", "la figurita", "la paloma tomkinson", "la teja", "larrañaga", "las acacias", "las canteras", "lezica", "malvín", "malvin norte", "manga", "marconi", "maroñas", "melilla", "mercado modelo", "montevideo", "nuevo paris", "pajas blancas", "palermo", "parque batlle", "parque miramar", "parque rodo", "paso de la arena", "paso molino", "peñarol", "peñarol lavalleja", "perez castellanos", "piedas blancas", "pocitos", "pocitos nuevo", "prado", "prado nueva savona", "puerto", "puerto buceo", "punta carretas", "punta espinillo", "punta gorda", "punta rieles", "reducto", "santiago vazquez", "sayago", "tres cruces", "tres ombues pblo victoria", "union", "villa biarritz", "villa dolores", "villa española", "villa garcia manga rural", "villa muños", "zona rural" };
                
            foreach (string x in entrada)
            {
                if (x.Contains("Price"))
                {
                    string[] splitted = x.Split("-");
                    Filters.Add(new PriceFilter(Int32.Parse(splitted[1]),Int32.Parse(splitted[2])));
                }

                else if (neighbourhoods.Contains(x))
                {
                    Filters.Add(new NeighbourhoodFilter (x));
                }

                else if (x.Contains("Rooms"))
                {
                    string[] splitted = x.Split("-");
                    Filters.Add(new RoomsFilter(splitted[1]));
                }
                
                else if (x.Contains("Baths"))
                {
                    string[] splitted = x.Split("-");
                    Filters.Add(new BathsFilter(splitted[1]));
                }

                else if (x.Contains("HabitableArea"))
                {
                    string[] splitted = x.Split("-");
                    Filters.Add(new HabitableAreaFilter(splitted[1]));
                }
                
                else if (x.Contains("Area"))
                {
                    string[] splitted = x.Split("-");
                    Filters.Add(new AreaFilter(splitted[1]));
                }
                
                else if (x.Contains("Garage"))
                {
                    Filters.Add(new GarageFilter(x));
                }

                else if (x.Contains("Garden"))
                {
                    Filters.Add(new GardenFilter(x));
                }

                else if (x.Contains("SwimmingPool"))
                {
                    Filters.Add(new SwimmingPoolFilter(x));
                }
                else if (x.Contains("Barbecue"))
                {
                    Filters.Add(new BarbecueFilter(x));
                }
                
                else if (x.Contains("Gym"))
                {
                    Filters.Add(new GymFilter(x));
                } 
            }
            return Filters;
        }
        public override List<IFilter> CreateExtendedList(string input)
        {
            
        }
    }
}