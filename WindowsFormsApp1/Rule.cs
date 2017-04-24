using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
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
            text += Name + ": if ";
            for (int i=0; i < ConditionList.Count-1; i++)
            {
                text += ConditionList[i] + ", ";
            }
            text += ConditionList.Last() + " then " + Conclusion;
            return text;
        }
    }
}
