using NUnit.Framework;
using System;

namespace Library.Test
{
    public class TestsPropertyTypeFilter
    {
        /// <summary>
        /// Test para la clase PropertyTypeFilter
        /// </summary>
        
        [Test]
        public void TestEqualsTrue()
        {
            IFilter filter1 = new PropertyTypeFilter("casa");
            IFilter filter2 = new PropertyTypeFilter("casa");

            Assert.IsTrue(filter1.Equals(filter2));
        }

        [Test]
        public void TestEqualsFalse()
        {
            IFilter filter1 = new PropertyTypeFilter("casa");
            IFilter filter2 = new PropertyTypeFilter("apartamento");

            Assert.IsFalse(filter1.Equals(filter2));
        }

        [Test]
        public void TestEqualsNullException()
        {
            IFilter filter1 = new PropertyTypeFilter("casa");
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