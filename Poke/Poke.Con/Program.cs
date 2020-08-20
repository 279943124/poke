using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Poke.Con
{
    class Program
    {
        private static Socket serverSocket;
        static void Main(string[] args)
        {
            // 新建服务端的socket
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 10056);
            serverSocket.Bind(endPoint);
            serverSocket.Listen(10);
            //TaskFactory taskFactory = new TaskFactory();
            //// 开启一个线程接受客户端连接
            //taskFactory.StartNew(ListenClientConnect);
            Thread thread = new Thread(ListenClientConnect);
            thread.IsBackground = false;
            thread.Start();
        }
        private static void ListenClientConnect()
        {
            Socket clientSocket = serverSocket.Accept();
            clientSocket.Send(System.Text.Encoding.Default.GetBytes("Hello World"));
            Thread thread = new Thread(ReceiveClientMessage);
            thread.Start(clientSocket);
        }
        private static void ReceiveClientMessage(object clientSocket)
        {
            Socket client = (Socket)clientSocket;
            byte[] buffer = new byte[1024];
            int len = client.Receive(buffer);
            Console.WriteLine(System.Text.Encoding.Default.GetString(buffer,0,len));
        }
    }
}
