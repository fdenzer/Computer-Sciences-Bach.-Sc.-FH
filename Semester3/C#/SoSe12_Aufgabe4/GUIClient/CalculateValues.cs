using System;
using System.Collections.Generic;
using Common;


namespace GUIClient
{
    public sealed class CalculateValues
    {

        #region private attributes

        private IEquation myFunc;
        private double segmentWidth;
        private List<Point> values;

        #endregion

        #region property accessors

        public Point[] Values
        {
            get { return values.ToArray(); }
        }

        public IEquation MyFunc
        {
            get { return myFunc; }
        }

        public double SegmentWidth
        {
            get { return segmentWidth; }
            set { segmentWidth = value; }
        }

        #endregion

        #region constructor(s)

        public CalculateValues(IEquation _myFunc)
        {
            segmentWidth = 0.01d;
            values = new List<Point>();
            myFunc = _myFunc;
        }

        #endregion

        #region method(s)

        public void FindValuesInRange(double lowerLimit, double upperLimit)
        {
            double x = lowerLimit;
            int k = 1;

            // seems overcomplicated, but k times segmentWidth is more exact than x += segmentWidth
            for (x = lowerLimit; x <= upperLimit; x = lowerLimit + (k++) * segmentWidth)
            {

                values.Add(Util.newPoint(x, myFunc.f(x)));

            }
        }

        #endregion
    }
}