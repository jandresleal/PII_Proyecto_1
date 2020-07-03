using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Library.Test
{
    public class TestDatabase
    {
        /// <summary>
        /// Aquí se realizan los tests correspondientes a Database
        /// </summary>
        
        [Test]
        public void TestAddFilter()
        {
            Database database = new Database(1);

            database.AddFilter(new PropertyTypeFilter("casa"));

            IFilter filter = new PropertyTypeFilter("casa");

            Assert.IsTrue(database.GetFilters()[0].Equals(filter));
        }

        [Test]
        public void TestAddProperty()
        {
            Database database = new Database(1);

            database.AddProperty(new Property("Casa en la playa", "Hermosa casa", "$500", "$10", "Buceo", "infocasas", "infocasas"));

            IProperty property = new Property("Casa en la playa", "Hermosa casa", "$500", "$10", "Buceo", "infocasas", "infocasas");

            Assert.IsTrue(database.GetPropertyList()[0].Equals(property));
        }

        [Test]
        public void TestStateInicial()
        {
            Database database = new Database(1);

            Status state = Status.Init;

            Assert.AreEqual(database.State, state);
        }

        [Test]
        public void TestSetState()
        {
            Database database = new Database(1);

            Status state = Status.WaitingDepartment;

            database.SetState(state);

            Assert.AreEqual(database.State, state);
        }

        [Test]
        public void TestSetAdapter()
        {
            Database database = new Database(1);

            IChannelAdapter adapter = new ConsoleChannel();

            database.SetAdapter(adapter);

            Assert.AreEqual(database.Adapter, adapter);
        }

        [Test]
        public void TestGetFilters()
        {
            Database database = new Database(1);

            List<IFilter> filters = new List<IFilter>();
            
            database.AddFilter(new PropertyTypeFilter("casa"));
            database.AddFilter(new NeighbourhoodFilter("axh"));
            database.AddFilter(new DepartmentFilter("fsgf"));

            IFilter filter1 = new PropertyTypeFilter("casa");
            IFilter filter2 = new NeighbourhoodFilter("axh");
            IFilter filter3 = new DepartmentFilter("fsgf");

            filters.Add(filter1);
            filters.Add(filter2);
            filters.Add(filter3);

            Assert.IsTrue(database.GetFilters().SequenceEqual(filters));
        }

        [Test]
        public void TestGetProperties()
        {
            Database database = new Database(1);

            List<IProperty> properties = new List<IProperty>();
            
            database.AddProperty(new Property("Casa en la playa", "Hermosa casa", "$500", "$10", "Pajas Blancas", "infocasas", "infocasas"));
            database.AddProperty(new Property("Apartamento en la playa", "Hermoso apartamento", "$800", "$10", "Buceo", "infocasas", "infocasas"));
            database.AddProperty(new Property("Bienvenido a la playa", "Hermosa vida", "$900", "$10", "Carrasco", "infocasas", "infocasas"));

            IProperty property1 = new Property("Casa en la playa", "Hermosa casa", "$500", "$10", "Pajas Blancas", "infocasas", "infocasas");
            IProperty property2 = new Property("Apartamento en la playa", "Hermoso apartamento", "$800", "$10", "Buceo", "infocasas", "infocasas");
            IProperty property3 = new Property("Bienvenido a la playa", "Hermosa vida", "$900", "$10", "Carrasco", "infocasas", "infocasas");

            properties.Add(property1);
            properties.Add(property2);
            properties.Add(property3);

            Assert.IsTrue(database.GetPropertyList().SequenceEqual(properties));
        }
    }
}
