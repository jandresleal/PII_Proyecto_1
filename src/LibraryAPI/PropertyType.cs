namespace PII_ICApi
{
    public enum PropertyType
    {
        Casa,
        Apartamento
    }

    static class PropertyTypeExtensions
    {
        public static PropertyType? FromString(string type)
        {
            switch(type.ToLower())
            {
                case "casa":
                case "casas":
                    return PropertyType.Casa;

                case "apartamento":
                case "apartamentos":
                    return PropertyType.Apartamento;
            }

            return null;
        }
    }
}