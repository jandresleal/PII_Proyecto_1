using System.Diagnostics;
using System;

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

        public void AddFilter(IFilter filter, long id)
        {
            SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).AddFilter(filter);
        }

        public void AddProperty(IProperty property, long id)
        {
            SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).AddProperty(property);
        }

        public void Search(long id)
        {
            try
            {
                SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).API.AskAPI(
                    SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).GetFilters(), 
                    id
                );
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

                Debug.WriteLine(e.Message + id);

                SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).SetAPI(SingleInstance<APIInfoCasas>.GetInstance);

                SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).API.AskAPI(
                    SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).GetFilters(), 
                    id
                );
            } 
        }

        public void CreateTextToPrint(long id)
        {
            try
            {  
                SingleInstance<PrintFormatter>.GetInstance.FormatMessage(SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).GetPropertyList(), id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + id);

                // sabemos que puede fallar por null
                // pero queremos que el programa deje de funcionar
                // dado que sería un bug
                throw e;
            }
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

        public void SetAPI(long id, IAPIsSearchEngines api)
        {
            SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).SetAPI(api);
        }

        public void SetAdapter(long id, IChannelAdapter adapter)
        {
            SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id).SetAdapter(adapter);
        }

        public void ToInterpreter(long id, string input)
        {
            SingleInstance<SimpleInterpreter>.GetInstance.ParseInput(id, input);
        }
    }
}