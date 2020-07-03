using System;

namespace Library
{
    public class PropertyTypeFilter : IFilter
    {
        /// <summary>
        /// Esta clase implementa la interfaz IFilter, tiene como única responsabilidad almacenar el filtro correspondiente
        /// al Tipo de propiedad, por ende, cumple con el principio SRP.
        /// El tipo de propiedad se refiere a si es una casa o apartamento.
        /// </summary>
        /// <value></value>
        public string Value { get; }

        public PropertyTypeFilter(string value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            return obj is PropertyTypeFilter a ? a.Value == Value : base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}