using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseRoot
{
    public class ValidationClass
    {
        public static bool CheckWord(string word, string number)
        {
            Dictionary<int, string> numbDict = new Dictionary<int, string>()
            { {1,"ij" },{2,"abc" },{3,"def" },
              {4,"gh" },{5,"kl" },{6,"mn" },
              {7,"prs" },{8,"tuv" },{9,"wxy" },
                         {0,"oqz" }};

            if (word.Length > number.Length)
                return false;

            for (int i = 0; i < word.Length; i++)
            {
                string val;

                numbDict.TryGetValue(number[i] - '0', out val);

                if (!val.Contains(word[i]))
                    return false;
            }

            return true;
        }

    }
}
