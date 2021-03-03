using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ExpertSystem.ExpertSystemForm;

namespace ExpertSystem
{
    public class ForwardChaining
    {
        #region "Fields and Accessors"

        public RuleCollection Rules { get; set; }
        public LiteralCollection CFacts { get; set; }        /* current facts */
        public LiteralCollection FFacts { get; set; }       /* final facts   */

        public enum GeneratedNewFact
        {
            True     = 1,
            False    = 0
        }
        #endregion

        #region "Constructor"

        public ForwardChaining(KnowledgeBase kb)
        {
            this.Rules = new RuleCollection();
            this.CFacts = new LiteralCollection();
            this.FFacts = new LiteralCollection();

            foreach (Fact f in kb.Facts) this.CFacts.Add(f);
            foreach (Rule r in kb.Rules) this.Rules.Add(r);

            DetermineIdNextRules();
        }
        #endregion

        #region "Determine IdNextRules for each rule"

        private void DetermineIdNextRules()
        {
            foreach (Rule r_ext in Rules)
            {
                r_ext.IdNextRules.Clear();
                foreach (Rule r_int in Rules)
                {
                    if (r_ext.Id != r_int.Id && r_int.Conditions.Contains(r_ext.Conclusion))
                    {
                        r_ext.IdNextRules.Add(r_int.Id);
                    }
                }
            }
        }
        #endregion

        #region "Execute reasoning"

        public void ExecuteReasoning()
        {
            List<GeneratedNewFact> results = new List<GeneratedNewFact>();

            int cycle = 0;
            string str;

            do
            {
                str = "[ Cykl " + ++cycle + " ]";
                LogFile.Log("\r\n" + str.PadRight(80, '_') + "\r\n", ExpertSystemForm.logFileName);

                results.Clear();
                /** 
                 *  For each rule in rules check all the conditions of rule. 
                 */
                foreach (Rule r in Rules)
                {
                    /**  
                     *  If all the conditions of rule are true, then
                     *          > rule is positively resolved. 
                     */
                    if (RuleIsPositivelyResolved(r))
                    {
                        if (r.Conclusion.Value != TypeOfValue.Unknown)
                            results.Add(FireRule(r));
                    }
                    else LogFile.Log("Reguła " + r.Id + " jest nieokreślona.", ExpertSystemForm.logFileName);
                }
            }
            /**  
             *  If in the last cycle no new conclusions have been generated, then
             *      > the forward chaining process attained stready state --> STOP.
             */
            while (results.Contains(GeneratedNewFact.True));
            /** 
             *  Check conflicts in current fact base (CFacts).
             */
            str = "[ Konflikty ]";
            LogFile.Log("\r\n" + str.PadRight(80, '_'), ExpertSystemForm.logFileName);

            ResolveConflicts(Conflict.TypeOfAttack.Undermining);
            ResolveConflicts(Conflict.TypeOfAttack.Rebutting);
            /** 
             *  The final facts (FFacts) represents the facts of forward chaining.
             */
            FFacts.CopyFrom(CFacts);
        }
        #endregion

        #region "Rule is positively resolved"

        private bool RuleIsPositivelyResolved(Rule r)
        {
            foreach (Literal c in r.Conditions)
            {
                if (c.Value != TypeOfValue.Unknown)
                {
                    if (! CFacts.Contains(c))
                        return false;
                }
                else
                {
                    Literal c_false = new Literal(c.Attribute, TypeOfValue.False);

                    if (CFacts.Contains(c.Attribute) && ! CFacts.Contains(c_false))
                        return false;
                }
            }
            LogFile.Log("Reguła " + r.Id + " jest spełniona.", ExpertSystemForm.logFileName);
            return true;
        }
        #endregion

        #region "Fire rule"

        private GeneratedNewFact FireRule(Rule r)
        {
            LogFile.Log(" Odpalono regułę " + r.Id + ":", ExpertSystemForm.logFileName);

            Fact C = new Fact(r.Conclusion, r.Id);
            Literal neg_C = new Literal(C.Attribute, (TypeOfValue)Convert.ToInt32(-1 * (int) C.Value));

            if (! CFacts.Contains(C.IdRule) && ! CFacts.Contains(new Fact(neg_C, -1)))
            {
                CFacts.AssertConclusion(C); 
                return GeneratedNewFact.True;
            }

            return GeneratedNewFact.False;
        }
        #endregion

        #region "Resolve conflicts"

        private void ResolveConflicts(Conflict.TypeOfAttack analyzed)
        {
            Rule r_ext, r_int;
            Conflict conflict;

            int i_ext = 0;
            while (i_ext < CFacts.Count)
            {
                Fact f_ext = CFacts[i_ext] as Fact;
                if (f_ext.IdRule != -1)
                {
                    r_ext = Rules[f_ext.IdRule] as Rule;

                    int i_int = 0;
                    while (i_int < CFacts.Count)
                    {
                        Fact f_int = CFacts[i_int] as Fact;
                        if (f_int.IdRule != -1 && f_ext.Id != f_int.Id)
                        {
                            r_int = Rules[f_int.IdRule] as Rule;

                            conflict = new Conflict(CFacts, Rules);
                            Conflict.TypeOfAttack occuring = conflict.Check(r_ext, r_int);
                            Attack attack = null;

                            if (analyzed == Conflict.TypeOfAttack.Undermining &&
                                occuring == Conflict.TypeOfAttack.Undermining)
                            {
                                attack = new Undermining(CFacts, Rules);
                            }
                            else if (analyzed == Conflict.TypeOfAttack.Rebutting &&
                                occuring == Conflict.TypeOfAttack.Rebutting)
                            {
                                attack = new Rebutting(CFacts, Rules);
                            }

                            if (attack != null)
                            {
                                attack.Execute(r_ext, r_int);

                                i_int = CFacts.Count;
                                i_ext = 0;
                            }
                        }
                        ++i_int;
                    }
                }
                ++i_ext;
            }
        }
        #endregion
    }
}
