using System;
using System.Collections.Generic;
using System.Threading;

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

        public void FormatMessage(List<IProperty> data, long id) 
        {
            string result = string.Empty;

            Database db = SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id);

            if (data.Count > 0)
            {
                SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Se listan las propiedades a continuación:");

                Thread.Sleep(500);

                foreach (IProperty property in data)
                {
                    if (property.Neighbourhood == "montevideo")
                    {
                        result = $"https://infocasas.com.uy{property.ResultPath}" + Environment.NewLine + $"{property.ImagePath}" + Environment.NewLine + $"{property.Title} {property.Description} Se encuentra en el barrio {property.Neighbourhood} y su precio es de {property.Price}";

                        if ($"{property.Expenses}" != string.Empty)
                        {
                            result+= $" Tiene unos gastos fijos mensuales de {property.Expenses}.";
                        }

                        SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, result);
                    }

                    else
                    {
                        result = $"https://infocasas.com.uy{property.ResultPath} {property.ImagePath}" + Environment.NewLine + $"{property.Title} {property.Description}. Su precio es de {property.Price}.";

                        if ($"{property.Expenses}" != string.Empty)
                        {
                            result+= $" Tiene unos gastos fijos mensuales de {property.Expenses}.";
                        }

                        SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, result);
                    }
                }
            }
            else
            {
                result = "No se encontraron propiedades que satisfagan la búsqueda.";
            }
            
            Thread.Sleep(1000);

            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Si desea realizar una nueva búsqueda, digite 1, de lo contrario, muchas gracias!");

            SingleInstance<Mediator>.GetInstance.SetState(id, Status.SearchDone);
        }       
    }
}