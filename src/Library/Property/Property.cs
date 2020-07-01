namespace Library
{
    public class Property : IProperty
    {
        /// <summary>
        /// Aplicamos el patrón Expert y los principios SRP y OCP.
 
        /// Creamos una clase abstracta Property de tipo IProperty dado que no queremos
        /// que haya una instancia de Property pero si que clases que comparten comportamiento
        /// puedan heredar y sobrescribir solamente el código necesario. De esta manera se
        /// reutiliza código y se mantiene un código extensible, por ende cumple con OCP.

        /// La única responsabilidad de la clase Property es almacenar las características de las
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
    }
}