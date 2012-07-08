using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Security.Permissions;
using System.Collections;

namespace Common
{
    public static class Util
    {
        public static double ReadDouble()
        {

            double real;

            while (true)
            {
                try
                {
                    real = Convert.ToDouble(Console.ReadLine());
                    return real;
                }
                catch (FormatException e)
                {
                    Console.Write("{0}\nNochmal bitte: ", e.Message);
                }
            }
        }

        /// <summary>
        /// Die Connect-Methode gibt das Server-Control-Interface zurück
        /// </summary>
        [SecurityPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]   //  demand all rights
        public static object Connect(string server, string typeName, int serverPort, int clientPort)
        {
            BinaryClientFormatterSinkProvider ch = new BinaryClientFormatterSinkProvider();
            TcpChannel chan = (TcpChannel)ChannelServices.GetChannel("tcp");        //  find TCP-Channel
            IDictionary prop = new Hashtable();
            prop["port"] = clientPort;
            prop["typeFilterLevel"] = TypeFilterLevel.Full;
            if (chan == null)                                           //  if channel chan is free
            {
                chan = new TcpChannel(prop, ch, null);                  //  create new Channel
                ChannelServices.RegisterChannel(chan, false);           //  register channel
            }
            return Activator.GetObject(typeof(MarshalByRefObject), "tcp://" + server + ":" + serverPort.ToString() + "/" + typeName);                //  Server-Control-Interface vom Server abfragen
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public static void RegisterObject(Type t, int port)
        {
            BinaryClientFormatterSinkProvider bsp1 = new BinaryClientFormatterSinkProvider();
            BinaryServerFormatterSinkProvider bsp2 = new BinaryServerFormatterSinkProvider();
            bsp2.TypeFilterLevel = TypeFilterLevel.Full;                //  activate deserialize on all data types

            IDictionary prop = new Hashtable();                         //  create new Hashtable
            prop["port"] = port;                                        //  set value for "port" in hashtable to port
            prop["typeFilterLevel"] = TypeFilterLevel.Full;             //  set value for typeFilterLevel

            TcpChannel chan = (TcpChannel)ChannelServices.GetChannel("tcp");        //  find TCP-Channel
            if (chan == null)                                                       //  if channel chan is free
            {
                chan = new TcpChannel(prop, bsp1, bsp2);                //  create channel
                ChannelServices.RegisterChannel(chan, false);           //  register channel
            }

            RemotingConfiguration.RegisterWellKnownServiceType(
                t, t.Name,
                WellKnownObjectMode.Singleton);                         //  register class "server" on the channel
        }

        public static Point newPoint(double x, double y)
        {
            Point t;
            t.x = x;
            t.y = y;
            return t;
        }
    }
}
