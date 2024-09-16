using NP_03._TCP_Task_Manager;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Channels;

var ip = IPAddress.Loopback;
var port = 27001;
var client = new TcpClient();
client.Connect(ip, port);

var steram = client.GetStream();
var br = new BinaryReader(steram);
var bw = new BinaryWriter(steram);
Command command = null;
string responce = null;
string str = null;

while (true)
{
    Console.WriteLine("Write any command or HELP");
    str = Console.ReadLine()!.ToUpper();

    if (str == "HELP")
    {
        Console.WriteLine();
        Console.WriteLine("Command list: ");
        Console.WriteLine(Command.processList);
        Console.WriteLine($"{Command.run} <process_name>");
        Console.WriteLine($"{Command.kill} <process_name>");
        Console.WriteLine($"HELP");
        Console.ReadLine();
        Console.Clear();
    }
    var input = str.Split(' ');
    switch (input[0])
    {
        case Command.processList:
            command = new Command { Text = input[0] };
            bw.Write(JsonSerializer.Serialize(command));
            responce = br.ReadString();
            var processList = JsonSerializer.Deserialize<string[]>(responce);
            foreach(var proc in processList)
            {
                Console.WriteLine($"            {proc}");
            }
            break;
        case Command.run:
            break;
        case Command.kill:
            break;
        default:
            break;
    }
}
