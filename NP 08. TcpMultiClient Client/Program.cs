using System.Net;
using System.Net.Sockets;

var client = new TcpClient();

var ip = IPAddress.Parse("127.0.0.1");
var port = 27001;
var endPoint = new IPEndPoint(ip, port);
try
{
    client.Connect(endPoint);
    if (client.Connected)
    {
        var writer = Task.Run(() =>
        {
            while (true)
            {
                var text = Console.ReadLine();
                var stream = client.GetStream();
                var bw = new BinaryWriter(stream);
                bw.Write(text);
            }
        });
        var reader = Task.Run(() =>
        {
            while (true)
            {
                var stream = client.GetStream();
                var br = new BinaryReader(stream);
                Console.WriteLine($"From server: {br.ReadString()}");
            }

        });
        Task.WaitAll(writer, reader);
    }
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}
