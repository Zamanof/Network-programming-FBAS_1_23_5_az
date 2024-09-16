using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();
var connectEp = new IPEndPoint(IPAddress.Loopback, 27001);
client.Connect(connectEp);
List<string> messages = [
    @"/\________",
    @"_/\_______",
    @"__/\______",
    @"___/\_____",
    @"____/\____",
    @"_____/\___",
    @"______/\__",
    @"_______/\_",
    @"________/\",
    @"_________/",
    @"\_________",
    ];

var i = 0;
byte[] bytes = null;
while (true)
{
    bytes = Encoding.Default.GetBytes(messages[i++%messages.Count]);
    client.Send(bytes);
    Thread.Sleep(100);
}
