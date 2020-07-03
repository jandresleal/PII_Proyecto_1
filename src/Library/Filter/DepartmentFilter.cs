using System;

namespace Library
{
    public class DepartmentFilter : IFilter
    {
        /// <summary>
        /// Esta clase implementa la interfaz IFilter, tiene como única responsabilidad almacenar
        /// el filtro correspondiente al departamento, por ende, cumple con el principio SRP.
        /// </summary>
        /// <value></value>
        public string Value { get; }

        public DepartmentFilter(string value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            return obj is DepartmentFilter a ? a.Value == Value : base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}