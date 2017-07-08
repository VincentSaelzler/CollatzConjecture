using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollatzConjecture.Models
{
    public class CollatzSequence
    {
        #region Properties
        public int InitialValue { get; private set; }
        public int? RepeatedValIndex { get; private set; }
        public bool TendsToInfinity { get; private set; }
        public int? TotalStoppingTime
        {
            get
            {
                //https://stackoverflow.com/questions/2766932/why-cant-i-set-a-nullable-int-to-null-in-a-ternary-if-statement
                return (RepeatedValIndex == null && !TendsToInfinity) ? (int?)Steps.Count - 1 : null;
            }
        }
        public string StepsString
        {
            get
            {
                string s = "";
                foreach (int i in Steps.OrderBy(step => step.Value).Select(step => step.Key))
                {
                    s += i.ToString() + ", ";
                }
                return s;
            }
        }
        public string LegendString
        {
            get
            {
                string s = "";
                for (int i = 0; i < Steps.Count; i++)
                {
                    s += i.ToString() + ", ";
                }
                return s;
            }
        }
        public IDictionary<int, int> Steps { get; set; } //IDictionary<stepVal, stepIndex>
        #endregion
        public CollatzSequence(int initialValue, int eventExp, int oddExp)
        {
            InitialValue = initialValue;
            Steps = new Dictionary<int, int> { { initialValue, 0 } };
            AddNext(initialValue, eventExp, oddExp, this);
        }
        private void AddNext(int inValue, int evenExp, int oddExp, CollatzSequence collatzSequence)
        {
            if (inValue != 1)
            {
                //calculate next value
                int nextValue;
                if (inValue % 2 == 0) //number is even
                {
                    nextValue = inValue / evenExp;
                }
                else
                {
                    nextValue = inValue * oddExp + 1;
                }

                //assuming that values that roll over int.maxvalue are tending to infinity
                if (nextValue < 0)
                {
                    TendsToInfinity = true;
                }
                else
                {
                    //take actions
                    if (nextValue == 1)
                    {
                        collatzSequence.Steps.Add(nextValue, collatzSequence.Steps.Count()); //TODO: check that the count is taken BEFORE the .Add call
                    }
                    else
                    {
                        if (collatzSequence.Steps.ContainsKey(nextValue))
                        {
                            collatzSequence.RepeatedValIndex = Steps[nextValue];
                        }
                        else
                        {
                            collatzSequence.Steps.Add(nextValue, collatzSequence.Steps.Count());
                            AddNext(nextValue, evenExp, oddExp, collatzSequence);
                        }
                    }
                }
            }
        }
    }
}