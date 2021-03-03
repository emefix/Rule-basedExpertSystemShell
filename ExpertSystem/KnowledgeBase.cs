using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ExpertSystem
{
    [Serializable, XmlRoot("KnowledgeBase")]
    public class KnowledgeBase
    {
        #region "Fields and Accessors"

        private LiteralCollection facts;
        private RuleCollection rules;

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlArray("FactList"), XmlArrayItem(typeof(Fact), ElementName = "Fact")]
        public LiteralCollection Facts { get => facts; set => facts = value; }

        [XmlArray("RuleList"), XmlArrayItem(typeof(Rule), ElementName = "Rule")]
        public RuleCollection Rules { get => rules; set => rules = value; }
        #endregion

        #region "Constructor"

        public KnowledgeBase()
        {
            this.facts = new LiteralCollection();
            this.rules = new RuleCollection();
            this.Name = string.Empty;
        }
        #endregion

        #region "Load knowledge base from Xml file"

        public void LoadFromXml(XmlDocument xmlDoc)
        {
            ParseXmlFile parser = new ParseXmlFile(xmlDoc);

            Name  = parser.ParseName();
            Facts = parser.ParseFacts();
            Rules = parser.ParseRules();
        }
        #endregion

        #region "ToString"

        public override string ToString()
        {
            StringBuilder txt = new StringBuilder();
            txt.Append("\r\nNazwa bazy wiedzy: " + Name);
            txt.Append("\r\n\r\nFakty:\r\n");
            txt.Append(Facts.Select("\r\n"));
            txt.Append("\r\n\r\nReguły:\r\n");
            txt.Append(Rules.Select("\r\n"));
            return txt.ToString();
        }
        #endregion
    }
}
