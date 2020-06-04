/*

Utilizamos una clase abstracta que implementa la interfaz dado que
entendimos que todos los distintos tipos de formato que queramos
dar o implementar en el futuro, seguirán ciertas condiciones básicas,
es por esto, que sirve como una forma de reutilizar código, permitir
la extensión y el mantenimiento. Se respeta el principio OCP.

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

using System;
using System.Collections.Generic;

namespace Library
{
    public class PrintFormatter : IPrintFormatter
    {
        public string FormatMessage(List<IProperty> data)
        {
            string result = "Se listan las propiedades a continuación" + Environment.NewLine;

            foreach (IProperty property in data)
            {
                result += $"La propiedad se encuentra en el barrio {property.Neighbourhood} y cuenta con: {property.Rooms} dormitorios, {property.Baths} baños, cuenta con {property.HabitableArea} metros cuadrados construidos y su terreno consiste de {property.Area} metros cuadradros.";

                if (property.Garage == true)
                {
                    result += "Para su comodidad, la propiedad incluye garage.";
                }
                
                else if (property.Barbecue == true)
                {
                    result += "A su vez, esta propiedad cuenta con barbacoa.";
                }

                else if (property.Garden == true)
                {
                    result += "Además, presenta un jardín ideal para unas tardes tomando mate.";
                }

                else if (property.Gym == true)
                {
                    result += "Asimismo, este dominio incluye un gimnasio completamente equipo.";
                }

                else if (property.SwimmingPool == true)
                {
                    result += "Y por si fuera poco, tiene piscina!";
                }

                result += Environment.NewLine;
            }
            return result;
        }       
    }
}