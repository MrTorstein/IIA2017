using ScottPlot;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

using Tools;
using System.Collections;
using System.Linq;

namespace Database_Displayer
{
    public partial class Form1 : Form
    {
        public int DataId { get; set; }
        public string? DataTimeStamp { get; set; }
        public double DataValue { get; set; }

        double[] dataX;
        double[] dataY;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetData();

            timer1.Interval = 1000;
            timer1.Start();
        }

        void GetData()
        {
            List<SensorData> sensorDataList = new List<SensorData>();
            SensorData sensorData = new SensorData();
            sensorDataList = sensorData.GetSensorData();

            //Convert Data from Database to Arrays used by ScottPlot
            dataX = new double[sensorDataList.Count];
            dataY = new double[sensorDataList.Count];

            int i = 0;
            foreach (SensorData data in sensorDataList)
            {
                dataX[i] = data.DataId;
                dataY[i] = data.DataValue;
                i++;
            }

            CreateChart(dataX, dataY);
        }

        void CreateChart(double[] dataX, double[] dataY)
        {
            formsPlot1.Plot.XLabel("Datapoint Id");
            formsPlot1.Plot.YLabel("Temperature [Celsius]");
            formsPlot1.Plot.Title("NI USB-TC01 Sensor");

            formsPlot1.Plot.Add.Scatter(dataX, dataY, color: ScottPlot.Color.FromHex("#FFA71A"));
            formsPlot1.Refresh();
            formsPlot1.Plot.Axes.AutoScale();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
