﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem
{
    class NonMonotonicity : Attack
    {
        #region "Constructor"

        public NonMonotonicity(LiteralCollection facts, RuleCollection rules)
            : base(facts, rules)
        { }
        #endregion

        #region "Override Execute method"

        public override ForwardChaining.GenerateNewFact Execute(Rule r1, Rule r2)
        {
            Console.WriteLine("  There is nonmonotonicity!");
            /**
             *  If negated conclusion is already asserted into facts generated by the same rule, then
             *      > facts.remove(nC);
             *      > facts.add(C).
             */
            RetractConclusion(Facts.IndexOf(r2.Id));
            AssertConclusion(r1.Conclusion, r1.Id);
            return ForwardChaining.GenerateNewFact.True;
        } 
        #endregion
    }
}
