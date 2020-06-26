using System;
namespace PII_ICApi
{
    [Serializable]
    public class ICIncompleteUrlException: InvalidOperationException
    {
        public ICIncompleteUrlException(string message)
            :base(message)
        {
        }
    }
}