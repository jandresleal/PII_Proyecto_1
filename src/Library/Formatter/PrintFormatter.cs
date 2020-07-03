using System;
using System.Collections.Generic;
using System.Threading;

namespace Library
{
    public class PrintFormatter : IPrintFormatter
    {
        /// <summary>
        /// Esta clase implementa la interfaz IPrintFormatter, tiene una única (pero gran) responsabilidad
        /// que es realizar el formateo del mensaje final que llegará al usuario.
        /// Esta clase recibe la información necesaria para crear el resultado
        /// esperado por el usuario. Es por esto que no es experta en dicha información porque la misma se
        /// recibe por paramentro, por ende, no cumple con el patrón Expert, pero si con el principio SRP,
        /// su única responsabilidad es la mencionada anteriormente.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        
        public PrintFormatter() {  }

        public string FormatMessage(List<IProperty> data, long id) 
        {
            string result = string.Empty;

            if (data.Count > 0)
            {
                SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Se listan las propiedades a continuación:");

                Thread.Sleep(500);

                foreach (IProperty property in data)
                {
                    if (property.Neighbourhood == "montevideo")
                    {
                        string price = this.VariableReplace(property.Price, " ");

                        if (this.PathContainsHttp(property.ResultPath))
                        {
                            result = $"{property.ResultPath}" + Environment.NewLine + $"{property.ImagePath}" + Environment.NewLine + $"{property.Title} {property.Description} Se encuentra en el barrio {property.Neighbourhood} y su precio es de {price}";
                        }

                        else
                        {
                            result = $"https://infocasas.com.uy{property.ResultPath}" + Environment.NewLine + $"{property.ImagePath}" + Environment.NewLine + $"{property.Title} {property.Description} Se encuentra en el barrio {property.Neighbourhood} y su precio es de {price}";
                        }

                        if ($"{property.Expenses}" != string.Empty)
                        {
                            string expenses = this.VariableReplace(property.Expenses, " GC");

                            result+= $" Tiene unos gastos fijos mensuales de {expenses}.";
                        }

                        SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, result);
                    }

                    else
                    {
                        string price = this.VariableReplace(property.Price, " ");

                        if (this.PathContainsHttp(property.ResultPath))
                        {
                            result = $"{property.ResultPath}" + Environment.NewLine + $"{property.ImagePath}" + Environment.NewLine + $"{property.Title} {property.Description} Se encuentra en el barrio {property.Neighbourhood} y su precio es de {price}";
                        }

                        else
                        {
                            result = $"https://infocasas.com.uy{property.ResultPath}" + Environment.NewLine + $"{property.ImagePath}" + Environment.NewLine + $"{property.Title} {property.Description} Se encuentra en el barrio {property.Neighbourhood} y su precio es de {price}";
                        }

                        if ($"{property.Expenses}" != string.Empty)
                        {
                            string expenses = this.VariableReplace(property.Expenses, " GC");

                            result+= $" Tiene unos gastos fijos mensuales de {expenses}.";
                        }

                        SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, result);
                    }
                }
            }
            else
            {
                SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "No se encontraron propiedades que satisfagan la búsqueda.");
            }
            
            Thread.Sleep(1000);

            SingleInstance<Mediator>.GetInstance.SendInfoToAdapter(id, "Si desea realizar una nueva búsqueda, digite 1, de lo contrario, muchas gracias!");

            SingleInstance<Mediator>.GetInstance.SetState(id, Status.SearchDone);

            return result;
        }

        public bool PathContainsHttp (string input)
        {
            if (input.Contains("http"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string VariableReplace(string input, string toReplace)
        {
            return input.Replace(toReplace, "");
        }     
    }
}