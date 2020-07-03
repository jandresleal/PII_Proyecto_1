using NUnit.Framework;
using System;

namespace Library.Test
{
    public class TestsProperty
    {
        /// <summary>
        /// Test para la clase DepartmentFilter
        /// </summary>
        
        [Test]
        public void TestEqualsTrue()
        {
            IProperty property = new Property("Casa en la playa", "Hermosa casa", "$500", "$10", "Buceo", "infocasas", "infocasas");
            IProperty property2 = new Property("Casa en la playa", "Hermosa casa", "$500", "$10", "Buceo", "infocasas", "infocasas");

            Assert.IsTrue(property.Equals(property2));
        }

        [Test]
        public void TestEqualsFalse()
        {
            IProperty property = new Property("Casa en la playa", "Hermosa casa", "$500", "$10", "Buceo", "infocasas", "infocasas");
            IProperty property2 = new Property("Casa en la playa", "YRYUJFJ", "$500", "$10", "Buceo", "infocasas", "infocasas");

            Assert.IsFalse(property.GetHashCode().Equals(property2.GetHashCode()));
        }

        [Test]
        public void TestEqualsNullException()
        {
            IProperty property = new Property("Casa en la playa", "Hermosa casa", "$500", "$10", "Buceo", "infocasas", "infocasas");
            IProperty property2 = null;
            // el test pasa dado que nunca se llega al Assert.Fail (el equals lanza excepción)
            // y se hace el catch del tipo correcto (NullReferenceException)
            try
            {
                property.Equals(property2);
                Assert.Fail();
            }
            catch (NullReferenceException)
            {
                
            }
        }
    }
}