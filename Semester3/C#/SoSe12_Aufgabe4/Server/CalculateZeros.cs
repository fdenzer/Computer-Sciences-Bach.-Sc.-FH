using System;
using System.Collections.Generic;
using Common;

namespace Server
{
    public sealed class CalculateZeros
    {

        #region protected attributes

        private double segmentWidth, epsilon;
        private List<Point> zeros;
        private equation e;

        #endregion

        #region property accessors

        public double Epsilon
        {
            get { return epsilon; }
            set { epsilon = value; }
        }

        public double SegmentWidth
        {
            get { return segmentWidth; }
            set { segmentWidth = value; }
        }

        public List<Point> Zeros
        {
            get { return zeros; }
            set { zeros = value; }
        }

        #endregion

        #region constructor(s)

        public CalculateZeros(equation _e)
        {
            segmentWidth = 0.01d;
            epsilon = 1E-15;
            zeros = new List<Point>();
            e = _e;
        }

        #endregion

        #region other methods

        public void FindZerosInRange(double lowerLimit, double upperLimit)
        {
            double localEpsilon, y, x = lowerLimit;
            double absLowerLimit = Math.Abs(lowerLimit), absUpperLimit = Math.Abs(upperLimit);      // calculate absolute values
            double max = (absLowerLimit >= absUpperLimit) ? absLowerLimit : absUpperLimit;          // find number with higher order of magnitude
            localEpsilon = Math.Pow(10, Math.Log10(max) - 15);

            int k = 1;

            // seems overcomplicated, but k times segmentWidth is more exact than x += segmentWidth
            for (x = lowerLimit; x <= upperLimit; x = lowerLimit + (k++) * segmentWidth)
            {

                y = e(x);

                if (Math.Sign(y) == 0)
                {
                    // found zero
                    zeros.Add(Util.newPoint(x, y));

                }
                else if (Math.Sign(y) == -Math.Sign(e(x + segmentWidth)))
                {
                    // start of interval bisection
                    Bisect(x, x + segmentWidth, localEpsilon);
                }
            }
        }

        private void Bisect(double lowerLimit, double upperLimit, double localEpsilon)
        {

            double middle;

            // do the if-part in interval containing zero
            if (Math.Sign(e(lowerLimit)) == -Math.Sign(e(upperLimit)))
            {

                // checks exit condition: x-values diverge little, making the segment small enough
                middle = (lowerLimit + upperLimit) / 2.0d;
                if ((upperLimit - lowerLimit) <= localEpsilon)
                {
                    zeros.Add(Util.newPoint(middle, e(middle)));

                }
                else
                {
                    // divide interval and and check smaller sections
                    // first half
                    Bisect(lowerLimit, middle, localEpsilon);
                    // second half
                    Bisect(middle, upperLimit, localEpsilon);
                }
            }
        }

        #endregion
    }
}