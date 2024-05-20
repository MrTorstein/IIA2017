using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Tools
{
    internal class SensorData
    {
        public int DataId { get; set; }
        public string? DataTimeStamp { get; set; }
        public double DataValue { get; set; }

        public List<SensorData> GetSensorData()
        {
            string connectionString = "Data Source=BEIST\\SQLEXPRESS;Initial Catalog=Datalogging and Monitoring System;Integrated Security=True; TrustServerCertificate=True";

            List<SensorData> sensorDataList = new List<SensorData>();
            SqlConnection con = new SqlConnection(connectionString);

            string selectSQL = "SELECT DatapointId, Value FROM DATAPOINT where LogId = 3";
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    SensorData sensorData = new SensorData();

                    sensorData.DataId = Convert.ToInt32(dr["DatapointId"]);
                    sensorData.DataValue = Convert.ToDouble(dr["Value"]);
                    sensorDataList.Add(sensorData);
                }
            }
            return sensorDataList;
        }
    }
}