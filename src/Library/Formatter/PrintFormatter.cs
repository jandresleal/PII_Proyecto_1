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
                    result += $"La propiedad se encuentra en el barrio {property.Neighbourhood}";
                    
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