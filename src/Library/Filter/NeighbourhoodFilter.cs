using System;

namespace Library
{
    public class NeighbourhoodFilter : IFilter
    {
        /// <summary>
        /// Filtro independiente creado únicamente para Neighbourhood
        
        /// Cada filtro, respeta SRP dado que tiene una única razón
        /// para su cambio, cuando se modifican sus atributos.
        /// </summary>
        
        public string Value { get; }

        public NeighbourhoodFilter(string value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            return obj is NeighbourhoodFilter a ? a.Value == Value : base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}