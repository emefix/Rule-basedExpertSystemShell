using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem
{
    public class CustomObjectCollection : CollectionBase
    {
        #region "CollectionBase methods implementation"

        public void Add(object o)
        {
            this.List.Add(o);
        }

        public void Insert(int index, object o)
        {
            this.List.Insert(index, o);
        }

        public void Remove(object o)
        {
            this.List.Remove(o);
        }

        public object this[int index]
        {
            get { return (object)this.List[index]; }
            set { List[index] = value; }
        }

        public string Select(string separator)
        {
            if (List.Count != 0)
            {
                StringBuilder txt = new StringBuilder();
                int i;
                for (i = 0; i < List.Count - 1; i++)
                    txt.Append(List[i] + separator);

                return txt.ToString() + List[i];
            }
            return string.Empty;
        }

        public new void RemoveAt(int index)
        {
            List.RemoveAt(index);
        }

        public void Rename(int index, string str)
        {
            for (int i = index; i < List.Count; i++)
            {
                Fact el = List[i] as Fact;
                el.SetName = str + " " + i;
            }
        }
        #endregion
    }
}
