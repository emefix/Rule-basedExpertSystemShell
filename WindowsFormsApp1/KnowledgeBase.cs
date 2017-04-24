using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Editor
{
    class KnowledgeBaseName
    {
        public string Name { get; private set; }

        public KnowledgeBaseName(string name)
        {
            this.Name = name;
        }
        public override string ToString()
        { 
            return this.Name;
        }
    }

    class Fact
    {
        public string Value { get; private set; }

        public Fact(string value)
        {
            this.Value = value;
        }
        public override string ToString()
        {
            return this.Value;
        }
    }

    class KnowledgeBase
    {
        public string name { get; private set; }
        //private string goal { get; private set; }
        public List<Rule> rules { get; private set; }
        public List<string> facts { get; private set; }

        public KnowledgeBase()
        {
            LoadKnowledgeBase();
        }

        public void LoadKnowledgeBase()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("KnowledgeBaseData.xml");
            XmlNodeList rootNodes = doc.DocumentElement.SelectNodes("/KnowledgeBase");

            foreach (XmlNode node in rootNodes)
            {
                this.name = /*new KnowledgeBaseName(*/node.Attributes["name"].Value;
                //this.goal = node["Goal"].InnerText;

                /*Create a list of facts.*/
                this.facts = new List<string>();

                foreach (XmlNode f in node["FactList"])
                {
                    this.facts.Add(f.InnerText);
                }

                /*Create a list of rules.*/
                this.rules = new List<Rule>();

                foreach (XmlNode r in node["RuleList"])
                {
                    string name = r.Attributes["name"].Value;
                    string conclusion = r["Conclusion"].InnerText;
                    double priority = double.Parse(r["Priority"].InnerText);

                    /*Create a list of conditions.*/
                    List<string> conds = new List<string>();

                    foreach (XmlNode c in r["ConditionList"])
                    {
                        conds.Add(c.InnerText);
                    }

                    this.rules.Add(new Rule(name, conds, conclusion, priority));
                }
            }
        }
    }
}
