using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace Tools
{
    public class SensorData
    {
        public int SensorId { get; set; }
        public double Value { get; set; }
        public DateTime LogTime { get; set; }
        public List<SensorData> GetSensorData()
        {
            string connectionString = "server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            List<SensorData> sensorDataList = new List<SensorData>();
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "select SensorId, Value, LogTime from DATAPOINT where LogId = 0";
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    SensorData sensorData = new SensorData();
                    sensorData.SensorId = Convert.ToInt32(dr["SensorId"]);
                    sensorData.Value = Convert.ToDouble(dr["Value"]);
                    sensorData.LogTime = Convert.ToDateTime(dr["LogTime"]);
                    sensorDataList.Add(sensorData);
                }
            }
            con.Close();
            return sensorDataList;
        }
    }

    public class Plot
    {

    }
}
