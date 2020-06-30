using NUnit.Framework;

namespace Library.Test
{
    public class TestPriceFilter
    {
        /// <summary>
        /// Test para la clase PriceFilter
        /// Decidimos hacer test únicamente para este filtro porque es el único
        /// que tiene más de un método y realiza operaciones con los atributos que se ingresan por parámetro
        /// </summary>
        /// 
        [Test]
        public void TestGetValues()
        {
            // PriceFilter filter = new PriceFilter(10,50);
            // Assert.AreEqual("10,50", filter.GetValues());
        }
        /// <summary>
        /// Se establece si el cálculo del rango extendido es correcto
        /// El rango extendido devuelve un string con el 80% del valor mínimo y un 25% más que el valor máximo ingresado,
        /// ambos valores separados por ","
        /// </summary>
        [Test]
        public void TestCalculateExtendedRange()
        {
            // PriceFilter filter = new PriceFilter(10,50);
            // string result = filter.CalculateExtendedRange(10,50);

            // Assert.AreEqual("8,62", result);
        }
        
    }
}