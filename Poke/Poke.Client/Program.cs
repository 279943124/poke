using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Poke.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10056));
            socket.Send(System.Text.Encoding.Default.GetBytes("大肥猪"));
            byte[] buffer = new byte[1024];
            int len = socket.Receive(buffer);
            Console.WriteLine(System.Text.Encoding.Default.GetString(buffer,0,len));
            Console.ReadLine();
        }
    }
}
