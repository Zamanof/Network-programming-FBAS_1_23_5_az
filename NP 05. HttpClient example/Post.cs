using System.Text.Json.Serialization;

namespace NP_05._HttpClient_example;

internal class Post
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Header { get; set; }
    [JsonPropertyName("body")]
    public string Body { get; set; }

    public override string ToString()
    {
        return $"{UserId}: {Header}";
    }
}
