namespace Library
{
    public interface IInterpreter
    {
        /// <summary>
        /// Utilizamos una clase abstracta dado que implementamos la interfaz 
        /// e identificamos que hay código que no deberá de ser sobrescrito por
        /// las clases que heredan, entonces, se puede reutilizar código y también
        /// es extensible dado que se puede seguir agregando comportamiento a las
        /// clases que heredan.

        /// Se cumple con el principio OCP debido a que se reutiliza código con
        /// las clases herederas y también es extensible dado que podemos agregar
        /// nuevos interpretes sin modificar las clases existentes.

        /// Interpreter es quien instancia a todos los filtros y como es quien
        /// realiza la interpretación de la entrada del cliente, conoce todos
        /// los datos que se pasan a ellos. Es por esto que lo consideramos
        /// cercano a los filtros y un Expert de ellos.

        /// Se implementan un método polimórfico - ParseInput
        /// que será sobrescribile por las clases que heredan para darle 
        /// flexibilidad al entorno y permitir la futura extensión a diferentes
        /// plataformas. Se utiliza el patrón polymorphism y se apunta a que se
        /// respete LSP con una implementación dónde no haya interferencia.
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