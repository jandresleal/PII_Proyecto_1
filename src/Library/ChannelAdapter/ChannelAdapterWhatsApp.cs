
namespace Library
{
    public class ChannelAdapterWhatsApp : IChannelAdapter
    {
        /// <summary>
        /// Utilizamos un atributo privado para controlar el fin de la 
        /// interacción con el usuario. Cuando el programa detecta que termina el chat,
        /// elimina la instancia de mediator que se creó para la interacción
        /// con el usuario.
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