using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ExpertSystem
{
    class ParseXmlFile
    {
        #region "Fields"

        private XmlDocument xmlDoc;
        #endregion

        #region "Constructor"

        public ParseXmlFile(XmlDocument doc)
        {
            this.xmlDoc = doc;
        }
        #endregion

        #region "Parse name of knowldege base"

        public string ParseName()
        {
            XmlNode kb = xmlDoc.DocumentElement.SelectSingleNode("/KnowledgeBase");
            return kb.Attributes["name"].Value;
        }
        #endregion

        #region "Parse facts"

        public LiteralCollection ParseFacts()
        {
            LiteralCollection facts = new LiteralCollection();
            XmlNodeList factNode = xmlDoc.GetElementsByTagName("Fact");

            foreach (XmlNode f in factNode)
            {
                /** Fact */
                string attribute = f["Attribute"].InnerText;
                TypeOfValue value = (TypeOfValue)Convert.ToInt32(f["Value"].InnerText);

                Fact fact = new Fact(facts.Count, attribute, value);
                facts.Add(fact);
            }
            return facts;
        }
        #endregion

        #region "Parse rules"

        public RuleCollection ParseRules()
        {
            /** Create a list of rules */
            RuleCollection rules = new RuleCollection();
            XmlNodeList ruleNode = xmlDoc.GetElementsByTagName("Rule");

            foreach (XmlNode r in ruleNode)
            {
                /** Conclusion of Rule */
                XmlNode conclusionNode = r["Conclusion"];
                string attribute = conclusionNode["Attribute"].InnerText;
                TypeOfValue value = (TypeOfValue)Convert.ToInt32(conclusionNode["Value"].InnerText);

                Literal conclusion = new Literal(attribute, value);

                /** Priority of Rule */
                decimal priority = decimal.Parse(r["Priority"].InnerText);

                /** Create a list of conditions */
                LiteralCollection conditions = ParseConditions(r);

                rules.Add(new Rule(rules.Count, conditions, conclusion, priority));
            }
            return rules;
        }
        #endregion

        #region "Parse conditions of rule"

        public LiteralCollection ParseConditions(XmlNode ruleNode)
        {
            /** Create a list of conditions */
            LiteralCollection conditions = new LiteralCollection();

            foreach (XmlNode node in ruleNode["ConditionList"])
            {
                /** Condition of Rule */
                string attribute = node["Attribute"].InnerText;
                TypeOfValue value = (TypeOfValue)Convert.ToInt32(node["Value"].InnerText);

                Literal cond = new Literal(attribute, value);
                conditions.Add(cond);
            }
            return conditions;
        }
        #endregion
    }
}
