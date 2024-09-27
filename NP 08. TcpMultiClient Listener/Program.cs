using System.Net;
using System.Net.Sockets;

TcpListener listener = null;
BinaryReader br = null;
BinaryWriter bw = null;
List<TcpClient> clients = [];

var ip = IPAddress.Parse("10.2.11.1");
var port = 27001;
var endPoint = new IPEndPoint(ip, port);
listener = new TcpListener(endPoint);
listener.Start(10);
Console.WriteLine($"Listening on {listener.LocalEndpoint}");

while (true)
{
    var client = listener.AcceptTcpClient();
    clients.Add(client);
    Console.WriteLine($"{client.Client.RemoteEndPoint} connected...");

    var reader = Task.Run(() =>
    {
        foreach (var client in clients)
        {
            Task.Run(() => 
            {
                while (true)
                {
                    var stream = client.GetStream();
                    br = new BinaryReader(stream);
                    try
                    {
                        var msg = br.ReadString();
                        Console.WriteLine($"Client {client.Client.RemoteEndPoint}: {msg}");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"{client.Client.RemoteEndPoint} removed");
                        clients.Remove(client);
                    }
                }
            }).Wait(50);
        }
    });

    var writer = Task.Run(() =>
    {
        while (true)
        {
            var msg = Console.ReadLine();
            foreach (var client in clients)
            {
                var stream = client.GetStream();
                bw = new BinaryWriter(stream);
                bw.Write(msg);
            }
        }
    });
}
