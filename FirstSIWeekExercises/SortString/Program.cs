using System;

namespace SortString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Microsoft .NET Framework 2.0 Application Development Foundation";
            string[] splittedText = text.Split(' ');

            Array.Sort(splittedText);

            text = string.Join(" ", splittedText);
            Console.WriteLine(text);
            Console.ReadKey();
        }
    }
}
