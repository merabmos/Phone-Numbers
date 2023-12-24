using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class ReverseRoot
{
    private static void Main()
    {


        List<string> phoneNumbers;
        List<string[]> words = Words(out phoneNumbers);
        CheckNumbers(words, phoneNumbers);
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
                if (text.Length > 100)
                    throw new Exception("Out of max count");
                phoneNumbers.Add(text);

            }
            else if (i == 2)
            {
                var lmtOfWords = int.Parse(text);

                if (lmtOfWords > 50000)
                    throw new Exception("Out of max number");

                words = new string[lmtOfWords];
                limit += lmtOfWords;
            }
            else
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
        }

        return w;
    }

    public static void CheckNumbers(List<string[]> words, List<string> phoneNumbers)
    {
        //Sit
        //yva
        //552123

        Dictionary<int, string> numbDict = new Dictionary<int, string>()
            { {1,"ij" },{2,"abc" },{3,"def" },
              {4,"gh" },{5,"kl" },{6,"mn" },
              {7,"prs" },{8,"tuv" },{9,"wxy" },
                         {0,"oqz" }};

        StringBuilder shedgeniliSityva = new StringBuilder(" ");
        for (int i = 0; i < words.Count; i++)
        {
            var mopovebuli = shedgeniliSityva.ToString().Trim();
            int mopovebuliLenght = mopovebuli.Length;

            int firstLetter = phoneNumbers[i][0] - '0';
            var filtredNumbers = words[i].Where(word => word.Length <= phoneNumbers[i].Length)
                                      .Where(word => !(word.Length == phoneNumbers[i].Length && !numbDict.GetValueOrDefault(firstLetter).Contains(word[0])));

            for (int j = 0; j < filtredNumbers.Count(); j++)
            {
                var word = filtredNumbers.ElementAt(j);
                bool usableWord = true;
                for (int w = 0; w < word.Length; w++)
                {
                    var exist = numbDict.GetValueOrDefault(phoneNumbers[i][mopovebuliLenght >= 0 ? mopovebuliLenght : w] - '0').Contains(word[w]);

                    if (!exist)
                    {
                        usableWord = false;
                        break;
                    }
                    mopovebuliLenght++;
                }

                if (usableWord)
                    shedgeniliSityva.Append(word + " ");
            }

            if (mopovebuliLenght != phoneNumbers[i].Length)
            {
                if(mopovebuliLenght > 0)
                    i = 0;
                else
                    Console.WriteLine("No solution.");
            }
            else
            {
                Console.WriteLine(shedgeniliSityva.ToString().Trim());
                shedgeniliSityva.Clear();
            }

        }
    }
}