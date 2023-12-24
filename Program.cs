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

        for (int i = 0; i < words.Count; i++)
        {
            int firstLetter = phoneNumbers[i][0] - '0';
            var filtredWords = words[i].Where(word => word.Length <= phoneNumbers[i].Length)
                                         .Where(word => !(word.Length == phoneNumbers[i].Length && !numbDict.GetValueOrDefault(firstLetter)
                                         .Contains(word[0])));

            string word = "";
            for (int j = 0; j < phoneNumbers[i].Length; j++)
            {
                int nNumber = phoneNumbers[i][j] - '0';
                var trimmed = word.Replace(" ", "");
                int trimmedLength = trimmed.Length;
                if (trimmedLength > 0 && j < trimmedLength)
                {
                    if (!numbDict.GetValueOrDefault(nNumber).Contains(trimmed[j]))
                        word = "";
                }
                else
                {
                    var filtredWordByFirstLetter = filtredWords.FirstOrDefault(o => numbDict.GetValueOrDefault(nNumber).Contains(o[0]) && o.Length == phoneNumbers[i].Length);

                    if (filtredWordByFirstLetter != null)
                        word += filtredWordByFirstLetter + " ";
                    else
                    {
                        filtredWordByFirstLetter = filtredWords.FirstOrDefault(o => numbDict.GetValueOrDefault(nNumber).Contains(o[0]));
                        if (filtredWordByFirstLetter != null)
                            word += filtredWordByFirstLetter + " ";
                        else
                            break;
                    }
                }
            }

            Console.WriteLine(string.IsNullOrEmpty(word) || word.Replace(" ", "").Length != phoneNumbers[i].Length ? "No solution." : word);
        }
    }
}