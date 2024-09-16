using System.Net;
using System.Net.Sockets;
using System.Text;
// Socket : IP Address, Port


// 127.0.0.1 - Loopback, self addres
var ipAddress = IPAddress.Parse("10.2.14.1");
var port = 27001;

Socket listener = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Stream,
    ProtocolType.Tcp);

var endPoint = new IPEndPoint(ipAddress, port);
listener.Bind(endPoint);
var backlog = 10; // Gelen ders sorushacam

listener.Listen(backlog);

Console.WriteLine("Listener listen...");

var length = 0;

var bytes = new byte[1024];
var message = string.Empty;

Socket client = null;

while (true)
{
    Console.WriteLine($"Listener listening on {listener.LocalEndPoint}");
    client = listener.Accept();
    await Task.Run(() =>
    {
        do
        {
            length = client.Receive(bytes);
            message = Encoding.Default.GetString(bytes, 0, length);
            Console.WriteLine($"{client.RemoteEndPoint}: {message}");
            if (message.ToLower() == "exit")
            {
                client.Shutdown(SocketShutdown.Both);
                client.Dispose();
                break;
            }

        } while (true);
    });
}


