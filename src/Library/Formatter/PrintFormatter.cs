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
                result = "Se listan las propiedades a continuación:" + Environment.NewLine + Environment.NewLine;

                foreach (IProperty property in data)
                {
                    result += $"{property.ImagePath}" + Environment.NewLine + $"{property.Title} {property.Description} Se encuentra en el barrio {property.Neighbourhood} y su precio es de {property.Price}.";
                    
                    if ($"{property.Expenses}" != "")
                    {
                        result+= $" Tiene unos gastos fijos mensuales de {property.Expenses}.";
                    }

                    result += Environment.NewLine + $"https://infocasas.com.uy{property.ResultPath}";

                    result += Environment.NewLine;
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