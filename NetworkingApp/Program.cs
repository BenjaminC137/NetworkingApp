using System;
using System.Net.Sockets;
using System.Text;

namespace NetworkingApp
{
    class Program
    {
        private static System.Net.Sockets.UdpClient udp = new System.Net.Sockets.UdpClient(15000);
        private static System.Net.IPEndPoint ip = new System.Net.IPEndPoint(System.Net.IPAddress.Broadcast, 15000);

        private static void Listen()
        {
            udp.BeginReceive((iar) =>
            {
                byte[] bytes = udp.EndReceive(iar, ref ip);
                string message = System.Text.Encoding.ASCII.GetString(bytes);
                Console.WriteLine(message);
                Listen();
            }, new object());
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string yourName = Console.ReadLine();
            string typedMessage = "";

            Listen();
            do
            {
                typedMessage = Console.ReadLine();
                byte[] encodedMessage = System.Text.Encoding.ASCII.GetBytes(yourName + ": " + typedMessage);
                string ipAddress = "192.168.1.40";
                var recipient = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(ipAddress), 15000);
                udp.Send(encodedMessage, encodedMessage.Length, recipient);
            }
                while (typedMessage != "exit");

        }
    }
}