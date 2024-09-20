using NP_05._HttpClient_example;
using System.Text.Json;

var client = new HttpClient();

var message = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri(@"https://jsonplaceholder.typicode.com/posts")
};
// .GetAsync() , PostAsync(), .DeleteAsync()

var response = await client.SendAsync(message);
var json = await response.Content.ReadAsStringAsync();
//Console.WriteLine(json);
var posts = JsonSerializer.Deserialize<List<Post>>(json);

foreach (var item in posts)
{
    Console.WriteLine(item);
}