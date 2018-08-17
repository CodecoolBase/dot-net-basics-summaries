using System;

namespace FirstSIWeekSummaryDemoCode
{
    public struct CoOrds
    {
        public int X;
        public int Y;

        public CoOrds(int x, int y)
        {
            X = x;
            Y = y;
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
        private readonly int _data;

        public string Name { get; set; }

        static void Main(string[] args)
        {
            Nullable<bool> nullableBool = null;
            bool? anotherNullableBool = null;

            Milk fifteenLitreMilk = new Milk(15);
            Console.WriteLine($"My milk is: {fifteenLitreMilk.Capacity} l");

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

        public bool IsLess(int treshold)
        {
            return this._data < treshold;
        }

        delegate double Method();
    }
}
