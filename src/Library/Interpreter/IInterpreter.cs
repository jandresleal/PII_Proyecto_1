namespace Library
{
    public interface IInterpreter
    {
        /// <summary>
        /// Esta interfaz tiene una operación 'ParseInput' el cual se encarga de agarrar lo que escribio el usario y
        /// transformarlo en un objeto message, este objeto tiene dos propiedades, el Tipo que hace referencia al filtro
        /// y la otra porpiedad es Value(valor). A su vez, el Interprente ensambla los handlers.
        /// 
        /// Una vez que se tienen todos los filtros, recibe un mensaje y llama un método del Mediator para obtener los
        /// filtros de Database y pasarlos a la API
        /// 
        /// ¿Interpreter es quien instancia a todos los filtros y como es quien
        /// realiza la interpretación de la entrada del cliente, conoce todos
        /// los datos que se pasan a ellos. Es por esto que lo consideramos
        /// cercano a los filtros y un Expert de ellos.?
        /// 
        /// ¿La operación ParseInput es polimórfica dado a que su resultado dependerá de las clases que implementen
        /// esta operacion, y se apunta a que se
        /// respete LSP con una implementación dónde no haya interferencia.?
        /// </summary>



        /// <summary>
        /// Se implementan un método polimórfico - ParseInput
        /// que será sobrescribile por las clases que heredan para darle 
        /// flexibilidad al entorno y permitir la futura extensión a diferentes
        /// plataformas. Se utiliza el patrón polymorphism y se apunta a que se
        /// respete LSP con una implementación dónde no haya interferencia.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="mediator"></param>
        /// <param name="database"></param>
        void ParseInput(long id, string input);
    }
}