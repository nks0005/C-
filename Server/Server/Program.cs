using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener Listener = null;
            NetworkStream NS = null;

            StreamReader SR = null;
            StreamWriter SW = null;
            TcpClient client = null;

            int PORT = 12345;

            Console.WriteLine("서버소켓");
            try
            {
                Listener = new TcpListener(PORT);
                Listener.Start(); // Listener 동작 시작

                while (true)
                {
                    client = Listener.AcceptTcpClient();

                    NS = client.GetStream(); // 소켓에서 메시지를 가져오는 스트림
                    SR = new StreamReader(NS, Encoding.UTF8); // Recv Message
                    SW = new StreamWriter(NS, Encoding.UTF8); // Send Messgae

                    string RecvMessage = string.Empty;

                    while (client.Connected == true) // 클라이언트 메시지 받기
                    {
                        RecvMessage = SR.ReadLine();

                        SW.WriteLine("Server : {0} [{1}]", RecvMessage, DateTime.Now); // 메시지 보내기
                        SW.Flush();
                        Console.WriteLine("Log: {0} [{1}]", RecvMessage, DateTime.Now);
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                SW.Close();
                SR.Close();
                client.Close();
                NS.Close();
            }
        }
    }
}