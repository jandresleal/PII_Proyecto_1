using System.Collections.Generic;

namespace Library
{
    public interface IPrintFormatter
    {
        /// <summary>
        /// Esta interfaz se encargada de definir un tipo que posteriormente
        /// puede ser implementado por múltiples clases.
        /// Su objetivo es realizar un formateo del mensaje, realizando modificaciones y
        /// que el usuario pueda elegir el más conveniente para sí.
        /// Se define la operación FormatMessage(List<IProperty> data, long id) que será polimórfica
        /// dado que su resultado dependerá de las clases que implementen esta operación. 
        /// Se sigue el patrón polymorphism.
        /// Como esta operación al ser implementada por varias clases no debería de producir 
        /// efectos colaterales, se respeta el principio LSP al crear 
        /// posibles múltiples clases que implementen esta interfaz.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string FormatMessage(List<IProperty> data, long id);
    }
}