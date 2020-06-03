/*

Utilizamos una clase abstracta dado que implementamos la interfaz 
e identificamos que hay código que no deberá de ser sobrescrito por
las clases que heredan, entonces, se puede reutilizar código y también
es extensible dado que se puede seguir agregando comportamiento a las
clases que heredan.

Se cumple con el principio OCP debido a que se reutiliza código con
las clases herederas (ver AskQuestion() que será igual en todas) y
también es extensible dado que podemos agregar nuevos interpretes
sin modificar las clases existentes

Interpreter es quien instancia a todos los filtros y como es quien
realiza la interpretación de la entrada del cliente, conoce todos
los datos que se pasan a ellos. Es por esto que lo consideramos
cercano a los filtros y un Expert de ellos.

Se implementan dos métodos polimórficos - ParseInput y CheckForEmptyFilters
que ambos serán sobrescribiles por las clases que heredan para darle 
flexibilidad al entorno y permitir la futura extensión a diferentes
plataformas. Se utiliza el patrón polymorphism y se apunta a que se
respete LSP con una implementación dónde no haya interferencia.
*/

using System.Collections.Generic;

namespace Library
{

    public abstract class Interpreter : IInterpreter
    {
        public Interpreter()
        {
            this.Filters = new List<IFilter>();
            this.ExtendedFilters = new List<IFilter>();
        }
        
        public List<IFilter> Filters { get; }

        public List<IFilter> ExtendedFilters { get; }

        public void AddFilter(IFilter filter)
        {
            Filters.Add(filter);
        }

        public void RemoveFilter(IFilter filter)
        {
            Filters.Remove(filter);
        }

        public string AskQuestion()
        {
            return "Ingrese parámetros válidos con el fin de realizar su búsqueda";
        }

        public bool CheckForEmptyFilters()
        {
           if (Filters.Count == 0)
           {
               return true;
           }
           else
           {
               return false;
           }
        }

        public abstract List<IFilter> ParseInput(string input);

        public abstract List<IFilter> CreateExtendedList(string input);
    }
}