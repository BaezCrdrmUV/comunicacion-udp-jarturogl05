using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server
{
    public class UdpServer
    {
        public static void Main()
        {
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 8080);
            UdpClient newsock = new UdpClient(ipep);

            Console.WriteLine("esperando cliente...");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            bool serverStatus = true;

            while (serverStatus)
            {
                data = newsock.Receive(ref sender);
                Console.WriteLine("Mensaje recibido de {0}:", sender.ToString());
                string msj = Encoding.UTF8.GetString(data, 0, data.Length);
                if (msj == "bye")
                {
                    newsock.Close();

                }
                else
                {

                    Console.WriteLine(msj);
                }

            }

        }
    }
}
