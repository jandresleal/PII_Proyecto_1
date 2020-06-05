
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
        public string UserInput(string Input)
        {
            return "";
        }

        public void SendTextToUser(string toUser)
        {
            
        }
        
        public bool EndMediator(string connection)
        {
            return false;
        }
    }
}