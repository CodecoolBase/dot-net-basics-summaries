using System;

namespace FirstSIWeekSummaryDemoCode.Geo
{
    public class BaseShape
    {

    }

    public class Triangle : BaseShape, IShape
    {
        private readonly int _a;
        private readonly int _b;
        private readonly int _c;

        public Triangle(int a, int b, int c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public double Range()
        {
            return _a + _b + _c;
        }

        public double Area()
        {
            throw new NotImplementedException();
        }
    }
}
