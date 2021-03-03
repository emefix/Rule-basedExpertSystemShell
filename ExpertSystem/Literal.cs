using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExpertSystem
{
    [TypeConverter(typeof(LiteralConverter))]
    public class Literal   
    {
        #region "Fields and Accessors"

        private TypeOfValue value;

        [XmlElement(ElementName = "Attribute")]
        [DisplayName("Atrybut"), Category("Właściwości")]
        public string Attribute { get; set; }

        [XmlIgnore]
        [TypeConverter(typeof(ValueEnumConverter))]
        [DisplayName("Wartość"), Category("Właściwości")]
        public TypeOfValue Value { get => value; set => this.value = value; }

        [XmlElement(ElementName = "Value")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public int ValueSerialized
        {
            get => Convert.ToInt32(this.value);
            set
            {
                int val = Convert.ToInt32(this.value);
                this.Value = (TypeOfValue)val;
            }
        }
        #endregion

        #region "Constructors"

        public Literal()
        {
            this.Attribute = string.Empty;
            this.Value = TypeOfValue.True;
        }

        public Literal(string attribute, TypeOfValue value)
        {
            this.Attribute = attribute;
            this.Value = value;
        }
        #endregion

        #region "Equals method"

        public bool Equals(Literal lit)
        {
            return Attribute == lit.Attribute && Value == lit.Value;
        }
        #endregion

        #region "ToString"

        public override string ToString()
        {
            string txt = "";

            if (this.Value == TypeOfValue.False)          txt += "\u00AC ";
            else if(this.Value == TypeOfValue.Unknown)    txt += "\u007E ";

            return txt + this.Attribute;
        } 
        #endregion
    }
}
