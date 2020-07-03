using System;
using System.Collections.Generic;

namespace Library
{
    public class NeighbourhoodHandler : BaseHandler
    {
        /// <summary>
        /// Esta clase implementa la interfaz BaseHandler, tiene como única responsabilidad reconocer
        /// el type correspondiente al barrio para luego ensamblar el filtro del type con ese valor. Cumple con SRP
        /// </summary>
        /// <param name="m"></param>
        public override void Handle(InterpreterMessage m)
        {
            List<string> neighbourhoods = new List<string> { "aguada", "aires puros", "arroyo seco", "atahualpa", "bañados de carrasco", "barra de carrasco", "barrio sur", "bella italia", "bella vista", "belvedere", "bolivar", "brazo oriental", "buceo", "camino maldonado", "capurro", "capurro bella vista", "carrasco", "carrasco este", "carrasco norte", "casabo", "casabo pajas blancas", "casavalle", "centro", "cerrito", "cerro", "ciudad vieja", "colon", "conciliacion", "cordon", "flor de maronas", "goes", "golf", "ituizango", "jacinto vera", "jardines del hipodromo", "la blanqueada", "la caleta", "la colorada", "la comercial", "la figurita", "la paloma tomkinson", "la teja", "larrañaga", "las acacias", "las canteras", "lezica", "malvín", "malvin norte", "manga", "marconi", "maroñas", "melilla", "mercado modelo", "montevideo", "nuevo paris", "pajas blancas", "palermo", "parque batlle", "parque miramar", "parque rodo", "paso de la arena", "paso molino", "peñarol", "peñarol lavalleja", "perez castellanos", "piedas blancas", "pocitos", "pocitos nuevo", "prado", "prado nueva savona", "puerto", "puerto buceo", "punta carretas", "punta espinillo", "punta gorda", "punta rieles", "reducto", "santiago vazquez", "sayago", "tres cruces", "tres ombues pblo victoria", "union", "villa biarritz", "villa dolores", "villa española", "villa garcia manga rural", "villa muños", "zona rural" };

            if (m.MessageType == Type.Neighbourhood)
            {
                if (neighbourhoods.Contains(m.Value))
                {
                    SingleInstance<Mediator>.GetInstance.AddFilter(
                        new NeighbourhoodFilter(m.Value),
                        m.ID
                    );
                }
                else
                {
                    throw new InvalidInputException("Por favor ingrese correctamente el barrio.");
                }
            }
            
            base.Handle(m);
        }
    }
}