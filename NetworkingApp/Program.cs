using System;

namespace NetworkingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.Sockets.UdpClient udp = new System.Net.Sockets.UdpClient(15000);
            System.Net.IPEndPoint iP = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 15000);
        }
    }
}
