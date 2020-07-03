using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Test
{
    public class TestsSimpleInterpreter
    {
        /// <summary>
        /// Test para la clase SimpleInterpreter
        /// Ejecutar los tests de a uno, por alguna razón con el run All tests hay 2 que fallan
        /// Siempre que se ejecuta de a uno, pasan correctamente.
        /// PD: Es rarísimo
        /// </summary>
        [Test]
        public void TestParseInputMultiplesFiltros()
        {
            Database database = SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(1);
            IInterpreter interpreter = new SimpleInterpreter();
            
            // se la crea para setearla en la database debido a que eso solo se realiza de forma
            // automática en el programa al recibir mensajes
            ConsoleChannel console = new ConsoleChannel();

            database.SetAdapter(console);

            TransactionTypeFilter transactionTypeFilter = new TransactionTypeFilter("compra");
            DepartmentFilter departmentFilter = new DepartmentFilter("canelones");
            PropertyTypeFilter propertyTypeFilter = new PropertyTypeFilter("casa");

            List<IFilter> filters = new List<IFilter>();

            filters.Add(transactionTypeFilter);
            filters.Add(departmentFilter);
            filters.Add(propertyTypeFilter);

            database.SetState(Status.WaitingTransactionType);
            interpreter.ParseInput(1, "2");
            interpreter.ParseInput(1, "canelones");
            interpreter.ParseInput(1, "1");

            Assert.IsTrue(database.GetFilters().SequenceEqual(filters));
        }

        [Test]
        public void TestParseInputUnFiltro()
        {
            Database database = SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(1);
            IInterpreter interpreter = new SimpleInterpreter();
            
            // se la crea para setearla en la database debido a que eso solo se realiza de forma
            // automática en el programa al recibir mensajes
            ConsoleChannel console = new ConsoleChannel();

            database.SetAdapter(console);

            TransactionTypeFilter transactionTypeFilter = new TransactionTypeFilter("compra");

            List<IFilter> filters = new List<IFilter>();

            filters.Add(transactionTypeFilter);

            database.SetState(Status.WaitingTransactionType);
            interpreter.ParseInput(1, "2");

            Assert.IsTrue(database.GetFilters().SequenceEqual(filters));
        }

        [Test]
        public void TestParseInputSinFiltros()
        {
            Database database = SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(1);
            IInterpreter interpreter = new SimpleInterpreter();
            
            // se la crea para setearla en la database debido a que eso solo se realiza de forma
            // automática en el programa al recibir mensajes
            ConsoleChannel console = new ConsoleChannel();

            database.SetAdapter(console);

            List<IFilter> filters = new List<IFilter>();

            database.SetState(Status.Init);
            interpreter.ParseInput(1, "5486156@éssaf");
            database.SetState(Status.WaitingTransactionType);
            interpreter.ParseInput(1, "hfthfhjfjy");
            database.SetState(Status.WaitingDepartment);
            interpreter.ParseInput(1, "64<68g<sg");
            database.SetState(Status.WaitingPropertyType);
            interpreter.ParseInput(1, "uw<bnuw<g**546");

            Assert.IsTrue(database.GetFilters().SequenceEqual(filters));
        }
    }
}