using System;
using System.Text;

namespace GUIClient {
    public static class IOHelper {

        public static double AskForDouble(bool upperLimit) {

            double real;

            while (true) {
                try {
                    if (upperLimit) {
                        real = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Obere Grenze", "Input", "1,0"));
                    } else {
                        real = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Untere Grenze", "Input", "0,0"));
                    }
                    return real;
                }
                catch (FormatException e) {
                    Console.Write("{0}\nNochmal bitte: ", e.Message);
                }
            }
        }
    }
}
