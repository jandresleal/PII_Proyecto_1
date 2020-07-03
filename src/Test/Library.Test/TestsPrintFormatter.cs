using NUnit.Framework;
using System.Collections.Generic;

namespace Library.Test
{
    public class TestsPrintFormatter
    {
        /// <summary>
        /// Tests para PrintFormatter
        /// Hay que destacar que PrintFormatter devuelve un string solo para que sea testeable
        /// pero queremos aclarar que este no es lo que se le va enviando al usuario.
        /// Las llamadas al mediator para enviar información al usuario se hacen
        /// por cada property que se va instanciando para que al usuario le lleguen
        /// mensajes completos de cada propiedad. Esto se realizó dado que telegram
        /// no te deja enviar un mensaje muy grande ni muchas fotos en el mismo mensaje
        /// (al menos no nos dejó a nosotros)
        /// </summary>
        [Test]
        public void TestFormatMessageVacio()
        {
            IPrintFormatter printFormatter = new PrintFormatter();

            List<IProperty> properties = new List<IProperty>();

            Assert.AreEqual(printFormatter.FormatMessage(properties, 1), string.Empty);
        }

        [Test]
        public void TestFormatMessageCon1Property()
        {
            IPrintFormatter printFormatter = new PrintFormatter();

            List<IProperty> properties = new List<IProperty>();

            IProperty property = new Property("Casa en la playa", "Hermosa casa", "$500", "$10", "Buceo", "infocasas", "infocasas");

            properties.Add(property);

            string result = "https://infocasas.com.uyinfocasas\r\ninfocasas\r\nCasa en la playa Hermosa casa Se encuentra en el barrio Buceo y su precio es de $500 Tiene unos gastos fijos mensuales de $10.";

            Assert.AreEqual(printFormatter.FormatMessage(properties, 1), result);
        }

        [Test]
        public void TestFormatMessageConMultiplesProperties()
        {
            IPrintFormatter printFormatter = new PrintFormatter();

            List<IProperty> properties = new List<IProperty>();

            IProperty property1 = new Property("Bienvenido a la playa", "Hermosa vida", "$900", "$10", "Carrasco", "infocasas", "infocasas");
            IProperty property2 = new Property("Apartamento en la playa", "Hermoso apartamento", "$800", "$10", "Buceo", "infocasas", "infocasas");
            IProperty property3 = new Property("Casa en la playa", "Hermosa casa", "$500", "$10", "Pajas Blancas", "infocasas", "infocasas");

            properties.Add(property1);
            properties.Add(property2);
            properties.Add(property3);

            string result = "https://infocasas.com.uyinfocasas\r\ninfocasas\r\nCasa en la playa Hermosa casa Se encuentra en el barrio Pajas Blancas y su precio es de $500 Tiene unos gastos fijos mensuales de $10.";

            Assert.AreEqual(printFormatter.FormatMessage(properties, 1), result);
        }

        [Test]
        public void TestPathContainsHttp()
        {
            PrintFormatter printFormatter = new PrintFormatter();

            string path = "https://infocasas.com.uyinfocasas\r\ninfocasas";

            Assert.IsTrue(printFormatter.PathContainsHttp(path));
        }

        [Test]
        public void TestPathNotContainsHttp()
        {
            PrintFormatter printFormatter = new PrintFormatter();

            string path = "hola!";

            Assert.IsFalse(printFormatter.PathContainsHttp(path));
        }

        [Test]
        public void TestVariableReplace()
        {
            PrintFormatter printFormatter = new PrintFormatter();

            string input = "hola!";
            string toReplace = "!";

            Assert.AreEqual(printFormatter.VariableReplace(input, toReplace), "hola");
        }
    }
}