using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem
{
    public enum TypeOfValue
    {
        [Description("prawda")]
        True = 1,

        [Description("nie wiadomo")]
        Unknown = 0,

        [Description("fałsz")]
        False = -1
    }
}
