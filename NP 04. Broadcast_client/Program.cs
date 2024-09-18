using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();
var ip = IPAddress.Parse("10.2.14.255");
var endPoint = new IPEndPoint(ip, 27001);

List<string> messages = [
    @"/\_______",
    @"_/\______",
    @"__/\_____",
    @"___/\____",
    @"____/\___",
    @"_____/\__",
    @"______/\_",
    @"_______/\",
    @"________/",
    @"_________",
    @"\________"
];
var i = 0;
var length = messages.Count;
while (true)
{
    var data = Encoding.Default.GetBytes(messages[i++ % length]);
    client.Send(data, endPoint);
    Thread.Sleep(100);
}
