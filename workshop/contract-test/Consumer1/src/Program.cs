// See https://aka.ms/new-console-template for more information
using src;

string baseUrl = "https://localhost:7072";

var gateway = new ServiceAGateway(baseUrl);

try
{

    var result = await gateway.CallApi(1);
    var resultContentText = result.Content!.ReadAsStringAsync().GetAwaiter().GetResult();
    Console.WriteLine(resultContentText);
}catch(Exception e)
{
    Console.WriteLine("Error, cannot call api with " + e.Message);
}
