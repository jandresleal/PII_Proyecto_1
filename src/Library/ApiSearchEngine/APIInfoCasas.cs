using System.Collections.Generic;
using PII_ICApi;

namespace Library
{
    public class APIInfoCasas : IAPIsSearchEngines
    {
        public APIInfoCasas() {  }

        /// <summary>
        /// Esta clase es la encargada de comunicarse con la API de InfoCasas con el
        /// fin de obtener la lista de propiedades a instanciar y posteriormente
        /// mostrar al usuario que realizó la búsqueda.
        /// 
        /// Este elemento busca ser un Expert en el manejo de las APIs para comunicarse
        /// con el Mediator, y tener una única razón de cambio, siguiendo SRP. 
        /// Permite además la expansión a diferentes APIs aplicando el principio polymorphic,
        /// ya que es independiente de ellas, y permitiría que se cumpla LSP ya que las APIs no
        /// deberían interferir entre sí, alterando los resultados esperados. 
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public void AskAPI(List<IFilter> filters, long id)
        {
            ICApi api = new ICApi();

            string barrio = string.Empty;

            foreach (IFilter filter in filters)
            {
                
                if (filter is DepartmentFilter)
                {
                    api.SetDepartment($"{filter.Value}");
                }

                else if (filter is NeighbourhoodFilter)
                {
                    api.SetCitiesAndNeighbourhoods(new string[]{$"{filter.Value}"});

                    barrio = filter.Value;
                }

                else if (filter is PropertyTypeFilter)
                {
                    if (filter.Value == "apartamento")
                    {
                        api.SetPropertyTypes(new PropertyType[]{PropertyType.Apartamento});
                    }
                    else if (filter.Value == "casa")
                    {
                        api.SetPropertyTypes(new PropertyType[]{PropertyType.Casa});
                    }
                }

                else if (filter is TransactionTypeFilter)
                {
                    if (filter.Value == "compra")
                    {
                        api.SetTransactionType(TransactionType.Venta);
                    }
                    else if (filter.Value == "alquiler")
                    {
                        api.SetTransactionType(TransactionType.Alquiler);
                    }
                }
            }

            List<ICApiSearchResult> results = api.Search();

            this.Parse(results, id, barrio);
        }

        // el método parse a continuación es llamado por el mediator y
        // en la práctica recibe el string retornado por la API
        public void Parse(List<ICApiSearchResult> results, long id, string barrio)
        {
            foreach (ICApiSearchResult result in results)
            {
                SingleInstance<Mediator>.GetInstance.AddProperty(
                    new Property(result.Title, result.Description, result.Price, result.Expenses, barrio, result.ImageURL, result.ResultURL),
                    id
                );
            }

            SingleInstance<Mediator>.GetInstance.CreateTextToPrint(
                id
            );
        }
    }
}