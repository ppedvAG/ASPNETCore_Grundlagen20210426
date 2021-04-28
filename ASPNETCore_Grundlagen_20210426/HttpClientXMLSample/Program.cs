using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpClientXMLSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://localhost:44360/WeatherForecast";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);

            string xml = await responseMessage.Content.ReadAsStringAsync();


            Console.WriteLine("Hello World!");
        }
    }
}
