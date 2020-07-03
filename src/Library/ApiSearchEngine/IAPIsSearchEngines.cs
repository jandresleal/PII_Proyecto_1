using System.Collections.Generic;

namespace Library
{
    public interface IAPIsSearchEngines
    {
        /// <summary>
        /// Esta interfaz es la encargada de que cualquier API de búsqueda con la que
        /// pueda llegar a integrarse la plataforma, implemente las mismas operaciones
        /// para no verse afectados por la expansión de las integraciones ni por cambios
        /// en las APIs.
        ///
        /// Esta interfaz respeta el principio SRP, tiene una única razón de cambio, esta sería
        /// que cambiara la forma en la que se integran las APIs.
        /// Permite además la expansión a diferentes APIs aplicando el principio polymorphic,
        /// ya que es independiente de ellas, y permite que se cumpla LSP ya que las APIs no
        /// deberían interferir entre sí, alterando los resultados esperados.
        /// 
        /// Además, como se mencionará también en APIInfoCasas, está pensado que las clases
        /// que implementan esta interfaz sigan el patrón creator al ser las encargadas
        /// de instanciar las propiedades porque conocen la información necesaria para ello
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        
        void AskAPI(List<IFilter> filters, long id);
    }
}