using Microsoft.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices.JavaScript;
using System.Windows.Forms;

namespace Tools
{
    internal class LocationData
    {
        public int LocationId { get; set; }
        public string? LocationName { get; set; }

        // Purpose: Get location data from database
        // Version: 12/05-24
        // Author: Torstein Solheim Olberg
        public List<LocationData> GetLocations(string adresse = "BEIST\\SQLEXPRESS", string name = "Temperature Logging and Control System")
        {
            //string location_connection_string = "Data Source=" + adresse + ";Initial Catalog=" + name + ";Integrated Security=True; TrustServerCertificate=True";
            string location_connection_string = "Server=tcp:BEIST,49172;Database=Temperature Logging and Control System;User Id=HPC3407;Password=kranbil1a;TrustServerCertificate=True";

            List<LocationData> location_data_list = [];
            SqlConnection loc_con = new(location_connection_string);

            string locationSQL = "select LocationId, Description from Location";
            loc_con.Open();
            SqlCommand loc_cmd = new(locationSQL, loc_con);
            SqlDataReader loc_dr = loc_cmd.ExecuteReader();

            if (loc_dr != null)
            {
                while (loc_dr.Read())
                {
                    LocationData location_data = new()
                    {
                        LocationId = Convert.ToInt32(loc_dr["LocationId"]),
                        LocationName = Convert.ToString(loc_dr["Description"])
                    };
                    location_data_list.Add(location_data);
                }
            }

            return location_data_list;
        }
    }

    internal class SensorData
    {
        public int DataId { get; set; }
        public double DataValue { get; set; }
        public string? DataUnit { get; set; }
        public DateTime DataTime { get; set; }

        // Purpose: Get sensor data from database
        // Version: 12/05-24
        // Author: Torstein Solheim Olberg
        public List<SensorData> GetSensorData(string adresse = "BEIST\\SQLEXPRESS", string name = "Temperature Logging and Control System", string location = "0")
        {
            //string connectionString = "Data Source=" + adresse + ";Initial Catalog=" + name + ";Integrated Security=True; TrustServerCertificate=True";
            string connection_string = "Server=tcp:BEIST,49172;Database=Temperature Logging and Control System;User Id=HPC3407;Password=kranbil1a;TrustServerCertificate=True";

            List<SensorData> sensorDataList = [];
            SqlConnection con = new(connection_string);

            string selectSQL = "select DataId, Value, Unit, Time from Datapoint where LocationId = " + location;
            con.Open();
            SqlCommand cmd = new(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    SensorData sensorData = new()
                    {
                        DataId = Convert.ToInt32(dr["DataId"]),
                        DataValue = Convert.ToDouble(dr["Value"]),
                        DataUnit = Convert.ToString(dr["Unit"]),
                        DataTime = Convert.ToDateTime(dr["Time"])
                    };
                    sensorDataList.Add(sensorData);
                }
            }
            return sensorDataList;
        }
    }

    internal class EmailSender(string email_adresse)
    {
        // Purpose: Send email used for alarms
        // Version: 15/05-24
        // Author: Torstein Solheim Olberg
        public void Send(string message) 
        {
            MailAddress from = new MailAddress("mr.torstein@gmail.com", "Temperature Logging and Control System System");
            MailAddress to = new MailAddress(email_adresse);
            SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 25);
            MailMessage msgMail = new();
            msgMail.From = from;
            msgMail.To.Add(to);
            msgMail.Subject = "Temperature Alarm";
            msgMail.Body = message;
            msgMail.IsBodyHtml = true;
            NetworkCredential cred = new NetworkCredential("mr.torstein@gmail.com", "kwjv lwhn ccvt krtk");
            mailClient.Credentials = cred;
            mailClient.EnableSsl = true;
            mailClient.Send(msgMail);
            msgMail.Dispose();
        }
    }
}