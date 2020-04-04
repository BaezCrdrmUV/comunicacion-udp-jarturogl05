using System;
using System.Net.Sockets;

namespace cliente
{
    public class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient();
            udpClient.Connect("192.168.1.76", 8080);

            bool serverStatus = true;

            while (serverStatus)
            {

                Console.WriteLine("Escribe un mensaje");
                string msg = Console.ReadLine();

                if (msg == "bye")
                {
                    Console.WriteLine("adios");
                    serverStatus = false;
                }
                else
                {
                    Byte[] senddata = System.Text.Encoding.UTF8.GetBytes(msg);
                    udpClient.Send(senddata, senddata.Length);
                }

            }

            udpClient.Close();
        }
    }
}
