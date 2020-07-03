using NUnit.Framework;
using System;

namespace Library.Test
{
    public class TestsNeighbourhoodFilter
    {
        /// <summary>
        /// Test para la clase DepartmentFilter
        /// </summary>
        
        [Test]
        public void TestEqualsTrue()
        {
            IFilter filter1 = new NeighbourhoodFilter("buceo");
            IFilter filter2 = new NeighbourhoodFilter("buceo");

            Assert.IsTrue(filter1.Equals(filter2));
        }

        [Test]
        public void TestEqualsFalse()
        {
            IFilter filter1 = new NeighbourhoodFilter("parque batlle");
            IFilter filter2 = new NeighbourhoodFilter("buceo");

            Assert.IsFalse(filter1.Equals(filter2));
        }

        [Test]
        public void TestEqualsNullException()
        {
            IFilter filter1 = new NeighbourhoodFilter("carrasco norte");
            IFilter filter2 = null;

            // el test pasa dado que nunca se llega al Assert.Fail (el equals lanza excepción)
            // y se hace el catch del tipo correcto (NullReferenceException)
            try
            {
                filter1.Equals(filter2);
                Assert.Fail();
            }
            catch (NullReferenceException)
            {
                
            }
        }
    }
}