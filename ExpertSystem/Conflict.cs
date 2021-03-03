using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem
{
    public class Conflict
    {
        #region "Accessors"

        public LiteralCollection Facts { get; set; }
        public RuleCollection Rules { get; set; }

        public enum TypeOfAttack
        {
            None = 0,
            Undermining = 1,
            Rebutting = 2
        }
        #endregion

        #region "Constructor"

        public Conflict(LiteralCollection facts, RuleCollection rules)
        {
            this.Facts = facts;
            this.Rules = rules;
        }
        #endregion

        #region "Check the conflict"

        public TypeOfAttack Check(Rule r1, Rule r2)
        {
            Literal neg_Conclusion = new Literal(r2.Conclusion.Attribute, 
                (TypeOfValue)Convert.ToInt32(-1 * (int)r2.Conclusion.Value));

            if (r1.Conclusion.Equals(neg_Conclusion))
            {
                return TypeOfAttack.Rebutting;
            }

            int index = r2.Conditions.IndexOf(r1.Conclusion.Attribute);
            if (index != -1)
            {
                Literal r2_cond = r2.Conditions[index] as Literal;

                if (r1.Conclusion.Value == TypeOfValue.True && r2_cond.Value == TypeOfValue.Unknown) 
                {
                    return TypeOfAttack.Undermining;
                }
            }
            return TypeOfAttack.None;
        }
        #endregion
    }
}
