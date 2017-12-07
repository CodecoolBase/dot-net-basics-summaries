using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsSummary
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo1ArrayListUsage();

            Demo2HashTable();

            //Demo3Enumerator();

            //Demo4Comparer();

            //Demo5GenericMin(5, 6, "Numbers are compared");
            //Demo5GenericMin("asdas", ".yxcyxc", "Texts are compared");

            Console.ReadLine();
        }

        private static void Demo1ArrayListUsage()
        {
            var arraylist = GetArrayList();
            Console.WriteLine("ArrayList first:");
            foreach (object o in arraylist)
            {
                Console.WriteLine(o); //54, apple
            }

            arraylist.AddRange(arraylist); //54, apple, 54, apple
            arraylist.Remove(54);
            arraylist.RemoveAt(1);

            Console.WriteLine("ArrayList after a bit change:");
            foreach (string s in arraylist)
            {
                Console.WriteLine(s);
            }

            while (arraylist.Contains("apple"))
            {
                int i = arraylist.IndexOf("apple");
                arraylist.RemoveAt(i);
            } //empty list

            Console.WriteLine("ArrayList after remove apples:");
            foreach (string s in arraylist)
            {
                Console.WriteLine(s);
            }
        }

        private static void Demo2HashTable()
        {
            //Hashtable hashtable = new Hashtable();
            //hashtable.Add(1982, "Kovács Viktória");
            //hashtable.Add(1985, "Nagy Géza");
            
            //simplified object instantiation
            Hashtable hashtable = new Hashtable
            {
                { 1982, "Kovács Viktória" },
                { 1985, "Nagy Géza" }
            };
            
            hashtable[1983] = "Kiss Erika";
            hashtable[1985] = "Varga János";
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine($"Winner who was born in {item.Key}. is: {item.Value}");
                //Varga János
                //Kiss Erika
                //Kovács Viktória
            }
            hashtable.Remove(1983);
            Console.WriteLine("1983 is removed.");
            foreach (DictionaryEntry hashItem in hashtable)
            {
                Console.WriteLine($"Winner who was worn in {hashItem.Key}. is: {hashItem.Value}");
            }
        }

        private static void Demo3Enumerator()
        {
            IEnumerable arraylist = GetArrayList();
            IEnumerator enumerator = arraylist.GetEnumerator();
            while (enumerator.MoveNext())
                Console.WriteLine(enumerator.Current);

            Console.WriteLine("Let's see via foreach:");
            foreach (var item in arraylist)
            {
                Console.WriteLine(item);
            }
        }

        private static void Demo4Comparer()
        {
            //Investigate LengthComparer class
            Dictionary<Point, string> apexis = new Dictionary<Point, string>(new LengthComparer());
            try
            {
                apexis.Add(new Point(1, 1), "A");
                apexis.Add(new Point(1, 2), "B");
                //Abs(x + y) is equal -> throw error
                var point = new Point(1, -1);
                if (!apexis.ContainsKey(point))
                {
                    apexis.Add(point, "C");
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }

            foreach (KeyValuePair<Point, string> coordinateInfo in apexis)
            {
                Console.WriteLine("{0}: {1}", coordinateInfo.Value, coordinateInfo.Key);
            }
        }

        public static void Demo5GenericMin<T>(T a, T b, string msg) where T : IComparable<T>
        {
            Console.WriteLine("The bigger from:\n (a), {0} \n (b), {1}", a, b);
            var aIsLessThanB = a.CompareTo(b) < 0 ? "a" : "b";
            Console.WriteLine(aIsLessThanB);
            Console.WriteLine("-----------");
            Console.WriteLine("your message was: " + msg);
        }

        private static ArrayList GetArrayList()
        {
            ArrayList arraylist = new ArrayList();
            arraylist.Add("apple");
            arraylist.Insert(0, 32);
            arraylist[0] = 54;
            return arraylist;
        }

        private static List<int> GetIntList()
        {
            List<int> letsSee = new List<int>();

            letsSee.Add(5);
            letsSee.Add(5);
            letsSee.Add(5);
            letsSee.Add(5);

            return letsSee;
        }
    }
}
