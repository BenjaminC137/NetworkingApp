using System;
using System.Net.Sockets;
using System.Text;

namespace NetworkingApp
{
    class Program
    {
        private static System.Net.HttpListener http = new System.Net.HttpListener();
        private static void Listen()
        {

            http.BeginGetContext((iar) =>
            {
                System.Net.HttpListenerContext context = http.EndGetContext(iar);
                string name = "World";
                if (context.Request.QueryString.AllKeys.Contains("name"))
                {
                    name = context.Request.QueryString["name"];
                }
                System.IO.Stream stream = context.Response.OutputStream;
                byte[] encodedMessage = System.Text.Encoding.ASCII.GetBytes("Hello " + name);
                stream.Write(encodedMessage, 0, encodedMessage.Length);
                Console.WriteLine("Request from " + name);
                context.Response.Close();
                Listen();
            }, new object());
        }
        static void Main(string[] args)
        {
            http.Prefixes.Add("http://*:80/");
            http.Start();
            Listen();
            string typedMessage;
            do
            {
                typedMessage = Console.ReadLine();

            } while (typedMessage != "EXIT");
            http.Stop();
        }
    }
}