using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule_basedExpertSystemShell
{
    class KnowledgeBase
    {
        public string Name { get; private set; }
        public string Goal { get; private set; }
        public List<Rule> RuleList { get; private set; }
        public List<string> FactList { get; private set; }

        public KnowledgeBase(string name, string goal, List<Rule> rules, List<string> facts)
        {
            this.Name = name;
            this.Goal = goal;
            this.RuleList = rules;
            this.FactList = facts;
        }

        public override string ToString()
        {
            string text = "";
            text += Name + "\n";
            text += Goal + "\n";
            foreach (string item in FactList)
            {
                text += item + "\n";
            }
            foreach (Rule item in RuleList)
            {
                text += item.ToString() + "\n";
            }
            return text;
        }
    }
}
