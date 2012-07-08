using System;
using Common;

namespace Client
{
    public sealed class DemoEquation : MarshalByRefObject, IEquation
    {
        public double f(double x)
        {
            return (x == 0.0) ? 30.0 : Math.Sin(30.0 * x) / x;
        }
    }
}
