using System;
using System.Net.Sockets;

namespace Poke.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            // 新建服务端的socket
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
        }
    }
}
