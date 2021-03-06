namespace Library
{
    public interface IMediator
    {
        /// <summary>
        /// Estructuramos el código con el patrón de diseño Mediator, con el objetivo de que toda la 
        /// comunicación entre las clases pase por un objeto único llamado mediator. 
        /// De esta manera, buscamos independizar las clases entre sí, para poder modificarlas
        /// sin alterar el funcionamiento de las demás. Esto nos facilita la implementación
        /// de las diferentes plataformas independientemente del funcionamiento interno del bot.
        /// También sigue el patrón singleton dado que se tiene una única instancia de él
        /// para el funcionamiento del bot
        /// 
        /// Buscamos encapsular las clases en grupos de alta cohesión entre sí, para que la complejidad 
        /// de cada tarea sea manejable y por otro lado maximizar la reutilización del código al 
        /// restringir la comunicación entre la clases y forzarla por el Mediator, según el principio 
        /// de Bajo Acoplamiento, de tal forma que, si se hace una modificación en alguna de las clases tenga
        /// una mínima repercusión posible en las demás clases, disminuyendo la dependencia entre ellas.
        /// </summary>
        void AddFilter(IFilter filter, long id);

        void AddProperty(IProperty property, long id);

        void Search(long id);

        void CreateTextToPrint(long id);

        void SendInfoToAdapter(long id, string input);

        void SetAPI(long id, IAPIsSearchEngines api);

        void SetAdapter(long id, IChannelAdapter adapter);

        void ToInterpreter(long id, string input);
    }
}