using System.Diagnostics;

namespace Library
{
    public class Mediator : IMediator
    {
        /// <summary>
        /// Es la clase encargada de implementar el Mediator
        /// Explicamos las razones de su uso en la interfaz IMediator
        /// </summary>
        /// <param name=></param>
        public Mediator() {  }

        public void AddFilter(IFilter filter, Database database)
        {
                database.AddFilter(filter);
        }

        public void AddProperty(IProperty property, Database database)
        {
            database.AddProperty(property);
        }

        public void Search(Database database)
        {
            try
            {
                database.API.AskAPI(database.GetFilters(), database.UserID);
            }
            catch (System.NullReferenceException e)
            {
                // Podría lanzarse esta excepción al llamar a la instancia almacenada
                // en la propiedad API de database. Si bien esta se crea
                // en el constructor, el sistema permite, en caso de implementar otra api
                // hacer el set sin tener esa propiedad hardcoded (como pasa en adapter)
                // Al momento de la implementación, esto ocurrió (no estaba hardcoded)
                // y como es un fallo del que nos podemos recuperar, hacemos el catch
                // de la excepción regenerando la única api implementada API 
                // y continuando el curso normal de la aplicación

                Debug.WriteLine(e.Message + database.UserID);

                database.SetAPI(SingleInstance<APIInfoCasas>.GetInstance);

                database.API.AskAPI(database.GetFilters(), database.UserID);
            } 
        }

        public void CreateTextToPrint(IPrintFormatter formatter, Database database)
        {
          formatter.FormatMessage(database.GetPropertyList(), database.UserID);
        }

        public void SendInfoToAdapter(long id, string input)
        {
            try
            {
                SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).Adapter.SendTextToUser(id, input);
            }
            catch (System.NullReferenceException e)
            {
                // Podría lanzarse esta excepción al llamar a la instancia almacenada
                // en la propiedad Adapter de database. El sistema permite, distintos adapters,
                // hasta el momento con dos integrados (telegram y consola). Para que funcione
                // este método, el set realizado en el adapter a la database debe ser satisfactorio
                // como la database puede ser instanciada sin un adapter, esto puede fallar.
                // Sin embargo, es un fallo del que nos podemos recuperar, ya que el ID de console
                // es siempre 1, por lo cual, a continuación, nos recuperamos del eventual fallo
                // y continuamos el curso normal de la aplicación

                Debug.WriteLine(e.Message + id);

                if (id == 1)
                {
                    SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).SetAdapter(SingleInstance<ConsoleChannel>.GetInstance);
                }
                else
                {
                    SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).SetAdapter(SingleInstance<TelegramBot>.GetInstance);
                }
            }      
        }

        public void SetState(long id, Status state)
        {
            SingleInstance<SimpleInterpreter>.GetInstance.SetState(id, state);
        }
    }
}