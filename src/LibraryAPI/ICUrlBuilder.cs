using System.Linq;
namespace PII_ICApi
{
    /// <summary>
    /// Crea una URL de búsqueda en InfoCasas a partir de los filtros 
    /// seteados.
    /// </summary>
    internal class ICUrlBuilder
    {
        public string Url
        {
            get
            {
                string url = "https://www.infocasas.com.uy";
                if (this.TransactionType == null)
                {
                    throw new ICIncompleteUrlException("No se puede construir una URL de búsqueda: falta tipo de transacción.");
                }
                url += $"/{this.EncodedTransactionType}";
                
                if (this.PropertyTypes == null || this.PropertyTypes.Length == 0)
                {
                    throw new ICIncompleteUrlException("No se puede construir una URL de búsqueda: falta tipo de propiedad.");
                }
                url += $"/{this.EncodedPropertyTypes}";

                url += $"/{this.EncodedDepartment}";

                url += $"/{this.EncodedCitiesAndNeighbourhoods}";

                return url;
            }
        }

        public TransactionType? TransactionType { get; set; }

        public PropertyType[] PropertyTypes { get; set; }

        public string Department { get; set; }

        public string[] CitiesAndNeighbourhoods { get; set; }

        protected string EncodedPropertyTypes
        {
            get
            {
                string[] encodedTypes = this.PropertyTypes.Select(pt => pt.ToString().ToLower() + "s").ToArray();
                return string.Join("-y-", encodedTypes);
            }
        }

        protected string EncodedTransactionType => 
            this.TransactionType.ToString().ToLower();


        protected string EncodedDepartment => 
            this.Department.ToLower();

        protected string EncodedCitiesAndNeighbourhoods =>
            this.CitiesAndNeighbourhoods == null ? "" : string.Join("-y-en-", this.CitiesAndNeighbourhoods);
        
    }

}