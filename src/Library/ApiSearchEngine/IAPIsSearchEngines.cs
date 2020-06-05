using System.Collections.Generic;

namespace Library
{
    public interface IAPIsSearchEngines
    {
        /// <summary>
        /// Este elemento busca ser un Expert en el manejo de las APIs para comunicarse
        /// con el Mediator, y tener una única razón de cambio, siguiendo SRP. 
        /// Permite además la expansión a diferentes APIs aplicando el principio polymorphic,
        /// ya que es independiente de ellas, y permitiría que se cumpla LSP ya que las APIs no
        /// interfieran entre sí, alterando los resultados esperados.
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        
        string AskAPI(List<IFilter> filters);

        void Parse(string data, IMediator mediator, Database database);
    }
}