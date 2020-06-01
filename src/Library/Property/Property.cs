namespace Library
{
    
/*
Aplicamos el patrón Expert y los principios SRP y OCP.
 
Creamos una clase abstracta Property de tipo IProperty dado que no queremos
que haya una instancia de Property pero si que clases que comparten comportamiento
puedan heredar y sobrescribir solamente el código necesario. De esta manera se
reutiliza código y se mantiene un código extensible, por ende cumple con OCP.

La única responsabilidad de la clase Property es almacenar las características de las
propiedades, entonces su única razón de cambio es si se la agregan o modifican atributos,
por lo tanto cumple con el principio SRP y a su vez sigue el patrón Expert porque se le
asigna la responsabilidad a la clase que tiene toda la información necesaria.
*/

    public class Property : IProperty
    {
        public string Neighborhood { get; set; }
        public int Rooms { get; set; }
        public int Baths { get; set; }
        public double HabitableArea { get; set; }
        public double Area { get; set; }
        public bool Garage { get; set; }
        public bool Garden { get; set; }
        public bool SwimmingPool { get; set; }
        public bool Barbecue { get; set; }
        public bool Gym { get; set; }

        public Property(string neighborhood, int rooms, int baths, double habitableArea, double area, bool garage, bool garden, bool swimmingPool, bool barbecue, bool gym)
        {
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
