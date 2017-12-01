namespace FirstSIWeekSummaryDemoCode.Geo
{
    public class Circle
    {
        private double rad;

        public double Rad
        {
            get { return rad; }
            set
            {
                if (value > 0)
                    rad = value;
            }
        }
        public Circle(double s)
        {
            Rad = s;
        }

        public double Area()
        {
            return 2 * 3.14 * Rad;
        }
    }
}
