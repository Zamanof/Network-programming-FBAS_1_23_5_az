using System.Net.Sockets;
using System.Net;
using System.Text;

var listener = new UdpClient(27001);
listener.EnableBroadcast = true;

var endPoint = new IPEndPoint(IPAddress.Any, 0);

while (true)
{
    var reciveBuffer = listener.Receive(ref endPoint);
    Console.WriteLine(Encoding.Default.GetString(reciveBuffer));
    Thread.Sleep(100);
    Console.Clear();
}

