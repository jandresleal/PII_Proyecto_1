/*

    Utilizamos un atributo privado finish para controlar el fin de la 
    interacción con el usuario. Cuando el programa detecta que termina el chat,
    elimina la instancia de mediator que se creó para la interacción
    con el usuario.

*/
namespace Library
{
    public class ChannelAdapterWhatsApp : IChannelAdapter
    {

        public string UserInput(string Input)
        {
        
        }

        public void SendTextToUser(string toUser)
        {
            
        }
        
        public bool EndMediator(string connection)
        {
            
        }
    }
}