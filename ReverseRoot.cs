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
                var number = Console.ReadLine();
                var regex = new Regex("^[0-9]+$");

                if (number == "-1")
                {
                    return number;
                }
                else if (number.Length > 100)
                {
                    Console.WriteLine("Phone number length must be lower than 100.");
                    Console.WriteLine("Try Again :");
                }
                else if (!regex.Match(number).Success)
                {
                    Console.WriteLine("Please enter only numbers.");
                    Console.WriteLine("Try Again :");
                }
                else
                    return number;
            }
        }
        public static int InputWordsTotalNumber()
        {
            while (true)
            {
                var number = Console.ReadLine();
                var regex = new Regex("^[0-9]+$");

                if (!regex.Match(number).Success)
                {
                    Console.WriteLine("Please enter only number.");
                    Console.WriteLine("Try Again :");
                }
                else
                {
                    var parsedNumber = int.Parse(number);

                    if (parsedNumber > 50000 && parsedNumber < 1)
                    {
                        Console.WriteLine("Number must be lower than 50000 and higher than 0");
                        Console.WriteLine("Try Again :");
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

                var word = Console.ReadLine();
                var regex = new Regex("^[a-z]+$");

                if (word.Length > 50)
                {
                    Console.WriteLine("Word length must be lower than 50.");
                    Console.WriteLine("Try Again :");
                }
                else if (!regex.Match(word).Success)
                {
                    Console.WriteLine("Please enter only letters.");
                    Console.WriteLine("Try Again :");
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

        public static List<string> CollectingWords(List<string> words, string number)
        {
            List<string> collectedWords = new List<string>();

            for (int i = 0; i < words.Count; i++)
            {
                var word = words[i];
                if (CheckWord(word, number))
                {
                    i = -1;
                    int numberLength = number.Length;

                    collectedWords.Add(word);

                    if (word.Length == numberLength)
                        return collectedWords;

                    number = number.Substring(word.Length);
                }
            }

            return collectedWords;
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
}
