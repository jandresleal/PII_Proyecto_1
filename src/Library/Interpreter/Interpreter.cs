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

        }
        
        private List<IFilter> filters = new List<IFilter>();

        private List<IFilter> ExtendedRange = new List<IFilter>();

        public void AskQuestion()
        {
   
        }

        public virtual bool CheckForEmptyFilters()
        {
           
        }

        public virtual List<IFilter> ParseInput(string input)
        {
           
        }

        public virtual List<IFilter> CreateExtendedList(string input)
        {
           
        }

        public void SendFiltersToMediator()
        {

        }
    }
}