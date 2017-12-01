using System;

namespace FirstSIWeekSummaryDemoCode.Geo
{
    class BaseShape
    {

    }

    class Triangle : BaseShape, IShape
    {
        private int _a, _b, _c;

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
