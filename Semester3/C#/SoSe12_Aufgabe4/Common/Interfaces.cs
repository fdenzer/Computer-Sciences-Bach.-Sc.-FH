using System;

namespace Common
{
    public delegate double equation(double x);

    [Serializable]
    public struct Point
    {
        public double x, y;
    }

    public interface IEquation
    {
        double f(double x);
    }

    public interface ICalculateNulls
    {
        Point[] Calculate(IEquation e, double start, double end);
    }

    public interface IServer
    {
        string MessageOfTheDay { get; }
        ICalculateNulls CreateCalculateNulls();
    }
}
