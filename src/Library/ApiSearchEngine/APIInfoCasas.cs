using System;
using System.Collections.Generic;

namespace Library.ApiSearchEngine
{
    public class APIInfoCasas : IAPIsSearchEngines
    {
        public string AskAPI(List<IFilter> filters)
        {
            string ask = string.Empty;

            foreach (IFilter filter in filters)
            {
                // el método get values devuelve un string con el valor de cada atributo del filtro
                // en este caso como no sabemos cómo tenemos que pedir la información
                // simplemente 
                ask += filter.GetValues();
            }
            // aquí preguntaríamos a la api en base al ask creado




            // una vez recibida la respuesta
            // devolvemos la string que nos retorne la API
            string answer = string.Empty;
            return answer;
        }


        // el método parse a continuación es llamado por el mediator y
        // en la práctica recibe el string retornado por la API
        public List<IProperty> Parse(string data)
        {
            List<IProperty> properties = new List<IProperty>();

            string[] objects = data.Split(@"/n");

            foreach (string x in objects)
            {
                string[] atributes = x.Split(",");
                properties.Add(new Property(
                    atributes[0],
                    Int32.Parse(atributes[1]),
                    Int32.Parse(atributes[2]),
                    double.Parse(atributes[3]),
                    double.Parse(atributes[4]),
                    bool.Parse(atributes[5]),
                    bool.Parse(atributes[6]),
                    bool.Parse(atributes[7]),
                    bool.Parse(atributes[8]),
                    bool.Parse(atributes[9])
                ));
            }
            return properties;
        }
    }
}