using System;
using Common;

namespace Server
{
    sealed class Server
    {
        static void Main(string[] args)
        {
            Util.RegisterObject(typeof(TServer), 1234);
            Console.WriteLine("Server started!");
            Console.WriteLine("\nPress any key to exit ... ");

            while (!Console.KeyAvailable)                       //  do until key pressed
                System.Threading.Thread.Sleep(200);             //  sleep for 200 ms
        }
    }
}
