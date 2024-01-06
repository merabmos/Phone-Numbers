using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class ReverseRoot
{
    private static void Main()
    {
        /*        List<string> phoneNumbers;
                List<string[]> words = Words(out phoneNumbers);
                CheckNumbers(words, phoneNumbers);*/

        Method();
    }



    public static List<string[]> Words(out List<string> phoneNumbers)
    {
        phoneNumbers = new List<string>();
        int limit = 2;
        string[] words = default;
        List<string[]> w = new List<string[]>();
        for (int i = 1; i <= limit; i++)
        {
            var text = Console.ReadLine();

            if (text == "-1")
                break;

            if (i == 1)
            {
                try
                {
                    if (text.Length > 100)
                        throw new Exception("Out of max count");
                    phoneNumbers.Add(text);
                }
                catch
                {
                    i = 0;
                }

            }
            else if (i == 2)
            {
                try
                {
                    var lmtOfWords = int.Parse(text);

                    if (lmtOfWords > 50000)
                        throw new Exception("Out of max number");

                    words = new string[lmtOfWords];
                    limit += lmtOfWords;
                }
                catch
                {
                    i = 1;
                }
            }
            else
            {
                try
                {

                    if (text.Length > 50)
                        throw new Exception("Out of max count");

                    words[i - 3] = text.ToLower();

                    if (i == limit)
                    {
                        w.Add(words);
                        i = 0;
                        limit = 2;
                    }
                }
                catch
                {
                    i--;
                }
            }
        }

        return w;
    }

    public static void CheckNumbers(List<string[]> words, List<string> phoneNumbers)
    {

        Dictionary<int, string> numbDict = new Dictionary<int, string>()
            { {1,"ij" },{2,"abc" },{3,"def" },
              {4,"gh" },{5,"kl" },{6,"mn" },
              {7,"prs" },{8,"tuv" },{9,"wxy" },
                         {0,"oqz" }};
    }


    public static void Method()
    {
        string number = "7325189087";

        List<string> words = new List<string>() { "it", "your", "reality", "real", "our" };

        SortByLenght(words);

        Console.WriteLine(CheckWord(words[2], number));
    }
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

    public static void SortByLenght(List<string> words)
    {
        words.Sort((x, y) => y.Length.CompareTo(x.Length));
    }

}