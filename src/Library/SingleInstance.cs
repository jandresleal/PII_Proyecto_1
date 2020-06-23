namespace Library

{
    public class SingleInstance<T> where T : new()
    {
        private static T instance;

        public static T GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }
                return instance; 
            }
        }
    }
}