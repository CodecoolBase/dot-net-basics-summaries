using System;
using System.Collections;

namespace DictionaryCollection
{
    public class Program
    {
        static void Main(string[] args)
        {
            Hashtable lookup = new Hashtable
            {
                ["0"] = "Zero",
                ["1"] = "One",
                ["2"] = "Two",
                ["3"] = "Three",
                ["4"] = "Four",
                ["5"] = "Five",
                ["6"] = "Six",
                ["7"] = "Seven",
                ["8"] = "Eight",
                ["9"] = "Nine"
            };

            string ourNumber = "888-555-1212";

            foreach (char currentChar in ourNumber)
            {
                string digit = currentChar.ToString();
                if (lookup.ContainsKey(digit))
                {
                    Console.WriteLine(lookup[digit]);
                }
            }

            Console.ReadKey();
        }
    }
}
