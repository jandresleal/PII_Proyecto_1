
namespace Library
{
    public interface IChannelAdapter
    {
        /// <summary>
        /// Para implementar este método decidimos utilizar el patrón de diseño Adapter,
        /// cuyo objetivo es poder comunicar a dos interfaces diferentes, en nuestro caso
        /// la plataforma que opera el usuario y nuestro código, convirtiendo los objetos de 
        /// la primera a una forma comprensible por la segunda.
        /// Decidimos implementar los ChannelAdapters de manera polimórfica para poder 
        /// independizar nuestro código de ellos, y facilitar la expansión del bot a nuevas
        /// plataformas.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string UserInput(string input);

        void SendTextToUser(string toUser);

        bool EndMediator(string connection);
    }
}