using System;

namespace Library
{
    public class PropertyTypeFilter : IFilter
    {
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