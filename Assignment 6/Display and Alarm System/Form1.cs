using System.Windows.Forms;
using ScottPlot;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

using Tools;
using System.Collections;
using System.Linq;
using System.Drawing.Text;
using Microsoft.IdentityModel.Tokens;

namespace Display_and_Alarm_System
{
    public partial class Window : Form
    {
        public int DataId { get; set; }
        public string? DataTimeStamp { get; set; }
        public double DataValue { get; set; }
        public int LocationId { get; set; }
        public string? LocationName { get; set; }

        List<SensorData> sensor_data_list = [];
        List<LocationData> location_data_list = [];
        SensorData sensor_data = new();
        LocationData location_data = new();

        double[] location_ids;
        string[] locations;
        double[] dataX;
        double[] dataY;
        double[] plotted_X;
        string[] unit;
        DateTime[] time;

        public bool alarm_sendt = false;
        public string alarm_email = "";

        public string adresse = "";
        public string name = "";
        public string dataunit = "";

        public Window()
        {
            InitializeComponent();
        }

        // Purpose: Set up program with starting parameters
        // Version: 12/05-24
        // Author: Torstein Solheim Olberg
        private void Window_Load(object sender, EventArgs e)
        {
            CurrentTempPictureBox.Image = System.Drawing.Image.FromFile("../../../NormalImage.png");

            SetAlarmEmail();

            GetLocation();

            try
            {
                GetData();
            }
            catch (Exception)
            {
                DatabaseNameTextBox.Text = "Server Invalid: Try again!";
                DatabaseNameTextBox.Focus();
            }

            UpdateData();
            UnitLabel.Text = dataunit;

            UpdateTimer.Interval = 1000;
            UpdateTimer.Start();
        }

        // Purpose: Get locations from database, update location choises and transform it to usefull format
        // Version: 12/05-24
        // Author: Torstein Solheim Olberg
        void GetLocation()
        {
            location_data_list = location_data.GetLocations();

            //Convert Data from Database to Arrays used by ScottPlot
            location_ids = new double[location_data_list.Count];
            locations = new string[location_data_list.Count];

            int i = 0;
            foreach (LocationData location_data in location_data_list)
            {
                location_ids[i] = location_data.LocationId;
                locations[i] = location_data.LocationName;
                i++;
            }

            LocationChoiceComboBox.DataSource = locations.ToList();
        }

        // Purpose: Get data from database and save it to usefull format
        // Version: 12/05-24
        // Author: Torstein Solheim Olberg
        void GetData()
        {
            if (adresse != "" & name != "")
            {
                sensor_data_list = sensor_data.GetSensorData(adresse, name, location_ids[LocationChoiceComboBox.SelectedIndex].ToString());
            }
            else if (adresse != "")
            {
                sensor_data_list = sensor_data.GetSensorData(adresse, location: location_ids[LocationChoiceComboBox.SelectedIndex].ToString());
            }
            else if (name != "")
            {
                sensor_data_list = sensor_data.GetSensorData(name: name, location: location_ids[LocationChoiceComboBox.SelectedIndex].ToString());
            }
            else
            {
                sensor_data_list = sensor_data.GetSensorData(location: location_ids[LocationChoiceComboBox.SelectedIndex].ToString());
            }

            //Convert Data from Database to Arrays used by ScottPlot
            dataX = new double[sensor_data_list.Count];
            dataY = new double[sensor_data_list.Count];
            unit = new string[sensor_data_list.Count];
            time = new DateTime[sensor_data_list.Count];

            int i = 0;
            foreach (SensorData data in sensor_data_list)
            {
                dataX[i] = data.DataId;
                dataY[i] = data.DataValue;
                unit[i] = data.DataUnit;
                time[i] = data.DataTime;
                i++;
            }
        }

        // Purpose: Update chart and textbox of data info
        // Version: 12/05-24
        // Author: Torstein Solheim Olberg
        void UpdateData(bool clear = false)
        {
            if (unit != null) { dataunit = unit[unit.Length - 1]; } else { dataunit = ""; }
            
            int plotted_length;
            if (plotted_X is null) { plotted_length = 0; } else { plotted_length = plotted_X.Length; }
            int data_length;
            if (dataX is null) { data_length = 0; } else { data_length = dataX.Length; }

            if (data_length != 0 & plotted_length < data_length)
            {
                TempTextBox.Text = Math.Round((decimal)dataY[dataY.Length - 1], 1).ToString();
                if (clear) { CreateChart(time.Select(x => x.ToOADate()).ToArray(), dataY); } else { UpdateChart(time.Select(x => x.ToOADate()).ToArray(), dataY); }
            }
            else if (data_length == 0 & plotted_length != data_length)
            {
                TempTextBox.Text = "No Temperature Data";
                double[] x = [0];
                double[] y = [0];
                CreateChart(x, y);
            }
            else if (data_length != 0 & plotted_length > data_length)
            {
                TempTextBox.Text = Math.Round((decimal)dataY[dataY.Length - 1], 1).ToString();
                CreateChart(time.Select(x => x.ToOADate()).ToArray(), dataY);
            }
            else if (plotted_length == data_length) { }
        }

