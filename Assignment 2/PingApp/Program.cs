///////////////////////////////////////////////////////////////////////
///
/// PingAppConsile: application testing the ping() connection to a node
///
/// Based on code form Microsoft MSDN about the ping() command
///
/// Version: 1.0: 8-JAN-17: NOS
///
///////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.VisualBasic;
//
namespace PingAppConsole
{
    class Program
    {
        /// <summary>
        /// ///////////////////////////////////////////////////////////
        static void Main(string[] args)
        /// Purpose: the main function in the application handling the
        /// ping()communication
        /// Version: 1.0: 8-JAN-17: NOS
        /// </summary>
        {
            string host, data;
            byte[] buffer;
            int timeout;
            Ping pingSender = new();
            PingOptions options = new()
            {
                // Use the default Ttl value which is 128,
                // but change the fragmentation behavior.
                DontFragment = true
            };

            // Create a buffer of 32 bytes of data to be transmitted.
            data = "CanIWatchPoirot?";
            buffer = Encoding.ASCII.GetBytes(data);
            timeout = 120;
            // Name or address of node to access
            host = "tv.nrk.no";
            PingReply reply = pingSender.Send(host, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine(" Ping communication status for {0}:", host);
                Console.WriteLine(" ----------------------------------------");
                Console.WriteLine(" Address: {0}", reply.Address.ToString());
                Console.WriteLine(" RoundTrip time (mSec): {0}",
                reply.RoundtripTime);
                Console.WriteLine(" Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine(" Dont fragment: {0}",
                reply.Options.DontFragment);
                Console.WriteLine(" Buffer size: {0}", reply.Buffer.Length);
                Console.WriteLine(" ----------------------------------------");
            }
            else
            {
                Console.WriteLine(" Error connecting to network address/name {0}", host);
            }

            PingSegment("192.168.0.");

            Console.WriteLine(" Press CR or Enter to Quit the application");
            Console.ReadLine();
        }

        // Description: Function used to ping all nodes in a network segment
        // Author: Torstein Solheim Olberg
        // Date: 04/02-2024
        public static void PingSegment(string network_prefix)
        {
            Ping pingSender = new();
            PingOptions options = new() {DontFragment = true};
            string data = "message";

            for (int i = 0; i < 255; i++)

            {
                string host = network_prefix + i.ToString();
                PingReply reply = pingSender.Send(host, 120, Encoding.ASCII.GetBytes(data), options);
                Console.WriteLine("Pinged " + host + ": Status = " + reply.Status);

            }
        }
    }
}