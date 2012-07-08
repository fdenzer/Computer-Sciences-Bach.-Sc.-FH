using System;
using Common;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUIClient
{
    public partial class ClientGUI : Form
    {
        
        int seriesCount;

        public int SeriesCount {
            get { return seriesCount; }
        }

        /// <summary>
        /// Adds one more scatter plot.
        /// </summary>
        /// <param name="listed">sets x-value-labels and makes marker larger</param>
        /// <param name="values">list of double x-y-coordinates</param>
        public void CreateSeries(bool listed, Point[] values) {

            if (seriesCount++ > 0) chart.Series.Add("Series" + seriesCount);

            foreach (var valuePair in values) {
                if (listed) xy_values.Items.Add("Nullstelle: X: " + valuePair.x + " Y: " + valuePair.y);
                chart.Series["Series" + seriesCount as String].Points.AddXY(valuePair.x, valuePair.y);
            }

            // Set point chart type
            chart.Series["Series" + seriesCount as String].ChartType = SeriesChartType.Point;

            // Set marker size
            chart.Series["Series" + seriesCount as String].MarkerSize = 10 + (listed ? 3 : -3);

            // Set marker shape
            chart.Series["Series" + seriesCount as String].MarkerStyle = MarkerStyle.Diamond;
        }

        public ClientGUI()
        {
            InitializeComponent();
            seriesCount = 0;
        }
    }
}
