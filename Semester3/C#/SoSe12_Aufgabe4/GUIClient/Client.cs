using System;
using Common;
using System.Windows.Forms;

namespace GUIClient
{
    static class Client
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region input

            double lowerLimit, upperLimit;

            do
            {
                lowerLimit = IOHelper.AskForDouble(false);
                upperLimit = IOHelper.AskForDouble(true);

            } while (lowerLimit >= upperLimit);

            #endregion

            #region processing

            IServer server = (IServer)Util.Connect("localhost", "TServer", 1234, 4711);
            Console.WriteLine("Der Server sagt:");
            Console.WriteLine(server.MessageOfTheDay);

            ICalculateNulls nulls = server.CreateCalculateNulls();

            DemoEquation demo = new DemoEquation();

            Point[] results = nulls.Calculate(demo, lowerLimit, upperLimit);

            CalculateValues cv = new CalculateValues(demo);
            cv.FindValuesInRange(lowerLimit, upperLimit);

            #endregion

            #region output

            ClientGUI plot = new ClientGUI();
            plot.CreateSeries(true, results);
            plot.CreateSeries(false, cv.Values);
            Application.Run(plot);
            
            #endregion
        }
    }
}
