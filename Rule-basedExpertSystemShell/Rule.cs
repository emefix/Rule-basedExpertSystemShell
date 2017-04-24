using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule_basedExpertSystemShell
{
    class Rule
    {
        public string Name { get; private set; }
        public List<string> ConditionList { get; private set; }
        public string Conclusion { get; private set; }
        public double Priority { get; private set; }

        public Rule(string name, List<string> conditions, string conclusion, double priority)
        {
            this.Name = name;
            this.ConditionList = conditions;
            this.Conclusion = conclusion;
            this.Priority = priority;
        }

        public override string ToString()
        {
            string text = "";
            text += Name + ": IF";
            foreach (string item in ConditionList)
            {
                text += item + " and ";
            }
            text += "THEN" + Conclusion;
            return text;
        }
    }
}
