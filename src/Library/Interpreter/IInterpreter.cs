namespace Library
{
    public interface IInterpreter
    {
        /// <summary>
        /// Esta interfaz tiene una operación 'ParseInput' el cual se encarga de procesar lo que escribio el usuario y
        /// transformarlo en un objeto interpreter message, este objeto tiene dos propiedades, el Tipo que hace referencia al filtro
        /// y la otra propiedad es Value(valor). A su vez, el Interprente ensambla los handlers.
        /// 
        /// Una vez que se tienen todos los filtros, recibe un mensaje y llama un método del Mediator para obtener los
        /// filtros de Database y pasarlos a la API
        /// 
        /// En el caso de tener más de un intérprete, la operación ParseInput sería polimórfica pero por
        /// razones de tiempo esto no fue realizado. Nos quedamos con una única posible interpretación
        /// como sería configurable
        /// </summary>
        /// <param name="input"></param>
        /// <param name="id"></param>
        void ParseInput(long id, string input);
    }
}