using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpertSystem
{
    class Undermining : Attack
    {
        #region "Constructor"

        public Undermining(LiteralCollection facts, RuleCollection rules)
            : base(facts, rules)
        { }
        #endregion

        #region "Override Execute method"

        public override void Execute(Rule r1, Rule r2)
        {
            LogFile.Log("\r\n Atak podkopania!", ExpertSystemForm.logFileName);

            StringBuilder message = new StringBuilder();
            message.Append("   r" + r1.Id + " pokonuje r" + r2.Id + ", ");
            message.Append("ponieważ pref(r" + r1.Id + ") > pref(r" + r2.Id + ").");

            LogFile.Log(message.ToString(), ExpertSystemForm.logFileName);

            Facts.RetractConclusion(Facts.IndexOf(new Fact(r2.Conclusion, r2.Id)));
            Facts.RetractAllConclusionsGeneratedByTheRule(r2, Rules);
        }
        #endregion
    }
}
