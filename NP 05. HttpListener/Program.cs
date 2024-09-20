using System.Net;

var listener = new HttpListener();

listener.Prefixes.Add(@"http://localhost:27001/");

listener.Start();

while (true)
{
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;
    //Console.WriteLine(request.RawUrl);
    //foreach(string key in request.QueryString.Keys)
    //{
    //    Console.WriteLine($"{key} - {request.QueryString[key]}");
    //}
    response.AddHeader("Content-Type", "text/html");

    StreamWriter writer = new StreamWriter(response.OutputStream);
    //writer.WriteLine($"Welcome {request.QueryString["name"]}");
    writer.WriteLine(@$"<h1 style='color:red;'> Salam {request.QueryString["name"]}</h1>");
    writer.WriteLine(@$"<a href='https://google.com'> Google</a>");
    writer.WriteLine(@$"<img src='https://images.squarespace-cdn.com/content/v1/5369465be4b0507a1fd05af0/1528837069483-LD1R6EJDDHBY8LBPVHIU/randall-ruiz-272502.jpg'/>");
    writer.Close();

}