using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Library.Test
{
    public class TestsSimpleInterpreter
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestParseInputMultiplesFiltros()
        {
            IMediator mediator = new Mediator();

            Database database = new Database();

            IInterpreter interpreter = new SimpleInterpreter();

            interpreter.ParseInput("price-10-20,Rooms-2,Baths-1,buceo,habitableArea-102,area-150", mediator, database);

            PriceFilter priceFilter = new PriceFilter(10,20);
            RoomsFilter roomsFilter = new RoomsFilter(2);
            BathsFilter bathsFilter = new BathsFilter(1);
            NeighbourhoodFilter neighbourhoodFilter = new NeighbourhoodFilter("Buceo");
            HabitableAreaFilter habitableArea = new HabitableAreaFilter(102);
            AreaFilter areaFilter = new AreaFilter(150);

            Assert.AreEqual(database.GetFilters()[0].GetValues().GetHashCode(), priceFilter.GetValues().GetHashCode());
            Assert.AreEqual(database.GetFilters()[1].GetValues().GetHashCode(), roomsFilter.GetValues().GetHashCode());
            Assert.AreEqual(database.GetFilters()[2].GetValues().GetHashCode(), bathsFilter.GetValues().GetHashCode());
            Assert.AreEqual(database.GetFilters()[3].GetValues().GetHashCode(), neighbourhoodFilter.GetValues().GetHashCode());
            Assert.AreEqual(database.GetFilters()[4].GetValues().GetHashCode(), habitableArea.GetValues().GetHashCode());
            Assert.AreEqual(database.GetFilters()[5].GetValues().GetHashCode(), areaFilter.GetValues().GetHashCode());
        }
    }
}