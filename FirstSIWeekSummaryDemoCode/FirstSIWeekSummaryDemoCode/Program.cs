using System;

namespace FirstSIWeekSummaryDemoCode
{
    public struct CoOrds
    {
        public int X, Y;

        public CoOrds(int p1, int p2)
        {
            X = p1;
            Y = p2;
        }
    }

    public struct Milk
    {
        public int Capacity;

        public Milk(int cap)
        {
            Capacity = cap;
        }
    }

    public enum MilkType
    {
        Soja,
        Fatty,
        Rice
    };

    class Program
    {
        private int _data;

        public string Name { get; set; }

        static void Main(string[] args)
        {
            Nullable<bool> b = null;
            bool? c = null;

            Milk m = new Milk(15);
            Console.WriteLine("My milk is: " + m.Capacity + " l");

            ExtensionMethodDemo();

            Console.ReadLine();
        }

        private static void ExtensionMethodDemo()
        {
            int luckyNumber = 12;
            Console.WriteLine(luckyNumber);
            int result = luckyNumber.PlusFive();
            Console.WriteLine(result);
        }

        public bool IsLEss(int treshold)
        {
            return this._data < treshold;
        }

        delegate double Method();
    }
}
