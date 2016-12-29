//Don't forget this:
using System.Net.NetworkInformation;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ViewTcpIp
{
    class Program
    {
        public static void ShowActiveTcpConnections()
        {
            StreamWriter file = new StreamWriter("a.txt");

            Console.WriteLine("자신의 컴퓨터에 TCP/IP 통신하는 소켓들의 리스트를 작성중입니다. ( 파일명 : a.txt, b.txt )");
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation c in connections)
            {
                string test = c.RemoteEndPoint.ToString();
                int test_bool = test.IndexOf("[::1]");
                if (test_bool != -1)
                    continue;
                file.WriteLine(c.RemoteEndPoint);
            }
            file.Close();
            Check_Reiteration();
            
        }

        public static void PingTest()
        {
            Ping pingSender = new Ping();

            StreamReader file = new StreamReader("b.txt");
            while (!file.EndOfStream)
            {
                string[] remote = file.ReadLine().Split(':');
                string IP = remote[0];
                string PORT = remote[1];

                PingReply reply = pingSender.Send(IP);
                Console.WriteLine("IP : {0}, Status : {1}", IP, reply.Status);
                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("{0} Ping교신 성공.", IP);
                    Pasing(IP);
                }
                else
                {
                    Console.WriteLine("{0} Ping교신 실패.", IP);
                    Pasing(IP);
                }
                Console.WriteLine("-------------------------------------");
            }
            file.Close();
        }

        public static void Pasing(string Target)
        {
            string TargetHttp = "http://" + Target + ".ipaddress.com/";
            WebRequest request = WebRequest.Create(TargetHttp);
            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());

            // 주소에 있는 텍스트 모두를 긁어 저장
            string firstStr = stream.ReadToEnd();

            string Organization = firstStr;
            Console.WriteLine("알아보고자 하는 IP : {0}", Target);
            int index1 = Organization.IndexOf("Organization:") + "Organization:".Length + 9;
            int index2 = Organization.IndexOf("ISP/Hosting:") - 19;
            Organization = Organization.Substring(index1, index2 - index1);
            Console.WriteLine("Organization : {0}", Organization);

            string ISP_Hosting = firstStr;
            index1 = firstStr.IndexOf("ISP/Hosting:") + "ISP/Hosting:".Length + 9;
            index2 = firstStr.IndexOf("Updated") - 19;
            ISP_Hosting = firstStr.Substring(index1, index2 - index1);
            Console.WriteLine("ISP_Hosting : {0}", ISP_Hosting);
        }   

        public static void Check_Reiteration()
        {
            StreamReader sr = new StreamReader("a.txt");
            StreamWriter sw = new StreamWriter("b.txt");
          
            string result = sr.ReadToEnd();

            string[] finds = result.Split('\n');
            for(int i=0; i<finds.Length;i++)
            {
                finds[i] = finds[i].Replace('\r', ' ');
            }
            bool Check = false;
            int k = 1;

            foreach (string find in finds)
            {
                if (find == "")
                    break;
                for (int i = k; i<finds[i].Length; i++)
                {
                    if(find == finds[i])
                    {
                        Check = true;
                        break;
                    }
                }
                if(Check == false)
                {
                    sw.WriteLine(find);
                }
                Check = false;
                k++;
            }

            sr.Close();
            sw.Close();
        }
        
        static void Main(string[] args)
        {
            ShowActiveTcpConnections();
            PingTest();

            Console.WriteLine("\n끝입니다. 종료하시려면 아무키나 입력해주세요.");
            Console.Read();
        }
    }
}