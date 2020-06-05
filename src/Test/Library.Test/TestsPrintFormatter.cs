using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Library.Test
{
    public class TestsPrintFormatter
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestFormatMessageVacio()
        {
            IPrintFormatter printFormatter = new PrintFormatter();

            List<IProperty> properties = new List<IProperty>();

            string result = "No se encontraron propiedades que satisfagan la búsqueda.";

            Assert.AreEqual(printFormatter.FormatMessage(properties),result);
        }

        [Test]
        public void TestFormatMessageCon1Property()
        {
            IPrintFormatter printFormatter = new PrintFormatter();

            List<IProperty> properties = new List<IProperty>();

            IProperty property = new Property(85000,"pajas blancas",3,2,149,201,false,true,false,false,false);

            properties.Add(property);

            string result = "Se listan las propiedades a continuación" + Environment.NewLine;

            result += $"La propiedad se encuentra en el barrio {property.Neighbourhood} y cuenta con: {property.Rooms} dormitorios, {property.Baths} baños, cuenta con {property.HabitableArea} metros cuadrados construidos y su terreno consiste de {property.Area} metros cuadradros.";

            result += " Además, presenta un jardín ideal para unas tardes tomando mate.";

            Assert.AreEqual(printFormatter.FormatMessage(properties), result);
        }

        [Test]
        public void TestFormatMessageConMultiplesProperties()
        {
            IPrintFormatter printFormatter = new PrintFormatter();

            List<IProperty> properties = new List<IProperty>();

            IProperty property1 = new Property(85000,"pajas blancas",3,2,149,201,false,true,false,false,false);

            IProperty property2 = new Property(120000,"aires puros",2,1,102,140,true,true,false,true,false);

            properties.Add(property1);

            properties.Add(property2);

            string result = "Se listan las propiedades a continuación" + Environment.NewLine;

            result += $"La propiedad se encuentra en el barrio {property1.Neighbourhood} y cuenta con: {property1.Rooms} dormitorios, {property1.Baths} baños, cuenta con {property1.HabitableArea} metros cuadrados construidos y su terreno consiste de {property1.Area} metros cuadradros.";

            result += " Además, presenta un jardín ideal para unas tardes tomando mate.";

            result += Environment.NewLine;

            result += $"La propiedad se encuentra en el barrio {property2.Neighbourhood} y cuenta con: {property2.Rooms} dormitorios, {property2.Baths} baños, cuenta con {property2.HabitableArea} metros cuadrados construidos y su terreno consiste de {property2.Area} metros cuadradros.";

            result += " Para su comodidad, la propiedad incluye garage.";

            result += " A su vez, esta propiedad cuenta con barbacoa.";

            result += " Además, presenta un jardín ideal para unas tardes tomando mate.";

            Assert.AreEqual(printFormatter.FormatMessage(properties), result);
        }
    }
}