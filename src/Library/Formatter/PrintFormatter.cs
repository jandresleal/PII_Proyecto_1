using System;
using System.Collections.Generic;

namespace Library
{
    public class PrintFormatter : IPrintFormatter
    {
        /// <summary>
        /// Esta clase tiene una única (pero gran) responsabilidad que es realizar
        /// el formateo del mensaje final que llegará al usuario.
        /// Esta clase recibe la información necesaria para crear el resultado
        /// esperado por el usuario. Es experta en esta información y su única 
        /// responsabilidad es realizar esta acción.
        /// Se respeta el principio SRP y también se sigue el patrón Expert.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        
        public PrintFormatter() {  }

        public string FormatMessage(List<IProperty> data) 
        {
            string result = string.Empty;

            if (data.Count > 0)
            {
                result = "Se listan las propiedades a continuación" + Environment.NewLine;

                int i = 1;

                foreach (IProperty property in data)
                {
                    result += $"La propiedad se encuentra en el barrio {property.Neighbourhood} y cuenta con: {property.Rooms} dormitorios, {property.Baths} baños, cuenta con {property.HabitableArea} metros cuadrados construidos y su terreno consiste de {property.Area} metros cuadradros.";
                    
                    if (property.Garage == true)
                    {
                        result += " Para su comodidad, la propiedad incluye garaje.";
                    }
                    
                    if (property.Barbecue == true)
                    {
                        result += " A su vez, esta propiedad cuenta con barbacoa.";
                    }

                    if (property.Garden == true)
                    {
                        result += " Además, presenta un jardín ideal para unas tardes tomando mate.";
                    }

                    if (property.Gym == true)
                    {
                        result += " Asimismo, este inmueble incluye un gimnasio completamente equipado.";
                    }

                    if (property.SwimmingPool == true)
                    {
                        result += " Y por si fuera poco, tiene piscina!";
                    }
                    
                    if (data.Count > i)
                    {
                        result += Environment.NewLine;
                    }
                    i++;
                }
            }
            else
            {
                result = "No se encontraron propiedades que satisfagan la búsqueda.";
            }
            return result;
        }       
    }
}