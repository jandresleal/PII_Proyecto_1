using System.Threading.Tasks;
using System.Collections.Generic;

namespace PII_ICApi
{
    /// <summary>
    /// Punto de entrada principal de la biblioteca.
    /// Permite realizar una consula de listado a InfoCasas.
    /// </summary>
    /// <example>
    /// <code>
    /// ICApi api = new ICApi()
    ///    .SetTransactionType(TransactionType.Alquiler)
    ///    .SetPropertyTypes(new PropertyType[]{PropertyType.Apartamento})
    ///    .SetDepartment("montevideo")
    ///    .SetCitiesAndNeighbourhoods(new string[]{"pocitos"});
    /// List<ICApiSearchResult> results = api.Search();
    /// results.ForEach(r => Console.WriteLine(r));
    /// </code>
    /// </example>
    public class ICApi
    {
        private ICUrlBuilder urlBuilder = new ICUrlBuilder();

        /// <summary>
        /// Realiza una búsqueda en InfoCasas y retorna una lista con
        /// los resultados.
        /// 
        /// Para buscar se utiliza:
        /// - Tipo de transacción (alquiler o venta)
        /// - Tipo(s) de propiedad: casa y/o apartamento
        /// - Departamento (opcional)
        /// - Ciudad(es)/Barrio(s) (opcional)
        /// </summary>
        /// <returns>Lista de resultados de la búsqueda</returns>
        public List<ICApiSearchResult> Search()
        {
            var scraper = new ICScrapper(urlBuilder.Url);
            Task<List<ICApiSearchResult>> task = scraper.Scrape();
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Setea el tipo de transacción.
        /// Permite encadenamiento de métodos.
        /// </summary>
        /// <param name="transactionType">Tipo de transacción</param>
        /// <returns>Instancia de ICApi</returns>
        public ICApi SetTransactionType(TransactionType transactionType)
        {
            this.urlBuilder.TransactionType = transactionType;
            return this;
        }

        /// <summary>
        /// Setea los tipos de propiedad a buscar.
        /// Permite encadenamiento de métodos.
        /// </summary>
        /// <param name="types">Tipos de propiedad</param>
        /// <returns>Instancia de ICApi</returns>
        public ICApi SetPropertyTypes(PropertyType[] types)
        {
            this.urlBuilder.PropertyTypes = types;
            return this;
        }

        /// <summary>
        /// Setea el departamento donde se buscarán propiedades.
        /// Permite encadenamiento de métodos.
        /// </summary>
        /// <param name="department">Departamento</param>
        /// <returns>Instancia de ICApi</returns>
        public ICApi SetDepartment(string department)
        {
            this.urlBuilder.Department = department;
            return this;
        }

        /// <summary>
        /// Setea las ciudades y barrios para filtrar la búsqueda.
        /// Permite encadenamiento de métodos.
        /// </summary>
        /// <param name="places">Ciudades y barrios</param>
        /// <returns>Instancia de ICApi</returns>
        public ICApi SetCitiesAndNeighbourhoods(string[] places)
        {
            this.urlBuilder.CitiesAndNeighbourhoods = places;
            return this;
        }
    }
}
