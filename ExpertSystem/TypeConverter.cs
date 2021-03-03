using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem
{
    /** 
     * This is a special type converter which will be associated with the Literal class.
     * It converts an Literal object to string representation for use in a property grid.
     */
    internal class LiteralConverter : ExpandableObjectConverter
    {
        #region "ExpandableObjectConverter methods implementation"

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            // We can be converted to an InstanceDescriptor
            if (destType == typeof(string))
                return true;
            return base.CanConvertTo(context, destType);
        }
        /** Converts the given value object to the specified type, using the arguments. */
        public override object ConvertTo(ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string))
            {
                /* Cast the value to an Literal type. */
                Literal lit = value as Literal;
                if (lit == null)
                    return string.Empty;

                /* Return the literal object. */
                return lit.ToString();
            }
            return base.ConvertTo(context, culture, value, destType);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
        #endregion
    }

    /** 
     * This is a special type converter which will be associated with the Collection of Literal classes.
     * It converts an collection of Literal objects to a string representation for use in a property grid.
     */
    internal class LiteralCollectionConverter : ExpandableObjectConverter
    {
        #region "ExpandableObjectConverter methods implementation"

        public override object ConvertTo(ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string))
            {
                LiteralCollection literals = (LiteralCollection)value;
                if (literals == null)
                    return "-";

                return literals.Select(", ");
            }
            return base.ConvertTo(context, culture, value, destType);
        }
        #endregion       
    }

    /** 
     * This is a special type converter which will be associated with the ValueEnum enum.
     * It converts an ValueEnum object to a string representation for use in a property grid.
     */
    internal class ValueEnumConverter : EnumConverter
    {
        #region "Field and Constructor"

        private Type enumType;

        public ValueEnumConverter(Type type) : base(type)
        {
            enumType = type;
        } 
        #endregion

        #region "EnumConverter methods implementation"

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            return destType == typeof(string);
        }

        /** Converts the given value object to the specified type, using the arguments. */
        public override object ConvertTo(ITypeDescriptorContext context,
                System.Globalization.CultureInfo culture, object value, Type destType)
        {
            FieldInfo fi = enumType.GetField(Enum.GetName(enumType, value));

            DescriptionAttribute dna = 
                (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));

            if (dna != null)
                return dna.Description;
            else
                return value.ToString();
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        /** Converts the given object to the type of this converter. */
        public override object ConvertFrom(ITypeDescriptorContext context,
                System.Globalization.CultureInfo culture, object value)
        {
            foreach (FieldInfo fi in enumType.GetFields())
            {
                DescriptionAttribute dna = 
                    (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));

                if ((dna != null) && ((string)value == dna.Description))
                    return Enum.Parse(enumType, fi.Name);
            }
            return Enum.Parse(enumType, (string)value);
        }
        #endregion
    }

    /** 
     * This is a special type converter which will be associated with the list of ints.
     * It converts an list of ints to a string representation for use in a property grid.
     */
    internal class IdConverter : StringConverter
    {
        #region "StringConverter methods implementation"

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            if (destType == typeof(string))
                return true;
            return base.CanConvertTo(context, destType);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string))
            {
                List<int> ids = (List<int>)value;
                if (ids == null)
                    return "-";
                
                return string.Join(", ", ids.Select(m => m));
            }
            return base.ConvertTo(context, culture, value, destType);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) {
            return false;
        }
        #endregion
    }
}