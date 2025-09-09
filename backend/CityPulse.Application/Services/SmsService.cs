/* using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CityPulse.Application.Services;

public class SmsService
{
    private const string apiKey = "5107b9ecca8902b39c9328ea81cb5b84b9cc4e38RkK0996elVVkK9uQrV8Nrp377";

    public async Task SendSmsAsync(string phoneNumber, string message)
    {
        using var client = new HttpClient();

        var requestData = new
        {
            phone = phoneNumber,
            message = message,
            key = apiKey
        };
        
        var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync("https://textbelt.com/text", content);
        var responseString = await response.Content.ReadAsStringAsync();
        
        dynamic result = JsonConvert.DeserializeObject(responseString);

        
        
        
    }
}
*/