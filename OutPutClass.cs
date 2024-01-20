using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseRoot
{
    public class OutPutClass
    {
        public void OutPut(List<string> searchedWords)
        {
            if (searchedWords != null)
            {
                Console.WriteLine(string.Join(" ", searchedWords));
            }
            else
            {
                Console.WriteLine("No solution.");
            }
        }

    }
}
