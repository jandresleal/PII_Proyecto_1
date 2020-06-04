using System;
using System.Collections.Generic;

namespace Library
{
    public class APIInfoCasas : IAPIsSearchEngines
    {
        public APIInfoCasas(){  }

        /// <summary>
        /// Este elemento busca ser un Expert en el manejo de las APIs para comunicarse
        /// con el Mediator, y tener una única razón de cambio, siguiendo SRP. 
        /// Permite además la expansión a diferentes APIs aplicando el principio polymorphic,
        /// ya que es independiente de ellas, y permitiría que se cumpla LSP ya que las APIs no
        /// interfieran entre sí, alterando los resultados esperados. 
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public string AskAPI(List<IFilter> filters)
        {
            string ask = string.Empty;

            foreach (IFilter filter in filters)
            {
                // el método get values devuelve un string con el valor de cada atributo del filtro
                // en este caso como no sabemos cómo tenemos que pedir la información
                // simplemente
                if (ask != string.Empty)
                {
                    ask += "," + filter.GetValues();
                }
                else
                {
                    ask += filter.GetValues();
                } 
            }
            // aquí preguntaríamos a la api en base al ask creado




            // una vez recibida la respuesta
            // devolvemos la string que nos retorne la API
            string answer = string.Empty;
            return answer;
        }


        // el método parse a continuación es llamado por el mediator y
        // en la práctica recibe el string retornado por la API
        public void Parse(string data, IMediator mediator, Database database)
        {
            string[] objects = data.Split("-");

            foreach (string x in objects)
            {
                string[] atributes = x.Split(",");
                
                mediator.AddProperty(
                    Int32.Parse(atributes[0]),
                    atributes[1],
                    Int32.Parse(atributes[2]),
                    Int32.Parse(atributes[3]),
                    Int32.Parse(atributes[4]),
                    Int32.Parse(atributes[5]),
                    bool.Parse(atributes[6]),
                    bool.Parse(atributes[7]),
                    bool.Parse(atributes[8]),
                    bool.Parse(atributes[9]),
                    bool.Parse(atributes[10]),
                    database
                );
            }
        }
    }
}