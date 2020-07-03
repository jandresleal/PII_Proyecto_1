using System.Collections.Generic;
using PII_ICApi;

namespace Library
{
    public class APIInfoCasas : IAPIsSearchEngines
    {
        public APIInfoCasas() {  }

        /// <summary>
        /// Esta clase implementa la interfaz IAPIsSearchEngines, es la encargada de comunicarse con la API de
        /// InfoCasas con el fin de obtener la lista de propiedades a instanciar y posteriormente
        /// mostrarlas al usuario que realizó la búsqueda.
        /// 
        /// Esta interfaz respeta el principio SRP, tiene una única razón de cambio, esta sería
        /// que cambiara la forma en la que se integran las APIs.
        /// Permite además la expansión a diferentes APIs aplicando el principio polymorphic,
        /// ya que es independiente de ellas, y permite que se cumpla LSP ya que las APIs no
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

        /// <summary>
        /// Este método no se impleneta desde una interfaz dado que necesita recibir como parámetro un tipo
        /// específico de la API en cuestión, lo que provocaría un problema si implementamos otra API.
        /// </summary>
        /// <param name="results">Lista de objetos instanciados por la API</param>
        /// <param name="id">ID del usuario</param>
        /// <param name="barrio"></param>
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