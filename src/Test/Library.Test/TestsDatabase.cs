using NUnit.Framework;

namespace Library.Test
{
    public class TestDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestAddPriceFilter()
        {
            Database database = new Database();

            database.AddPriceFilter(10,50);

            IFilter filter = new PriceFilter(10,50);

            Assert.AreEqual(database.GetFilters()[0].GetValues().GetHashCode(), filter.GetValues().GetHashCode());
        }

        [Test]
        public void TestAddNeighbourhoodFilter()
        {
            Database database = new Database();

            database.AddNeighbourhoodFilter("aires puros");

            IFilter filter = new NeighbourhoodFilter("aires puros");

            Assert.AreEqual(database.GetFilters()[0].GetValues().GetHashCode(), filter.GetValues().GetHashCode());            
        }

        [Test]
        public void TestAddRoomsFilter()
        {
            Database database = new Database();

            database.AddRoomsFilter(3);

            IFilter filter = new RoomsFilter(3);

            Assert.AreEqual(database.GetFilters()[0].GetValues().GetHashCode(), filter.GetValues().GetHashCode());
        }

        [Test]
        public void TestAddBathsFilter()
        {
            Database database = new Database();

            database.AddBathsFilter(2);

            IFilter filter = new BathsFilter(2);

            Assert.AreEqual(database.GetFilters()[0].GetValues().GetHashCode(), filter.GetValues().GetHashCode());
        }

        [Test]
        public void TestAddHabitableAreaFilter()
        {
            Database database = new Database();

            database.AddHabitableAreaFilter(68.2);

            IFilter filter = new HabitableAreaFilter(68.2);

            Assert.AreEqual(database.GetFilters()[0].GetValues().GetHashCode(), filter.GetValues().GetHashCode());
        }

        [Test]
        public void TestAddAreaFilter()
        {
            Database database = new Database();

            database.AddAreaFilter(42.987);

            IFilter filter = new AreaFilter(42.987);

            Assert.AreEqual(database.GetFilters()[0].GetValues().GetHashCode(), filter.GetValues().GetHashCode());
        }

        [Test]
        public void TestAddGarageFilter()
        {
            Database database = new Database();

            database.AddGarageFilter(false);

            IFilter filter = new GarageFilter(false);

            Assert.AreEqual(database.GetFilters()[0].GetValues().GetHashCode(), filter.GetValues().GetHashCode());
        }

        [Test]
        public void TestAddGardenFilter()
        {
            Database database = new Database();

            database.AddGardenFilter(true);

            IFilter filter = new GarageFilter(true);

            Assert.AreEqual(database.GetFilters()[0].GetValues().GetHashCode(), filter.GetValues().GetHashCode());
        }

        [Test]
        public void TestAddSwimmingPoolFilter()
        {
            Database database = new Database();

            database.AddSwimmingPoolFilter(true);

            IFilter filter = new SwimmingPoolFilter(true);

            Assert.AreEqual(database.GetFilters()[0].GetValues().GetHashCode(), filter.GetValues().GetHashCode());
        }

        [Test]
        public void TestAddBarbecueFilter()
        {
            Database database = new Database();

            database.AddBarbecueFilter(true);

            IFilter filter = new BarbecueFilter(true);

            Assert.AreEqual(database.GetFilters()[0].GetValues().GetHashCode(), filter.GetValues().GetHashCode());
        }

        [Test]
        public void TestAddGymFilter()
        {
            Database database = new Database();

            database.AddGymFilter(false);

            IFilter filter = new GymFilter(false);

            Assert.AreEqual(database.GetFilters()[0].GetValues().GetHashCode(), filter.GetValues().GetHashCode());
        }
    }
}