/*

Se utilizó el patrón Creator y Expert dado que Properties conoce la información necesaria
para instanciar objetos IProperty. Esta información se la provee el mediator que
llama a la clase Properties para instanciar todos los objetos necesarios y finalmente
recibir la lista final de propiedades con los objetos instanciados.

También aplicamos SRP dado que la clase tiene una única razón para ser modificada
y es que se agreguen objetos o se remuevan de la lista de properties. Esto ocurre mediante
dos métodos de instancia.

Creamos una clase abstracta Property de tipo IProperty dado que no queremos que haya una instancia de Property pero si que clases que comparten comportamiento puedan heredar y sobrescribir solamente el código necesario. De esta manera se reutiliza código y se mantiene un código extensible, por ende cumple con OCP.
La única responsabilidad de la clase Property es almacenar las características de las propiedades, entonces su única razón de cambio es si se la agregan o modifican atributos, por lo tanto cumple con el principio SRP y a su vez sigue el patrón Expert porque se le asigna la responsabilidad a la clase que tiene toda la información necesaria.

*/


namespace Library
{
    public class Properties
    {

        public List<IProperty> Properties { get; set; }

        public Properties()
        {
            this.Properties = new List<IProperty>();
        }

        public void AddProperty(string neighborhood, int rooms, int baths, double habitableArea, double area, bool garage, bool garden, bool swimmingPool, bool barbecue)
        {

        }

        public void RemoveProperty(IProperty property)
        {

        }
        
        public void PropertiesToMediator(List<IProperty> properties)
        {

        }
    }
}