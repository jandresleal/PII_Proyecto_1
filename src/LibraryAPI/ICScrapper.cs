using System;
using System.Collections.Generic;
using AngleSharp;
using AngleSharp.Dom;
using System.Threading.Tasks;

namespace PII_ICApi
{
    /// <summary>
    /// Ejecuta una búsqueda en ML de Uruguay y parsea el HTML
    /// de respuesta para construir la lista de resultados.
    /// </summary>
    internal class ICScrapper
    {
        private string url;

        internal ICScrapper(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// Ejecuta la búsqueda y retorna los resultados.
        /// </summary>
        /// <returns>Lista de objetos resultado.</returns>
        public virtual async Task<List<ICApiSearchResult>> Scrape()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(this.url);
            return Parse(document);
        }

        /// <summary>
        /// Parsea el HTML de respuesta para construir la lista de objetos
        /// resultado.
        /// </summary>
        /// <param name="document">El HTML de respuesta de ML.</param>
        /// <returns>Lista de objetos resultado.</returns>
        protected virtual List<ICApiSearchResult> Parse(AngleSharp.Dom.IDocument document)
        {
            List<ICApiSearchResult> results = new List<ICApiSearchResult>();

            foreach(var item in document.QuerySelectorAll(".mainContentListado .propiedades-slider"))
            {
                string title = item.QuerySelector("a.holder-link").GetAttribute("title").Trim();
                string description = item.QuerySelector(".descriptionProp p, .textoDesc")?.InnerHtml?.Trim();
                string itemURL = item.QuerySelector("a.holder-link").GetAttribute("href");
                string imageURL = item.QuerySelector(".imagen img").GetAttribute("src");
                PropertyType propertyType = PropertyTypeExtensions.FromString(item.QuerySelector(".tipo-propiedad").InnerHtml.Trim()).Value;

                string price = item.QuerySelector(".precio").InnerHtml;
                if (price.IndexOf('<') >= 0)
                {
                    price = price.Substring(0, price.IndexOf('<')).Trim();
                }

                string expenses = item.QuerySelector(".gastos_comunes")?.InnerHtml?.Replace("+", "")?.Trim();

                results.Add(new ICApiSearchResult(title, description, price, expenses, imageURL, itemURL, propertyType));
            }

            return results;
        }

    }
}
