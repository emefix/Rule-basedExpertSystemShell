using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExpertSystem
{
    public class Rule
    {
        #region "Fields and Accessors"

        private string name;

        [XmlIgnore, DisplayName("Nazwa"), Category("Właściwości reguły")]
        public string Name { get => name; private set => name = value; }

        [XmlIgnore, Browsable(false)]
        public string SetName { get => name; set => name = value; }

        [XmlArray("ConditionList"), XmlArrayItem(typeof(Literal), ElementName = "Condition")]
        [DisplayName("Lista warunków"), Category("Właściwości reguły")]
        public LiteralCollection Conditions { get; set; }

        [XmlElement(ElementName = "Conclusion")]
        [DisplayName("Wniosek"), Category("Właściwości reguły")]
        public Literal Conclusion { get; set; }

        [XmlIgnore]
        [DisplayName("Priorytet"), Category("Właściwości reguły")]
        public decimal Priority { get; set; }

        [XmlElement(ElementName = "Priority")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string PrioritySerialized
        {
            get => Priority.ToString(CultureInfo.CreateSpecificCulture("pl-PL"));
            set
            {
                Decimal.TryParse(value, NumberStyles.Any, CultureInfo.CreateSpecificCulture("pl-PL"), out decimal priority);
                Priority = priority;
            }
        }

        [XmlIgnore, Browsable(false)]
        public int Id { get; set; }

        [XmlIgnore, Browsable(false), TypeConverter(typeof(IdConverter))]
        [DisplayName("Reguły wykorzystujące wniosek"), Category("Właściwości reguły")]
        public List<int> IdNextRules { get; private set; }

        #endregion

        #region "Constructors"

        public Rule()
        { }

        public Rule(int id)
        {
            this.Id = id;
            this.Name = "reguła " + Id;
            this.Conclusion = new Literal("wniosek", TypeOfValue.True);
            this.Conditions = new LiteralCollection
            {   new Literal("warunek", TypeOfValue.True)  };
            this.Priority = 1;
            this.IdNextRules = new List<int>();
        }

        public Rule(int id, LiteralCollection conditions, Literal conclusion, decimal priority)
        {
            this.Id = id;
            this.Name = "reguła " + Id;
            this.Conclusion = conclusion;
            this.Conditions = conditions;
            this.Priority = priority;
            this.IdNextRules = new List<int>();
        } 
        #endregion

        #region "ToString"

        public override string ToString()
        {
            string text = "r" + this.Id + ":  ";

            if (Conditions.Count != 0) {
                int i;
                for (i = 0; i < Conditions.Count - 1; i++)
                    text += Conditions[i] + "  \u028C  ";

                text += Conditions[i];
            }
            return text + "  \u2500\u2500\u25BA  " + Conclusion + "\t(pr = " + Priority + ")";
        }
        #endregion
    }
}
