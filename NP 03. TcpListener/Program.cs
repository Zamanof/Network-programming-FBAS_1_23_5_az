﻿using System.Net;
using System.Net.Sockets;

//var listener = new TcpListener(IPAddress.Loopback, 27001);
var listener = new TcpListener(IPAddress.Parse("10.2.14.1"), 27001);
listener.Start(5);

while (true)
{
    var client = listener.AcceptTcpClient();
    var stream = client.GetStream();
    var bw = new BinaryWriter(stream);
    var br = new BinaryReader(stream);
    while (true)
    {
        var data = br.ReadString();
        Console.WriteLine(data);
        bw.Write("VV");
    }

}