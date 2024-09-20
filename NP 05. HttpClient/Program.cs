using System.Net;
using System.Net.Http.Json;

#region WebClient
// HTTP + FTP
var webClient = new WebClient();
//Console.WriteLine(webClient.DownloadString(@"https://google.az"));
#endregion

var client = new HttpClient();

var message = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri(@"https://google.az"),

};

message.Headers.Add("Accept", "text/html");

var response = await client.SendAsync(message);
Console.WriteLine(response);
Console.WriteLine(response.Headers);
Console.WriteLine(response.StatusCode);
Console.WriteLine(response.Content);
Console.WriteLine(response.RequestMessage);