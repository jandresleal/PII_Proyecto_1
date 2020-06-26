/*
using NUnit.Framework;
using System.Collections.Generic;

namespace Library.Test
{
    public class TestsSimpleInterpreter
    {
        /// <summary>
        /// Test para la clase SimpleInterpreter
        /// </summary>
        [Test]
        public void TestParseInputMultiplesFiltros()
        {
            IMediator mediator = new Mediator();

            Database database = new Database();

            IInterpreter interpreter = new SimpleInterpreter();

            // IChannelAdapter adapter = new TelegramAdapter();

            // se debe setear una api dado que luego de crear filtros
            // satisfactoriamente, se envía un mensaje el mediator
            // para que se ejecute el método Search
            // el cual, requiere de una API seteada en la database.

            IAPIsSearchEngines api = new APIInfoCasas();

            database.SetAPI(api);

            interpreter.ParseInput("price-10-20,Rooms-2,Baths-1,buceo,habitableArea-102,area-150", database);

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
        
        [Test]
        public void TestParseInputUnFiltro()
        {
            IMediator mediator = new Mediator();

            Database database = new Database();

            IInterpreter interpreter = new SimpleInterpreter();

            IAPIsSearchEngines api = new APIInfoCasas();

            database.SetAPI(api);

            interpreter.ParseInput("gym", database);

            GymFilter gymFilter = new GymFilter(true);

            Assert.AreEqual(database.GetFilters()[0].GetValues().GetHashCode(), gymFilter.GetValues().GetHashCode());
        }

        [Test]
        public void TestParseInputSinFiltros()
        {
            IMediator mediator = new Mediator();

            Database database = new Database();

            IInterpreter interpreter = new SimpleInterpreter();

            // IChannelAdapter adapter = new TelegramAdapter();

            // se debe setear un adapter dado que el método ParseInput
            // en ausencia de filtros, llama al método
            // SendInfoToAdapter(string question, Database database)
            // con el fin de devolver que no encontró parámetros
            // de búsqueda válidos
            
            // database.SetAdapter(adapter);

            // en caso de no fallar como en los tests anteriores, se llama
            // al mediador también pero para realizar el search
            // en base a la API que tenga seteada la database

            interpreter.ParseInput("dhhddzcfxf", database);

            List<IFilter> filters = new List<IFilter>();

            Assert.AreEqual(database.GetFilters().Count, filters.Count);
        }
    }
}
*/