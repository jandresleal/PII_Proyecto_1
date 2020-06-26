using System.Collections.Generic;
namespace PII_ICApi
{
    /// <summary>
    /// Representa un resultado de la búsqueda.
    /// </summary>
    public class ICApiSearchResult
    {
        internal ICApiSearchResult(string title, string description, string price, string expenses, string imageURL, string resultURL, PropertyType type)
        {
            this.Title = title;
            this.Description = Description;
            this.Price = price;
            this.ImageURL = imageURL;
            this.ResultURL = resultURL;
            this.Type = type;
            this.Expenses = expenses;
        }
        
        /// <value>Título del item.</value>
        public string Title { get; private set; }

        /// <value>Descripción corta del item.</value>
        public string Description { get; private set; }

        /// <value>Precio del item.</value>
        public string Price { get; private set; }

        /// <value>Gastos comunes.</value>
        public string Expenses { get; private set; }

        /// <value>URL de la imágen del item.</value>
        public string ImageURL { get; private set; }

        /// <value>URL del item en InfoCasas.</value>
        public string ResultURL { get; private set; }

        /// <value>Tipo de propiedad</value>
        public PropertyType Type { get; private set; }

        public override string ToString()
        {
            return $"{Title},{Price},{Expenses},{ImageURL},{ResultURL},{Type.ToString()}";
        }
    }
}