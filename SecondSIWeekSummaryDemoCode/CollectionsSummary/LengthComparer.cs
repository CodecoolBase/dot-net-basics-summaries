using System;
using System.Collections.Generic;

namespace CollectionsSummary
{
    public class LengthComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point x, Point y)
        {
            return (Math.Abs(x.X) + Math.Abs(x.Y)) == (Math.Abs(y.X) + Math.Abs(y.Y));
        }
        public int GetHashCode(Point obj)
        {
            return Math.Abs(obj.X) + Math.Abs(obj.Y);
        }
    }
}
