namespace Library
{
    public interface IProperty
    {
        /// <summary>
        /// Esta interfaz tiene como única responsabilidad de almacenar los datos correspondientes de cada propiedad,
        /// entonces su única razón de cambio es si se la agregan o modifican atributos,
        /// por lo tanto, cumple con el principio SRP y a su vez sigue el patrón Expert porque se le
        /// asigna la responsabilidad a la clase que tiene toda la información necesaria.
        /// </summary>
        /// <value></value>
        
        string Title { get; }

        string Description { get; }

        string Price { get; }

        string Expenses { get; }

        string Neighbourhood { get; }

        string ImagePath { get; }

        string ResultPath { get; }
    }
}