
namespace Library
{
    public interface IChannelAdapter
    {
        /// <summary>
        /// Esta interfaz es la encargada de definir un tipo que será el que las distintas
        /// integraciones implementen. Tendrá la responsabilidad de recibir información 
        /// de la integración y convertirla a información entendible por el core del bot.
        /// 
        /// Decidimos implementar los ChannelAdapters mediante una interfaz para poder 
        /// independizar nuestro código de ellos, y facilitar la expansión del bot a nuevas
        /// plataformas.
        /// Buscamos que cada channel adapter cuando implementa la operación, termine devolviendo
        /// el mismo resultado que los demás con el fin de que el core del bot
        /// trabaje de una forma única. Sin embargo, cada channel adapter al tratarse de distintas
        /// integraciones, tendrá que realizar diferentes transformaciones dependiendo de su entorno.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        void UserInput(string input);

        string SendTextToUser(string toUser);

        bool EndMediator(string connection);
    }
}