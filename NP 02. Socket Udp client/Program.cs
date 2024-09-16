using System.Net;
using System.Net.Sockets;
using System.Text;

var client= new Socket(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp);

var connectEp = new IPEndPoint(IPAddress.Loopback, 27001);

var message = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent eget felis sed dolor sodales rhoncus. Etiam fermentum, ante vitae condimentum aliquet, nunc nisi molestie elit, vel vehicula mauris urna sed est. Sed at faucibus diam. Suspendisse nec justo erat. Donec ut metus sollicitudin, viverra lacus ac, aliquet diam. Donec nec aliquam massa. Aliquam vel ex a ipsum fermentum eleifend ac eu mauris. Aliquam maximus enim lacus, ac semper arcu blandit non. Curabitur sodales, lorem et convallis elementum, felis tortor tempor arcu, a placerat est enim ullamcorper justo. Praesent non eros vel justo rhoncus hendrerit. Aenean interdum ligula quis diam convallis, et ornare ex aliquet.
Nulla eu erat hendrerit, pharetra nisl ut, pharetra quam. Proin venenatis felis vel luctus rhoncus. In feugiat maximus massa vel efficitur. Nunc nec metus ac ante fringilla maximus nec at orci. Duis consequat congue diam, in aliquet lectus molestie id. Aliquam aliquet, ipsum in mollis feugiat, orci diam accumsan neque, nec pellentesque urna ipsum at metus. Praesent volutpat luctus accumsan. Ut id pharetra est. Quisque quis augue ac nunc varius porta vel porttitor augue. Phasellus ut urna cursus nulla porttitor placerat. Curabitur ut risus sagittis, pretium mauris quis, facilisis neque. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nam malesuada vitae lacus in vestibulum.
Duis imperdiet diam mauris, eget blandit sapien consequat porttitor. Maecenas vestibulum turpis in congue eleifend. Pellentesque est erat, malesuada et suscipit ac, dapibus eget massa. Vestibulum sed pharetra lectus, non venenatis augue. Phasellus vitae urna eu risus imperdiet fringilla eu et lacus. Praesent ultrices tincidunt facilisis. Etiam volutpat bibendum leo vitae iaculis. Morbi eu tristique turpis, nec porttitor sem. Aliquam a odio dolor.
Sed luctus ullamcorper mi blandit vulputate. Nulla pellentesque vitae velit non ornare. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce nec auctor risus. Nullam vulputate hendrerit malesuada. Donec consequat neque eu augue dapibus porttitor. Sed vel lobortis elit, vitae tempor risus. Fusce sed erat sem. Maecenas posuere augue sed ante scelerisque auctor.
Nam sit amet dolor sapien. Nam varius molestie facilisis. Nulla velit velit, pharetra non eleifend et, feugiat sit amet risus. Quisque cursus mi mi, vel congue libero scelerisque ac. Integer at venenatis ante, quis lacinia sapien. Mauris dapibus finibus dolor. Ut sed magna enim. Proin convallis ut nunc eget sodales. Duis laoreet est a quam pretium consequat. Proin a luctus ipsum.";

int count = 0;
while (true)
{
    var bytes = Encoding.Default.GetBytes(message[count++ % message.Length].ToString());
    Thread.Sleep(100);
    client.SendTo(bytes, connectEp);
}