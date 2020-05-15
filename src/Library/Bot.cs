/*

    La clase bot contiene una lista con todas las instancias Mediator que están activas,
    y las crea y destruye durante el funcionamiento, por lo que es un Creator de esta clase,
    y además es un Expert de ellos, pues los conoce y maneja.

    Cumple además el principio SRP, ya que solamente cambia al agregarse o eliminarse instancias
    de esa lista. 

*/

using System.Collections.Generic;

namespace Library
{
    public class Bot
    {
        public IList<IMediator> Mediators {get; set;}

        public IMediator mediator AddMediator()
        {
            
        }

        public void RemoveMediator(IMediator mediator)
        {

        }
    }
}