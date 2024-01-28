using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;



// https://dotnetcoretutorials.com/knapsack-algorithm-in-c/
// https://www.geeksforgeeks.org/trie-insert-and-search/
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
        public static void CheckNumbers(List<List<string>> words, List<string> phoneNumbers)
        {
            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                SortByLenght(words[i]);
                var searchedWords = CollectingWords(words[i], phoneNumbers[i]);
                OutPut(searchedWords);
            }
        }
        /*
43550 
3
hell
he
llo
-1 
 */
        public static List<string> CollectingWords(List<string> words, string number)
        {
            List<string> collectedWords = new List<string>();

            // yvela sityvas gadavuvlit 
            for (int i = 0; i < words.Count; i++)
            {
                // shevamowmebt tua shesadzlebeli gamoyenebul iqnas es sityva 
                if (CheckWord(words[i], number))
                {
                    collectedWords.Add(words[i]);

                    if (words[i].Length == number.Length)
                        return collectedWords;

                    number = number.Substring(words[i].Length);

                    //Tu sityva arsebobs,iqneb kide iarsebos pontshi tavidan vabrunebt
                    i = -1;
                }

            }

            var shortedWords = ShortingWords(words, number);
            for (int i = 0; i < shortedWords.Count; i++)
            {
                    if (CheckWord(shortedWords[i], number))
                    {
                        collectedWords[collectedWords.Count - 1] += shortedWords[i];

                        if (shortedWords[i].Length == number.Length)
                            return collectedWords;

                        number = number.Substring(shortedWords[i].Length);

                        //Tu sityva arsebobs,iqneb kide iarsebos pontshi tavidan vabrunebt
                        i = -1;
                    }
            }

            return null;
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
        public static List<string> ShortingWords(List<string> words, string number)
        {
            return words = words.Select(word => ShortingWord(word, number)).ToList();
        }
        public static string ShortingWord(string word, string number)
        {
            if (word.Length > number.Length)
            {
                var wordL = word.Length - number.Length;
                word = word.Substring(wordL);
            }

            return word;
        }
        public static void SortByLenght(List<string> words)
        {
            words.Sort((x, y) => y.Length.CompareTo(x.Length));
        }

        #region I/O
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
        #endregion
    }
}
