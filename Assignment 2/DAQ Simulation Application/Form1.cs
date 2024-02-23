using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.Globalization;
using static System.Windows.Forms.LinkLabel;
using SensorApp;

namespace DAQ_Simulation_Application
{
    // Purpose: Controlling the programs behaviour
    // Version: 04/02-24
    // Author: Torstein Solheim Olberg
    public partial class main_window : Form
    {
        readonly int sampling_time = 55000;

        readonly List<Sensor> sensors = [];
        readonly List<Sensordata> samples = [];

        Boolean sampling_status = false;


        // Purpose: Initialize class and GUI components
        // Version: 04/02-24
        // Author: Torstein Solheim Olberg
        public main_window()
        {
            InitializeComponent();

            for (int i = 0; i < 9; i++)
            {
                sensors.Add(new Sensor(i));
            }

            sampling_timer.Interval = sampling_time;
        }

        // Purpose: Take one sample for each sensor, save them and display them
        // Version: 04/02-24
        // Author: Torstein Solheim Olberg
        private void TakeSample()
        {
            DateTime time = DateTime.Now;
            sensor_value_textbox.Text += time.ToString() + ": ";
            samples.Add(new Sensordata());
            samples[^1].Date = time.ToString();
            for (int i = 0; i < sensors.Count; i++)
            {
                samples[^1][i] = sensors[i].GetNewValue();
                sensor_value_textbox.Text += samples[^1][i].ToString() + Environment.NewLine;
            }
            LogSamples();
        }

        // Purpose: Save samples gotten to a csv file
        // Version: 04/02-24
        // Author: Torstein Solheim Olberg
        private void LogSamples()
        {
            string path = "../../../data/";
            string filename;


            if (logging_filename_textbox.Text == "")
            {
                filename = DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".csv";
            }
            else if (logging_filename_textbox.Text.ToLower().Contains(".csv", StringComparison.CurrentCulture))
            {
                filename = logging_filename_textbox.Text;
            }
            else
            {
                filename = logging_filename_textbox.Text + ".csv";
            }

            FileInfo outfile_info = new(path + filename);
            Boolean appending = false;
            if (outfile_info.Exists)
            {
                appending = true;
            }

            using (StreamWriter outfile = new(Path.Combine(path, filename), appending))
            {
                if (!appending)
                {
                    outfile.WriteLine("Date;Sensor 1;Sensor 2;Sensor 3;Sensor 4;Sensor 5;Sensor 6;Sensor 7;Sensor 8;Sensor 9");
                }
                foreach (Sensordata sample in samples)
                    outfile.WriteLine(
                        "{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}",
                        sample.Date,
                        sample[0],
                        sample[1],
                        sample[2],
                        sample[3],
                        sample[4],
                        sample[5],
                        sample[6],
                        sample[7],
                        sample[8]
                    );
            }

            samples.Clear();
        }

        // Purpose: Activate or deactivate a sampling session when sampling button is clicked
        // Version: 30/01-24
        // Author: Torstein Solheim Olberg
        private void SampleButtonClick(object sender, EventArgs e)
        {
            if (!sampling_status)
            {
                sampling_status = true;
                sample_button.Text = "Stop Sampling";
                sample_once_button.Enabled = false;

                if (!sampling_timer.Enabled)
                {
                    if (samples.Count == 0)
                    {
                        sensor_value_textbox.Text = "";
                    }
                    TakeSample();
                    sampling_timer.Start();
                }
            }
            else
            {
                sampling_status = false;
                sample_button.Text = "Start Sampling";
            }
        }

        // Purpose: Sample sensors once and deactivate sampling until interval is passed
        // Version: 30/01-24
        // Author: Torstein Solheim Olberg
        private void SampleOnceButtonClick(object sender, EventArgs e)
        {
            TakeSample();
            sampling_timer.Start();
            sample_once_button.Enabled = false;
        }

        // Purpose: Sample or reactivate sampling once when sampling interval has passed
        // Version: 30/01-24
        // Author: Torstein Solheim Olberg
        private void SamplingTimerTick(object sender, EventArgs e)
        {
            if (sampling_status)
            {
                TakeSample();
            }
            else
            {
                sampling_timer.Stop();
                sample_once_button.Enabled = true;
            }
        }

        // Purpose: Display Help message when Help is clicked
        // Version: 04/02-24
        // Author: Torstein Solheim Olberg
        private void HelpToolStripMenuItemClick(object sender, EventArgs e)
        {
            string first_line = "This is a program generating a dataset and saving it to a csv file.\n";
            string second_line = "You can either start a sampling session where a sample is collected\n";
            string third_line = "every 55 seconds, or sample yourself. But sampling is not allowed more\n";
            string fourth_line = "often than every 55 seconds.\nYou can specify a name for the csv file";
            string fifth_line = "to log to, or the program will \nuse the time of the logging as the name file.";
            MessageBox.Show(first_line + second_line + third_line + fourth_line + fifth_line, "Help Page", MessageBoxButtons.OK);
        }
    }
}