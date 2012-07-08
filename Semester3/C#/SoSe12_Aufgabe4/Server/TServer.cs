using System;
using Common;

namespace Server
{
    public sealed class TServer : MarshalByRefObject, IServer
    {
        ICalculateNulls IServer.CreateCalculateNulls()
        {
            return new CalculateNulls();
        }

        public string MessageOfTheDay
        {
            get { return "Welcome on the server ..."; }
        }
    }
}
