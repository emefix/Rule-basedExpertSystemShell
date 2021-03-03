using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem
{
    internal class LiteralListConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture,
            object value, Type destType)
        {
            if (destType != typeof(string))
                return base.ConvertTo(context, culture, value, destType);

            List<Literal> literals = value as List<Literal>;
            if (literals == null)
                return "-";

            return string.Join(", ", literals.Select(m => m));
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context,
            object value, Attribute[] attributes)
        {
            List<PropertyDescriptor> list = new List<PropertyDescriptor>();
            List<Literal> literals = value as List<Literal>;
            if (literals != null)
            {
                /* Iterate the list of literals */
                foreach (Literal lit in literals)
                {
                    if (lit.Attribute != null)
                        list.Add(new LiteralPropertyDescriptor(lit, list.Count));
                }
            }
            return new PropertyDescriptorCollection(list.ToArray());
        }

        private class LiteralPropertyDescriptor : SimplePropertyDescriptor
        {
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public Literal Literal { get; private set; }

            public LiteralPropertyDescriptor(Literal lit, int index)
                : base(lit.GetType(), "warunek "+(index+1).ToString(), typeof(string))
            {
                Literal = lit;
            }

            public override object GetValue(object component)
            {
                return Literal;
            }

            public override string Description
            {
               get
               {
                   Literal lit = this.literals[index];
                   StringBuilder sb = new StringBuilder();
                   sb.Append(lit.Attribute);
                   sb.Append(", ");
                   sb.Append(lit.Value);

                   return lit.ToString();
               }
            }

            public override void SetValue(object component, object value)
            {
                Literal = (Literal)value;
                //LiteralProperty.Attribute = (string)value;
                //LiteralProperty.Value = (bool)value;
            }

            //public override AttributeCollection Attributes
            //{
            //    get
            //    {
            //        return new AttributeCollection();
            //    }
            //}

            //public override string DisplayName
            //{
            //    get
            //    {
            //        return Literal.Attribute + " " +Literal. Value;

            //        //return literal.Attribute + " " + literal.Value;
            //    }
            //}

            //public override string Name
            //{
            //    get { return "#" + index.ToString(); }
            //}

            //public override Type PropertyType
            //{
            //    get { return this.literals[index].GetType(); }
            //}
        }

    }
    //internal class LiteralConverter : ExpandableObjectConverter
    //{
    //    public override object ConvertTo(ITypeDescriptorContext context,
    //                                     System.Globalization.CultureInfo culture,
    //                                     object value, Type destType)
    //    {
    //        if (destType == typeof(string) && value is Literal)
    //        {
    //            Literal lit = (Literal)value;
    //            return lit.Attribute + "," + lit.Value;
    //        }
    //        return base.ConvertTo(context, culture, value, destType);
    //    }
    //}
}

