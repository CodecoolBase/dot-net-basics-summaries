namespace FirstSIWeekSummaryDemoCode.Geo
{
    public class Rectangle : Polygon
    {
        private int _a, _b;

        public int A
        {
            get { return _a; }
            set { _a = value; }
        }

        public int B
        {
            get { return _b; }
            set { _b = value; }
        }

        public Rectangle(int a, int b) : base()
        {
            this._a = a;
            this._b = b;
        }

        public override double Area()
        {
            return _a * _b;
        }

        public override double Range()
        {
            return 2 * (_a + _b);
        }
    }
}
