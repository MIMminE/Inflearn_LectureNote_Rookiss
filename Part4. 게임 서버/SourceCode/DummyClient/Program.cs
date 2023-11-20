using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DummyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

            // 휴대폰 설정
            Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // 입장 문의
            socket.Connect(endPoint);
            Console.WriteLine($"Connected to {socket.RemoteEndPoint.ToString()}");

            // 보낸다.
            Byte[] sendBuff = Encoding.UTF8.GetBytes("Hello Server~");
            socket.Send(sendBuff);

            // 받는다. 
            Byte[] recvBuff = new Byte[1024];
            int recvByte = socket.Receive(recvBuff);
            string recvString = Encoding.UTF8.GetString(recvBuff, 0, recvByte);
            Console.WriteLine(recvString);

            socket.Close();
        } 
    }
}