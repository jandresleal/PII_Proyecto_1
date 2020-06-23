using System.Data;

namespace Library
{
    public class ChannelAdapterWhatsApp : IChannelAdapter
    {
        /// <summary>
        /// Este channel adapter sería el encargado de comunicarse con
        /// la plataforma WhatsApp (a definir la integración) y quitar
        /// la estructura con la cual se realiza el intercambio de información
        /// con la integración, permitiendo que una vez la información se procese
        /// sea en el formato correcto para el core del robot
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public void UserInput(string input)
        {
            SimpleInterpreter simpleInterpreter = new SimpleInterpreter();
            //Me comunico con el simple interpreter para que me cree la Database
            Database database = simpleInterpreter.ParseInput(input);

             /*
              * Aca la tenemos que guardar y analizar que hacer con los valores. En caso de que tengamos todo lo necesario es simplemente
             buscar la propiedad con los datos que tenemos y guardar los resultados en el campo result de la database.
             En caso que no contemos con informacion suficiente para realizar la busqueda tenemos que solicitar al usuario mas informacion.
             El solicitar informacion nos agregaria complejidad. Ya que como esta desarrollado contemplamos solo el caso de que siempre se cree
             una nueva database.En ese caso deberiamos de crear un buscador de database para poder continuar agregandole informacion a una
             ya creada.
             */
            Database.SaveDatabase(database);
            //database.Result = Property.SearchProperty(database);
            SendTextToUser(database.Result);
        }

        public string SendTextToUser(string toUser)
        {
            return toUser;
        }
        
        public bool EndMediator(string connection)
        {
            return false;
        }
    }
}