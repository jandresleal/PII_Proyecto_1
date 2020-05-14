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

*/

using System;

namespace Library
{

    public abstract class Interpreter : IInterpreter
    {
        public void AskQuestion()
        {
   
        }
        public virtual bool CheckForEmptyFilters(string input)
        {
           
        }
        public virtual void ParseInput(string input)
        {
           
        }
    }
}