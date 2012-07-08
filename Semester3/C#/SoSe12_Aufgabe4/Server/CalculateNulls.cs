using Common;
using System.Runtime.Remoting;
using System;
using System.Collections.Generic;

namespace Server
{
    public sealed class CalculateNulls : MarshalByRefObject, ICalculateNulls
    {
        public Point[] Calculate(IEquation e, double start, double end)
        {
            List<Point> results = new List<Point>();
            equation ef = e.f;
            CalculateZeros cs = new CalculateZeros(ef);

            cs.FindZerosInRange(start, end);
            results = cs.Zeros;
            return results.ToArray();
        }
    }
}