namespace FirstSIWeekSummaryDemoCode.Geo
{
    public class Circle
    {
        private double _radius;

        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value > 0)
                    _radius = value;
            }
        }
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Area()
        {
            return 2 * System.Math.PI * Radius;
        }
    }
}