        // Purpose: Populate the chart
        // Version: 12/05-24
        // Author: Torstein Solheim Olberg
        void CreateChart(double[] dataX, double[] dataY)
        {
            TempDataGraph.Plot.Clear();
            TempDataGraph.Plot.XLabel("Datapoint Id");
            TempDataGraph.Plot.YLabel("Temperature [" + dataunit + "]");
            TempDataGraph.Plot.Title("Temperature Data");
            TempDataGraph.Plot.Axes.DateTimeTicksBottom();

            TempDataGraph.Plot.Add.Scatter(dataX, dataY, color: ScottPlot.Color.FromHex("#FFA71A"));
            TempDataGraph.Refresh();
            TempDataGraph.Plot.Axes.AutoScale();

            plotted_X = (double[])dataX.Clone();
        }

        // Purpose: Update the chart
        // Version: 12/05-24
        // Author: Torstein Solheim Olberg
        void UpdateChart(double[] dataX, double[] dataY)
        {
            TempDataGraph.Plot.Add.Scatter(dataX, dataY, color: ScottPlot.Color.FromHex("#FFA71A"));
            TempDataGraph.Refresh();
            TempDataGraph.Plot.Axes.AutoScale();

            plotted_X = (double[])dataX.Clone();
        }

        // Purpose: Update chart when timer activates
        // Version: 11/05-24
        // Author: Torstein Solheim Olberg
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            GetData();
            UpdateData();
        }

        // Purpose: Update Timer interval when spesified by user
        // Version: 11/05-24
        // Author: Torstein Solheim Olberg
        private void UpdateIntervalTextBox_TextChanged(object sender, EventArgs e)
        {
            _ = int.TryParse(UpdateIntervalTextBox.Text, out int interval);
            if (interval == 0)
            {
                interval = 1;
            }
            UpdateTimer.Interval = 1000 * interval;
        }

        // Purpose: Alert user when temp is alarmingly cold or hot
        // Version: 12/05-24
        // Author: Torstein Solheim Olberg
        private void TempTextBox_TextChanged(object sender, EventArgs e)
        {
            bool result;
            result = float.TryParse(TempTextBox.Text, out float temp);
            if (temp > 11 & temp < 29) { }
            else if (temp > 30 & !alarm_sendt)
            {
                CurrentTempPictureBox.Image = System.Drawing.Image.FromFile("../../../HotImage.png");
                if (alarm_email != "")
                {
                    EmailSender email_sender = new(alarm_email);
                    email_sender.Send("Temperature is to hot! This is dangerous!");
                    alarm_sendt = true;
                }
            }
            else if (temp > 29 | temp > 11)
            {
                CurrentTempPictureBox.Image = System.Drawing.Image.FromFile("../../../NormalImage.png");
                alarm_sendt = false;
            }
            else if (!result)
            {
                CurrentTempPictureBox.Image = System.Drawing.Image.FromFile("../../../NormalImage.png");
                alarm_sendt = false;
            }
            else if (temp < 10)
            {
                CurrentTempPictureBox.Image = System.Drawing.Image.FromFile("../../../ColdImage.png");
                if (alarm_email != "")
                {
                    EmailSender email_sender = new(alarm_email);
                    email_sender.Send("Temperature is to cold! This is dangerous!");
                    alarm_sendt = true;
                }
                
            }
        }

        // Purpose: Set the email used for alarms
        // Version: 15/05-24
        // Author: Torstein Solheim Olberg
        void SetAlarmEmail()
        {
            if (AlarmEmailTextBox.Text == "")
            {
                alarm_email = "mr.torstein@gmail.com";
            }
            else
            {
                alarm_email = AlarmEmailTextBox.Text;
            }
        }

        // Purpose: request new data when new location is chosen
        // Version: 12/05-24
        // Author: Torstein Solheim Olberg
        private void LocationChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData();
            UpdateData(clear: true);

            DisplayTitleLabel.Text = "Data For " + LocationChoiceComboBox.Text;
            UnitLabel.Text = dataunit;
        }

        // Purpose: Connect to specified server at next timer tick
        // Version: 12/05-24
        // Author: Torstein Solheim Olberg
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            adresse = DatabaseAdresseTextBox.Text;
            name = DatabaseNameTextBox.Text;

            try
            {
                GetData();
                UpdateData();
            }
            catch (Exception)
            {
                DatabaseNameTextBox.Text = "Server Invalid: Try again!";
                DatabaseNameTextBox.Focus();
            }
        }
    }
}
