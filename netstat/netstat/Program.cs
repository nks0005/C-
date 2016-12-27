using System;
using System.Net;
using System.Net.NetworkInformation;

namespace netstat
{
    class Program
    {
        static void Main(string[] args)
        {
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();

            IPEndPoint[] endPoints = ipProperties.GetActiveTcpListeners();
            TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation info in tcpConnections)
            {
                Console.WriteLine("Local : " + info.LocalEndPoint.Address.ToString() + ":" + info.LocalEndPoint.Port.ToString()
                    + "\nRemote : " + info.RemoteEndPoint.Address.ToString()
                    + ":" + info.RemoteEndPoint.Port.ToString()
                    + "\nState : " + info.State.ToString() + "\n\n");
            }
        }
    }
}