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
        public string UserInput { get; set; }

        public string Answer { get; set; }

        private bool finish;

        public void SendTextToInterpreter(string data)
        {
            
        }
        public void SendTextToUser(string data)
        {
            
        }
        public void EndMediator(bool finish)
        {
            
        }
    }
}