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

        string Price { get; }

        string Expenses { get; }

        string Neighbourhood { get; }

        string ImagePath { get; }

        string ResultPath { get; }
    }
}