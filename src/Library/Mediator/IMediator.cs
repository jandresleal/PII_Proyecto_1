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

        /// Buscamos encapsular las clases en grupos de alta cohesión entre sí, para que la complejidad 
        /// de cada tarea sea manejable y por otro lado maximizar la reutilización del código al 
        /// restringir la comunicación entre la clases y forzarla por el Mediator, según el principio 
        /// de Bajo Acoplamiento.
        /// </summary>

        void AddFilter(IFilter filter, long id);

        void AddProperty(IProperty property, long id);

        void Search(long id);

        void CreateTextToPrint(IPrintFormatter formatter, long id);

        void SendInfoToAdapter(long id, string input);
    }
}