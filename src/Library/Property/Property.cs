using System;

namespace Library
{
    public class Property : IProperty
    {
        /// <summary>
        /// Aplicamos el patrón Expert y el principio SRP.
        ///
        /// La clase Property de tipo IProperty tiene como única responsabilidad almacenar las características de las
        /// propiedades, entonces su única razón de cambio es si se la agregan o modifican atributos,
        /// por lo tanto cumple con el principio SRP y a su vez sigue el patrón Expert porque se le
        /// asigna la responsabilidad a la clase que tiene toda la información necesaria.
        /// </summary>
        /// <value></value>

        public string Title { get; }

        public string Description { get; }

        public string Price { get; }

        public string Expenses { get; }

        public string Neighbourhood { get; }

        public string ImagePath { get; }

        public string ResultPath { get; }
        
        public Property(string title, string description, string price, string expenses, string neighbourhood, string imagePath, string resultPath)
        {
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.Expenses = expenses;
            this.Neighbourhood = neighbourhood;
            this.ImagePath = imagePath;
            this.ResultPath = resultPath;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            return obj is Property & this.Title == Title & this.Description == Description & this.Price == Price & this.Expenses == Expenses & this.Neighbourhood == Neighbourhood & this.ImagePath == ImagePath & this.ResultPath == ResultPath;
        }

        public override int GetHashCode()
        {
            string x = this.Title + this.Description + this.Price + this.Expenses + this.Neighbourhood + this.ImagePath + this.ResultPath;

            return x.GetHashCode();
        }
    }
}