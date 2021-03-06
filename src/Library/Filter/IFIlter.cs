
namespace Library
{
    public interface IFilter
    {
        /// <summary>
        /// Buscamos crear cada filtro de manera individual ya que
        /// no comparten datos entre ellos para de esta forma
        /// encapsular la información y utilizar solo los que
        /// sean necesarios para el caso.

        /// Cada filtro, respeta SRP dado que tiene una única razón
        /// para su cambio, esta es, cuando se modifican sus atributos.
        /// </summary>
        /// <returns></returns>
        
        string Value { get; }
    }
}