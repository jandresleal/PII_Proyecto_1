namespace Library
{
    public interface IHandler
    {
        /// <summary>
        /// Esta interfaz se encargada de definir un tipo que posteriormente
        /// puede ser implementado por múltiples clases.
        /// 
        /// Su objetivo es recibir el objeto message, y pasarse el mismo entre los handler que implementan esta interfaz,
        /// para ver quien es el responsable en reconocerlo para ensamblar el filtro correspondiente.
        /// 
        /// Para cada Handler se cumple el principio SRP, dado a que su única responsabilidad es ensamblar los filtros correspondientes
        /// al type.
        /// 
        /// Sigue el patron Chain of Responsability dado que le da a más de un objeto la posibilidad de responder a su 
        /// petición, la misma se pasa mediante los handlers hasta que es procesada por alguno de ellos.
        /// </summary>
        /// <value></value>
        IHandler Next { set; }

        void Handle(InterpreterMessage m);
    }
}