using System;

namespace Library
{
    public class TransactionTypeFilter : IFilter
    {
        /// <summary>
        /// Esta clase implementa la interfaz IFilter, tiene como única responsabilidad almacenar el filtro correspondiente
        /// al tipo de transacción, por ende, cumple con el principio SRP.
        /// Con el tipo de transacción nos referimos a la compra o alquiler de propiedades.
        /// </summary>
        /// <value></value>
        public string Value { get; private set; }

        public TransactionTypeFilter(string value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            return obj is TransactionTypeFilter a ? a.Value == Value : base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}