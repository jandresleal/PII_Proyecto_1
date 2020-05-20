/*
Se utilizó el patrón Creator y Expert dado que Properties conoce la información necesaria
para instanciar objetos IProperty. Esta información se la provee el mediator que
llama a la clase Properties para instanciar todos los objetos necesarios y finalmente
recibir la lista de propiedades con los objetos instanciados.

También aplicamos SRP dado que la clase tiene una única razón para ser modificada
y es que se agreguen objetos o se remuevan de la lista de properties. Esto ocurre mediante
dos métodos de instancia.

*/

using System.Collections.Generic;

namespace Library
{
    public class Properties
    {

        private List<IProperty> properties;

        public Properties()
        {
            this.properties = new List<IProperty>();
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