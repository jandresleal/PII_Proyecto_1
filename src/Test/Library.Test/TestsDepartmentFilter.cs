using NUnit.Framework;
using System;

namespace Library.Test
{
    public class TestsDepartmentFilter
    {
        /// <summary>
        /// Test para la clase DepartmentFilter
        /// </summary>
        
        [Test]
        public void TestEqualsTrue()
        {
            IFilter filter1 = new DepartmentFilter("montevideo");
            IFilter filter2 = new DepartmentFilter("montevideo");

            Assert.IsTrue(filter1.Equals(filter2));
        }

        [Test]
        public void TestEqualsFalse()
        {
            IFilter filter1 = new DepartmentFilter("montevideo");
            IFilter filter2 = new DepartmentFilter("canelones");

            Assert.IsFalse(filter1.Equals(filter2));
        }

        [Test]
        public void TestEqualsNullException()
        {
            IFilter filter1 = new DepartmentFilter("artigas");
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