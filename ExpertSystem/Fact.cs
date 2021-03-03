using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExpertSystem
{
    public class Fact : Literal
    {
        #region "Fields and Accessors"

        private string name;
        private int idRule;
        private int id;

        [XmlIgnore, DisplayName("Nazwa faktu"), Category("Właściwości")]
        public string Name { get => name; private set => name = value; }

        [XmlIgnore, Browsable(false)]
        public string SetName { get => name; set => name = value; }

        [XmlIgnore, DisplayName("Nr reguły")]
        [Description("Nr reguły potwierdzającej fakt"), Category("Właściwości")]
        public int GetIdRule { get => idRule; private set => idRule = value; }

        [XmlIgnore, Browsable(false)]
        public int IdRule { get => idRule; set => idRule = value; }

        [XmlIgnore, Browsable(true)]
        public int Id { get => id; private set => id = value; }

        [XmlIgnore, Browsable(false)]
        public int SetId { get => id; set => id = value; }
        #endregion

        #region "Constructors"

        public Fact() { }

        public Fact(int id)
        {
            this.Id = id;
            this.Name = "fakt " + id;
            this.IdRule = -1;

            this.Attribute = "nowy_fakt";
            this.Value = TypeOfValue.True;
        }

        public Fact(Literal lit, int idRule)
           : base(lit.Attribute, lit.Value)
        {
            IdRule = idRule;
        }

        public Fact(int id, string attribute, TypeOfValue value)
            : base(attribute, value)
        {
            this.Id = id;
            this.Name = "fakt " + id;
            this.IdRule = -1;
        }
        #endregion

        #region "Equals method"

        public bool Equals(Fact f)
        {
            return Attribute == f.Attribute && Value == f.Value && IdRule == f.IdRule;
        }
        #endregion

        #region "ToString"

        public override string ToString()
        {
            string txt;
            txt = base.ToString();
            if (idRule != -1)
                txt += " (r" + idRule.ToString() + ")";
            return txt;
        }
        #endregion
    }
}
