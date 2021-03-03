using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpertSystem
{
    class Rebutting : Attack
    {
        #region "Constructor"

        public Rebutting(LiteralCollection facts, RuleCollection rules)
           : base(facts, rules)
        { }
        #endregion

        #region "Override Execute method"

        public override void Execute(Rule r1, Rule r2)
        {
            LogFile.Log("\r\n Atak obalania!", ExpertSystemForm.logFileName);

            if (r1.Priority > r2.Priority)
            {
                StringBuilder message = new StringBuilder();
                message.Append("   r" + r1.Id + " pokonuje r" + r2.Id + ", ");
                message.Append("ponieważ pref(r" + r1.Id + ") > pref(r" + r2.Id + ").");

                LogFile.Log(message.ToString(), ExpertSystemForm.logFileName);

                Facts.RetractConclusion(Facts.IndexOf(new Fact(r2.Conclusion, r2.Id)));
                Facts.RetractAllConclusionsGeneratedByTheRule(r2, Rules);
            }
            else if (r1.Priority < r2.Priority)
            {
                StringBuilder message = new StringBuilder();
                message.Append("   r" + r2.Id + " pokonuje r" + r1.Id + ", ");
                message.Append("ponieważ pref(r" + r1.Id + ") < pref(r" + r2.Id + ").");

                LogFile.Log(message.ToString(), ExpertSystemForm.logFileName);

                Facts.RetractConclusion(Facts.IndexOf(new Fact(r1.Conclusion, r1.Id)));
                Facts.RetractAllConclusionsGeneratedByTheRule(r1, Rules);
            }
            /** 
            * There is a conflict between rules. 
            */
            else if (r1.Priority == r2.Priority)
            {
                StringBuilder message = new StringBuilder();
                message.Append("Reguły się obalają: \r\n\t" + r1.ToString() + ",\r\n\t" + r2.ToString() + ".\r\n");

                LogFile.Log("  " + message.ToString(), ExpertSystemForm.logFileName);

                message.Append("Nie można wniosokować z reguł nr " + r1.Id + " i " + r2.Id + ",\r\n");
                message.Append("określ priorytety dla tych reguł.");

                MessageBox.Show(message.ToString(), "Konflikt między regułami", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Facts.RetractConclusion(Facts.IndexOf(new Fact(r1.Conclusion, r1.Id)));
                Facts.RetractAllConclusionsGeneratedByTheRule(r1, Rules);

                Facts.RetractConclusion(Facts.IndexOf(new Fact(r2.Conclusion, r2.Id)));
                Facts.RetractAllConclusionsGeneratedByTheRule(r2, Rules);
            }
        }
        #endregion
    }
}
