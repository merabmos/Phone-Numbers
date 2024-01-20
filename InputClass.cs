using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ReverseRoot
{
    public class InputClass
    {
        public  List<List<string>> Input(out List<string> phoneNumbers)
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

        public  string InputPhoneNumber()
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
        public  int InputWordsTotalNumber()
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
        public List<string> InputWords(int wordsTotalNumber)
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
    }
}
