using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem
{
    public class LiteralPropertyDescriptor : PropertyDescriptor
    {
        #region "Fields"

        private LiteralCollection literals = null;
        private int index = -1;
        #endregion

        #region "Constructor"

        public LiteralPropertyDescriptor(LiteralCollection coll, int idx)
            : base("warunek " + (idx + 1).ToString(), null)
        {
            this.literals = coll;
            this.index = idx;
        }
        #endregion

        #region "PropertyDescriptor methods implementation"

        public override AttributeCollection Attributes
        {
            get {
                return new AttributeCollection(null);
            }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get {
                return this.literals.GetType();
            }
        }

        public override string Description
        {
            get {
                Literal lit = this.literals[index] as Literal;
                StringBuilder sb = new StringBuilder();

                sb.Append(lit.Attribute);
                sb.Append(", ");
                sb.Append(lit.Value);

                return sb.ToString();
            }
        }

        public override object GetValue(object component)
        {
            return this.literals[index];
        }

        public override bool IsReadOnly
        {
            get { return true; }
        }
       
        public override Type PropertyType
        {
            get {
                return this.literals[index].GetType();
            }
        }

        public override void ResetValue(object component)
        { }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override void SetValue(object component, object value)
        {
            this.literals[index] = (Literal)value;
        }
        #endregion
    }
}
