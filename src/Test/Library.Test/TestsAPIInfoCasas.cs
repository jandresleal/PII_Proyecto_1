using NUnit.Framework;

namespace Library.Test
{
    public class TestAPIInfoCasas
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestParse()
        {
            IMediator mediator = new Mediator();

            Database database = new Database(); 

            IAPIsSearchEngines api = new APIInfoCasas();

            string data = $"120000,aires puros,2,1,102,140,true,true,false,true,false-85000,pajas blancas,3,2,149,201,false,true,false,false,false";

            IProperty property1 = new Property(120000,"aires puros",2,1,102,140,true,true,false,true,false);

            IProperty property2 = new Property(85000,"pajas blancas",3,2,149,201,false,true,false,false,false);

            api.Parse(data,mediator,database);

            Assert.AreEqual(database.GetPropertyList()[0].GetPropertyValues().GetHashCode(),property1.GetPropertyValues().GetHashCode());
            Assert.AreEqual(database.GetPropertyList()[1].GetPropertyValues().GetHashCode(),property2.GetPropertyValues().GetHashCode());
        }
    }
}