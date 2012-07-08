using System;
using Common;

namespace Client
{
    sealed class ClientConsole
    {
        static void Main(string[] args)
        {
            double lowerLimit, upperLimit;

            do
            {
                Console.Write("Bitte das untere Intervalllimit (z.B. 0,0) eingeben: ");
                lowerLimit = Util.ReadDouble();

                Console.Write("Bitte das obere Intervalllimit (z.B. 1,0) eingeben: ");
                upperLimit = Util.ReadDouble();

            } while (lowerLimit >= upperLimit);

            IServer server = (IServer)Util.Connect("localhost", "TServer", 1234, 4711);
            Console.WriteLine("Der Server sagt:");
            Console.WriteLine(server.MessageOfTheDay);

            ICalculateNulls nulls = server.CreateCalculateNulls();

            Point[] results = nulls.Calculate(new DemoEquation(), lowerLimit, upperLimit);

            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine(results[i].x + " => " + results[i].y);
            }

            Console.WriteLine("\nEingabetaste zum beenden.");
            Console.ReadLine();
        }
    }
}
