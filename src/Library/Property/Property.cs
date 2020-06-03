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
        public double Price { get; }

        public string Neighborhood { get; }
        
        public int Rooms { get; }

        public int Baths { get; }
        
        public double HabitableArea { get; }

        public double Area { get; }

        public bool Garage { get; }

        public bool Garden { get; }

        public bool SwimmingPool { get; }

        public bool Barbecue { get; }
        
        public bool Gym { get; }

        public Property(double price, string neighborhood, int rooms, int baths, double habitableArea, double area, bool garage, bool garden, bool swimmingPool, bool barbecue, bool gym)
        {
            this.Price = price;
            this.Neighborhood = neighborhood;
            this.Rooms = rooms;
            this.Baths = baths;
            this.HabitableArea = habitableArea;
            this.Area = area;
            this.Garage = garage;
            this.Garden = garden;
            this.SwimmingPool = swimmingPool;
            this.Barbecue = barbecue;
            this.Gym = gym;
        }
    }
}
