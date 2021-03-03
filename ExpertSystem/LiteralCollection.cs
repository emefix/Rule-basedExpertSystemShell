using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExpertSystem
{
    [TypeConverter(typeof(LiteralCollectionConverter))]
    public class LiteralCollection : CustomObjectCollection, ICustomTypeDescriptor
    {
        #region "LiteralCollection methods implementation"

        public int IndexOf(string attribute)
        {
            for (int i = 0; i < Count; i++)
            {
                Literal el = List[i] as Literal;
                if (el.Attribute == attribute)
                    return i;
            }
            return -1;
        }

        public int IndexOf(Literal lit)
        {
            for (int i = 0; i < Count; i++)
            {
                Literal el = List[i] as Literal;
                if (el.Equals(lit))
                    return i;
            }
            return -1;
        }

        public int IndexOf(int idrule)
        {
            for (int i = 0; i < Count; i++)
            {
                Fact el = List[i] as Fact;
                if (el.IdRule == idrule)
                    return i;
            }
            return -1;
        }

        public int IndexOf(Fact f)
        {
            for (int i = 0; i < Count; i++)
            {
                Fact el = List[i] as Fact;
                if (el.Equals(f))
                    return i;
            }
            return -1;
        }

        public bool Contains(string attribute)
        {
            foreach (Literal el in List)
                if (el.Attribute == attribute)
                    return true;
            return false;
        }

        public bool Contains(Literal lit)
        {
            foreach (Literal el in List)
                if (el.Equals(lit))
                    return true;
            return false;
        }

        public bool Contains(int idrule)
        {
            for (int i = 0; i < Count; i++)
            {
                Fact el = List[i] as Fact;
                if (el.IdRule == idrule)
                    return true;
            }
            return false;
        }

        public bool Contains(Fact f)
        {
            foreach (Fact el in List)
                if (el.Equals(f))
                    return true;
            return false;
        }

        public bool ContainsWithAnotherRule(Literal lit, int idrule)
        {
            foreach (Fact el in List)
                if (el.Equals(lit) && el.IdRule != idrule)
                    return true;
            return false;
        }

        public void AssertConclusion(Fact C)
        {
            C.SetId = List.Count;
            List.Add(C);
            LogFile.Log("   Zapisano wniosek: '" + C + "'.", ExpertSystemForm.logFileName);
        }

        public void RetractConclusion(int index)
        {
            Fact fact = List[index] as Fact;
            LogFile.Log("   Odrzucono fakt: '" + fact + "'", ExpertSystemForm.logFileName);
            List.RemoveAt(index);
        }

        public void RetractAllConclusionsGeneratedByTheRule(Rule r, RuleCollection rules)
        {
            if (r.IdNextRules != null)
            {
                foreach (int id in r.IdNextRules)
                {
                    Rule nextRule = rules[id] as Rule;

                    int index_nextConclusion = IndexOf(new Fact(nextRule.Conclusion, id));
                    if (index_nextConclusion != -1)
                    {
                        if (! ContainsWithAnotherRule(r.Conclusion, id))
                        {
                            RetractAllConclusionsGeneratedByTheRule(rules[id] as Rule, rules);
                            RetractConclusion(index_nextConclusion);
                        }
                    }
                }
            }
        }

        public void CopyFrom(LiteralCollection facts)
        {
            int counter = 0;
            foreach (Fact f in facts)
            {
                if (! Contains(f as Literal))
                {
                    f.SetName = "fakt " + ++counter;
                    Add(f);
                }
            }
        }
        #endregion

        #region "Implementation of ICustomTypeDescriptor"

        /** Method, which Will called while binding object to PropertyGrid.
         */

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes) {
            return GetProperties();
        }

        public PropertyDescriptorCollection GetProperties()
        {
            /** Create a new collection object PropertyDescriptorCollection.
             */
            PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);

            /** Iterate the list of literals 
             */
            for (int i = 0; i < this.List.Count; i++)
            {
                /** For each literal create a property descriptor and add it to the PropertyDescriptorCollection instance. 
                 */
                LiteralPropertyDescriptor pd = new LiteralPropertyDescriptor(this,i);
                pds.Add(pd);
            }
            return pds;
        }

        public String GetClassName() {
            return TypeDescriptor.GetClassName(this, true);
        }
        public AttributeCollection GetAttributes() {
            return TypeDescriptor.GetAttributes(this, true);
        }
        public String GetComponentName() {
            return TypeDescriptor.GetComponentName(this, true);
        }
        public TypeConverter GetConverter() {
            return TypeDescriptor.GetConverter(this, true);
        }
        public EventDescriptor GetDefaultEvent() {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }
        public PropertyDescriptor GetDefaultProperty() {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }
        public object GetEditor(Type editorBaseType) {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }
        public EventDescriptorCollection GetEvents(Attribute[] attributes) {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }
        public EventDescriptorCollection GetEvents() {
            return TypeDescriptor.GetEvents(this, true);
        }
        public object GetPropertyOwner(PropertyDescriptor pd) {
            return this;
        }
        #endregion
    }
}
