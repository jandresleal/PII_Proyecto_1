using System.Collections.Generic;
using System;

namespace Library
{

    public class SimpleInterpreter : Interpreter
    {
        public SimpleInterpreter(Mediator mediator) : base(mediator) {}

        public override void ParseInput(string input)
        {
            string[] entrada = input.Split(",");

            List<string> neighbourhoods = new List<string> { "aguada", "aires puros", "arroyo seco", "atahualpa", "bañados de carrasco", "barra de carrasco", "barrio sur", "bella italia", "bella vista", "belvedere", "bolivar", "brazo oriental", "buceo", "camino maldonado", "capurro", "capurro bella vista", "carrasco", "carrasco este", "carrasco norte", "casabo", "casabo pajas blancas", "casavalle", "centro", "cerrito", "cerro", "ciudad vieja", "colon", "conciliacion", "cordon", "flor de maronas", "goes", "golf", "ituizango", "jacinto vera", "jardines del hipodromo", "la blanqueada", "la caleta", "la colorada", "la comercial", "la figurita", "la paloma tomkinson", "la teja", "larrañaga", "las acacias", "las canteras", "lezica", "malvín", "malvin norte", "manga", "marconi", "maroñas", "melilla", "mercado modelo", "montevideo", "nuevo paris", "pajas blancas", "palermo", "parque batlle", "parque miramar", "parque rodo", "paso de la arena", "paso molino", "peñarol", "peñarol lavalleja", "perez castellanos", "piedas blancas", "pocitos", "pocitos nuevo", "prado", "prado nueva savona", "puerto", "puerto buceo", "punta carretas", "punta espinillo", "punta gorda", "punta rieles", "reducto", "santiago vazquez", "sayago", "tres cruces", "tres ombues pblo victoria", "union", "villa biarritz", "villa dolores", "villa española", "villa garcia manga rural", "villa muños", "zona rural" };
                
            foreach (string x in entrada)
            {
                if (x.Contains("Price"))
                {
                    string[] splitted = x.Split("-");
                    mediator.AddPriceFilter(Int32.Parse(splitted[1]),Int32.Parse(splitted[2]));
                }

                else if (neighbourhoods.Contains(x))
                {
                    mediator.AddNeighbourhoodFilter(x);
                }

                else if (x.Contains("Rooms"))
                {
                    string[] splitted = x.Split("-");
                    mediator.AddRoomsFilter(Int32.Parse(splitted[1]));
                }
                
                else if (x.Contains("Baths"))
                {
                    string[] splitted = x.Split("-");
                    mediator.AddBathsFilter(Int32.Parse(splitted[1]));
                }

                else if (x.Contains("HabitableArea"))
                {
                    string[] splitted = x.Split("-");
                    mediator.AddHabitableAreaFilter(double.Parse(splitted[1]));
                }
                
                else if (x.Contains("Area"))
                {
                    string[] splitted = x.Split("-");
                    mediator.AddAreaFilter(double.Parse(splitted[1]));
                }
                
                else if (x.Contains("Garage"))
                {
                    mediator.AddGarageFilter(bool.Parse(x));
                }

                else if (x.Contains("Garden"))
                {
                    mediator.AddGardenFilter(bool.Parse(x));
                }

                else if (x.Contains("SwimmingPool"))
                {
                    mediator.AddSwimmingPoolFilter(bool.Parse(x));
                }
                else if (x.Contains("Barbecue"))
                {
                    mediator.AddBarbecueFilter(bool.Parse(x));
                }
                
                else if (x.Contains("Gym"))
                {
                    mediator.AddGymFilter(bool.Parse(x));
                } 
            }
        }
    }
}