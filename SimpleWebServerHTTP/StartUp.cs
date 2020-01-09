
namespace httpServer
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var tcpListener = new TcpListener(
                IPAddress.Loopback, 12345);

            const string newLine = "\r\n";

            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();

                using (var stream = client.GetStream())
                {
                    var requestBytes = new byte[100000];
                    int readBytes = stream.Read(requestBytes, 0, requestBytes.Length);
                    var stringRequest = Encoding.UTF8.GetString(requestBytes, 0, readBytes);
                    Console.WriteLine(new string('=', 70));
                    Console.WriteLine(stringRequest);

                    var responseBody = //@"<form method='post'><input type='text' name='tweet' placeholder='tweet here'\><input type='submit'\>";
                        stringRequest;

                    string response = "HTTP/1.0 200 OK" + newLine
                        + "Server: MyCustomServer/1.0" + newLine
                        + "Content-Type: text/plain" + newLine
                        + "Set-Cookie: cookie1=test1; Expires=" +
                        DateTime.UtcNow.AddSeconds(30).ToString("R") + newLine
                        + "Set-Cookie: cookie2=test2; Max-Age=30" + newLine
                        + "Set-Cookie: cookie3=test3;Expires=" +
                        DateTime.UtcNow.AddSeconds(-1).ToString("R") + newLine //Deletes Cookie
                        + "Set-Cookie: cookie4=test4; Max-Age=30; Security; HttpOnly;" + newLine //Sends only trough secure connections, and prevents the cookie beign accessed trough scripts
                        + "Content-Lenght: 11" + newLine + newLine
                        + responseBody;
                    var responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, responseBytes.Length);
                }
            }
        }
    }
}
