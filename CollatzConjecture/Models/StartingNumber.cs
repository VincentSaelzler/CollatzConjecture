using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollatzConjecture.Models
{
    public class StartingNumber
    {
        public StartingNumber(int i, int evenExp, int oddExp)
        {
            StartingNumberId = i;
            Steps = new List<int> { i };
            while (Steps[Steps.Count - 1] > 1 && Steps.Count < 1000)
            {
                Steps.Add(GetNext(Steps[Steps.Count - 1], evenExp, oddExp));
            }
        }
        public int StartingNumberId { get; set; }
        public int TheNum { get { return StartingNumberId; } }
        public int NumSteps { get { return Steps.Count(); } }
        public string StepsString
        {
            get
            {
                string s = "";
                foreach (int i in Steps)
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
                for (int i = 1; i <= Steps.Count; i++)
                {
                    s += i.ToString() + ", ";
                }
                return s;
            }
        }
        public IList<int> Steps { get; set; }
        public int GetNext(int i, int evenExp, int oddExp)
        {
            if (i % 2 == 0)
            {
                return i / evenExp;
            }
            else
            {
                return i * oddExp + 1;
            }
        }
    }
}