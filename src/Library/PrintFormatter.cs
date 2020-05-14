/*

Utilizamos una clase abstracta que implementa la interfaz dado que
entendimos que todos los distintos tipos de formato que queramos
dar o implementar en el futuro, seguirán ciertas condiciones básicas,
es por esto, que sirve como una forma de reutilizar código, permitir
la extensión y el mantenimiento. Se respeta el principio OCP

La única razón de cambio es recibir/modificar un mensaje. Con ese mensaje recibido
se realiza primero el formateo del mismo (a la forma que se quiera, 
esta clase realizaría un formato básico) y luego la impresión, ambos
métodos que pueden verse sobrescritos. Por esta razón, se respeta el
principio SRP y también se sigue el patrón Expert.

Además, implementamos método Print() y FormatMessage() polimórficos dado que dependiendo
de la superclase se verán distintos resultados a mismo método. Se sigue el patrón
polymorphism. Como estos métodos al ser implementados no deberían de producir efectos
colaterales, esperamos que se respete el principio LSP (cuando lo implementemos efectivamente
y funciona sin efectos colaterales, podremos afirmarlo).

*/

namespace Library
{
    public abstract class PrintFormatter : IPrintFormatter
    {
        public string Message { get; set; }

        public string FormattedMessage { get; set; }

        public PrintFormatter(string message)
        {
            this.Message = message;
        }

        public virtual void Print()
        {

        }

        public virtual void FormatMessage()
        {

        }

        public void SendMessageToMediator()
        {

        }
    }
}