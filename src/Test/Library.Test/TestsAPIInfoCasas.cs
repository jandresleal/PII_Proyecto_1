using NUnit.Framework;
using PII_ICApi;
using System.Collections.Generic;
using System.Linq;

namespace Library.Test
{
    public class TestAPIInfoCasas
    {
        /// <summary>
        /// Aquí se realizan los tests para la ApiInfoCasas
        /// </summary>
        [Test]
        public void TestAskAndParseAPI()
        {
            Database database = new Database(1);

            Database database2 = new Database (5); 

            APIInfoCasas apiCore = new APIInfoCasas();

            ICApi api = new ICApi();

            api.SetDepartment("montevideo");
            api.SetPropertyTypes(new PropertyType[]{PropertyType.Apartamento});
            api.SetTransactionType(TransactionType.Alquiler);
            api.SetCitiesAndNeighbourhoods(new string[]{"buceo"});

            List<IFilter> filters = new List<IFilter>();

            DepartmentFilter department = new DepartmentFilter("montevideo");
            PropertyTypeFilter propertyTypeFilter = new PropertyTypeFilter("apartamento");
            TransactionTypeFilter transactionTypeFilter = new TransactionTypeFilter("alquiler");
            NeighbourhoodFilter neighbourhoodFilter = new NeighbourhoodFilter("buceo");

            filters.Add(department);
            filters.Add(propertyTypeFilter);
            filters.Add(transactionTypeFilter);
            filters.Add(neighbourhoodFilter);

            apiCore.AskAPI(filters, 1);

            List<ICApiSearchResult> apiResult = api.Search();
            
            apiCore.Parse(apiResult, 5, "buceo");

            Assert.IsTrue(database.GetPropertyList().SequenceEqual(database2.GetPropertyList()));
        }
    }
}