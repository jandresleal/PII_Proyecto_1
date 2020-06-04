using System;
using System.Collections.Generic;

namespace Library
{
    public class APIInfoCasas : IAPIsSearchEngines
    {
        public APIInfoCasas(IMediator mediator)
        {   
            this.mediator = mediator;
        }

        private IMediator mediator;

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
        public List<IProperty> Parse(string data)
        {
            List<IProperty> properties = new List<IProperty>();

            string[] objects = data.Split(@"/n");

            foreach (string x in objects)
            {
                string[] atributes = x.Split(",");
                
                mediator.AddProperty(
                    Int32.Parse(atributes[0]),
                    atributes[1],
                    Int32.Parse(atributes[2]),
                    Int32.Parse(atributes[3]),
                    double.Parse(atributes[4]),
                    double.Parse(atributes[5]),
                    bool.Parse(atributes[6]),
                    bool.Parse(atributes[7]),
                    bool.Parse(atributes[8]),
                    bool.Parse(atributes[9]),
                    bool.Parse(atributes[10])
                );
            }
            return properties;
        }
    }
}