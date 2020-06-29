namespace Library
{
    public interface IProperty
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        /// 
        
        string Title { get; }

        string Description { get; }

        int Price { get; }

        int Expenses { get; }

        string Neighbourhood { get; }

        string ImagePath { get; }

        string ResultPath { get; }
    }
}