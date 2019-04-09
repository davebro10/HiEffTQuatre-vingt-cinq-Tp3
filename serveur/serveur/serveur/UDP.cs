using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace serveur
{
    class UDP
    {

        private UdpClient udpClient = new UdpClient();
        private const int UDP_PORT = 10282;

        public UDP()
        {
            udpClient = new UdpClient(UDP_PORT);
            //udpClient.Connect("localhost", UDP_PORT_SEND);
        }

        private enum UDP_RESPONSE {
            MEMBRE
        }
    

        public void Start()
        {
            Thread thdUDPServer = new Thread(new ThreadStart(Listen));
            thdUDPServer.Start();
        }

        public void Listen()
        {
            while (true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                string[] response = returnData.Split(';');
                
                if(response[0] == "MEMBRE")
                {
                    DateTime dateTime = Convert.ToDateTime(response[1]);
                    Send(udpClient, RemoteIpEndPoint, dateTime, Models.API.LAST_TIME_SYNC_CLIENTS);
                }
                else if(response[0] == "UPLOAD")
                {
                    DateTime dateTime = Convert.ToDateTime(response[1]);
                    Console.WriteLine("First : " + dateTime + " " + "SECOND: " + Models.API.LAST_TIME_SYNC_FILES + "\n");
                    Send(udpClient, RemoteIpEndPoint, Models.API.LAST_TIME_SYNC_FILES, dateTime);
                }
                else if (response[0] == "DOWNLOAD")
                {
                    DateTime dateTime = Convert.ToDateTime(response[1]);
                    Send(udpClient, RemoteIpEndPoint, dateTime, Models.API.LAST_TIME_SYNC_FILES);
                }
            }
        }

        void Send(UdpClient client, IPEndPoint remoteIpEndPoint, DateTime date1, DateTime date2)
        {
            if (date1.AddSeconds(1) < date2)
            {
                Byte[] senddata = Encoding.ASCII.GetBytes("YES");
                client.Send(senddata, senddata.Length, remoteIpEndPoint);
            }
            else
            {
                Byte[] senddata = Encoding.ASCII.GetBytes("NO");
                client.Send(senddata, senddata.Length, remoteIpEndPoint);
            }
        }

    }
}
