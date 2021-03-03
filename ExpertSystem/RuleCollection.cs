using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem
{
    public class RuleCollection : CustomObjectCollection
    {
        #region "CustomObjectCollection methods implementation"

        public new void Rename(int index, string str)
        {
            for (int i = index; i < List.Count; i++)
            {
                Rule el = List[i] as Rule;
                el.Id = i;
                el.SetName = str + " " + i;
            }
        }
        #endregion
    }
}
