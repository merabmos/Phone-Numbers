using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ReverseRoot
{
    public class ReverseRoot
    {
        private static void Main()
        {
            List<string> phoneNumbers;

            List<List<string>> words;

            words = Input(out phoneNumbers);

            CheckNumbers(words, phoneNumbers);
        }

        public static List<List<string>> Input(out List<string> phoneNumbers)
        {
            List<List<string>> words = new List<List<string>>() { };
            phoneNumbers = new List<string>();

            while (true)
            {
                var number = InputPhoneNumber();
                if (number != "-1")
                {
                    phoneNumbers.Add(number);

                    int totalWordsNumber = InputWordsTotalNumber();

                    words.Add(InputWords(totalWordsNumber));
                }
                else
                    return words;
            }
        }

        public static string InputPhoneNumber()
        {
            while (true)
            {
                var number = Console.ReadLine().Trim();
                var regex = new Regex("^[0-9]+$");

                if (number == "-1")
                {
                    return number;
                }
                else if (number.Length >= 100)
                {
                    continue;

                }
                else if (!regex.Match(number).Success)
                {
                    continue;
                }
                else
                    return number;
            }
        }
        public static int InputWordsTotalNumber()
        {
            while (true)
            {
                var number = Console.ReadLine().Trim();
                var regex = new Regex("^[0-9]+$");

                if (!regex.Match(number).Success)
                {
                    continue;
                }
                else
                {
                    var parsedNumber = int.Parse(number);

                    if (parsedNumber >= 50000 && parsedNumber < 1)
                    {
                        continue;
                    }
                    else
                        return parsedNumber;
                }

            }
        }
        public static List<string> InputWords(int wordsTotalNumber)
        {
            List<string> words = new List<string>();

            while (true)
            {
                if (wordsTotalNumber == words.Count)
                    return words;

                var word = Console.ReadLine().ToLower().Trim();
                var regex = new Regex("^[a-z]+$");

                if (word.Length >= 50)
                {
                    continue;
                }
                else if (!regex.Match(word).Success)
                {
                    continue;
                }
                else
                    words.Add(word);
            }
        }
        public static void OutPut(List<string> searchedWords)
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
        public static void CheckNumbers(List<List<string>> words, List<string> phoneNumbers)
        {
            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                SortByLenght(words[i]);
                var searchedWords = SearchingWords(words[i], phoneNumbers[i]);
                OutPut(searchedWords);
            }
        }

        public static List<string> SearchingWords(List<string> words, string number)
        {
            bool finded = false;

            List<string> collectedWords = new List<string>();

            while (!finded)
            {
                var collected = CollectingWords(words, number);

                if (collected.Count == 0)
                    return null;

                collectedWords.AddRange(collected);

                int colletedLength = string.Join("", collected).Length;

                if (colletedLength != number.Length && colletedLength > 0)
                    number = number.Substring(colletedLength);
                else
                    finded = true;
            }

            return collectedWords;
        }

        public static List<string> CollectingWords(List<string> words, string number, bool abbreviated = false, List<string> collectedWords = null)
        {
            if (collectedWords == null)
                collectedWords = new List<string>();

            for (int i = 0; i < words.Count; i++)
            {
                var word = words[i];

                if (CheckWord(word, number))
                {
                    i = -1;

                    int numberLength = number.Length;
                    if (abbreviated)
                        collectedWords[collectedWords.Count - 1] += word;
                    else
                        collectedWords.Add(word);

                    if (word.Length == numberLength)
                        return collectedWords;

                    number = number.Substring(word.Length);
                }

                if (i == words.Count - 1)
                {
                    if (collectedWords.Count > 0)
                    {
                        var abbreviatedWords = words.Select(word =>
                        {
                            if (word.Length > number.Length)
                            {
                                var wordL = word.Length - number.Length;
                                word = word.Substring(wordL);
                            }
                            return word;
                        }).ToList();

                        CollectingWords(abbreviatedWords, number, true, collectedWords);
                    }
                }
            }

            return collectedWords;
        }
        /*
        43550 // hello
        3
        hell
        he
        llo
        -1 
         */
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
}
