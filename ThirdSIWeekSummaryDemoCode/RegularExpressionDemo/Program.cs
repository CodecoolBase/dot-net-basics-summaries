using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace RegularExpressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo01SearchingInText();
            Demo02SubStringReplace();
            Demo03Encoding();
            Demo04EncodingTables();
            Demo05WriteToFile();
            Demo06ReadFromFile();

            Console.ReadKey();
        }

        public static void Demo01SearchingInText()
        {
            string reg = "[a-z]{4}";
            Match m = Regex.Match("Apple is on tree", reg);
            Console.WriteLine(m.Groups[0]);
        }

        public static void Demo02SubStringReplace()
        {
            //The Regex.Replace() -> We can refer to the pattern with expression name (${név})
            var input = "apple app le let's see apple";
            Regex.Replace(input, "a(?<mid>pple)", "${mid}a${mid}");
            Console.WriteLine(input);
        }

        public static void Demo03Encoding()
        {
            Encoding e = Encoding.GetEncoding("Korean");
            byte[] encoded = e.GetBytes("Hello world!");

            for (int i = 0; i < encoded.Length; ++i)
            {
                Console.WriteLine("Byte {0}: {1}", i, encoded[i]);
            }
        }

        public static void Demo04EncodingTables()
        {
            EncodingInfo[] ei = Encoding.GetEncodings();

            foreach (EncodingInfo e in ei)
            {
                Console.WriteLine("{0}: {1}, {2}",
                                e.CodePage,
                                e.Name,
                                e.DisplayName);
            }
        }

        public static void Demo05WriteToFile()
        {
            StreamWriter swUtf7 = new StreamWriter("utf7.txt", false, Encoding.UTF7);
            swUtf7.WriteLine("Hello world!");
            swUtf7.Close();
        }

        public static void Demo06ReadFromFile()
        {
            StreamReader srUtf7 = new StreamReader("utf7.txt", Encoding.UTF7, false);
            Console.WriteLine(srUtf7.ReadToEnd());
            srUtf7.Close();
        }
    }
}
