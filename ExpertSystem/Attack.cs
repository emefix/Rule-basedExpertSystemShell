using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem
{
    abstract public class Attack
    {
        #region "Accessors"

        public LiteralCollection Facts { get; set; }
        public RuleCollection Rules { get; set; }
        #endregion

        #region "Constructor"

        public Attack(LiteralCollection facts, RuleCollection rules)
        {
            this.Facts = facts;
            this.Rules = rules;
        }
        #endregion

        #region "Execute abstract method"

        abstract public void Execute(Rule r1, Rule r2);
        #endregion
    }
}
