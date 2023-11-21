using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerCore
{
    class Program
    {
        static void OnAcceptHandler(Socket clientSocket)
        {
            try
            {
				Session session = new Session();
				session.init(clientSocket);

                // 보낸다.
                byte[] sendBuffer = Encoding.UTF8.GetBytes("Welcome to MMO Server");
                clientSocket.Send(sendBuffer);

                // 쫒아낸다.

                Thread.Sleep(1000);
                session.Disconnect();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void Main(string[] args)
        {
            // DNS
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

            Listener lintener = new Listener();
            // 문지기

            lintener.init(endPoint, OnAcceptHandler); // 앤드포인트와 소켓이 준비가 되면 이 함수를 실행시켜주라는 의미
            Console.WriteLine("Listening...");

            while (true)
            {
                ;  
            }
        }
    }
}