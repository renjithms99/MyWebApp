using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class OpenAIChatService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "**************";

    public OpenAIChatService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> GetChatResponse(string userMessage)
    {
        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[] {
                new { role = "user", content = userMessage }
            }
        };

        var requestContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

        var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", requestContent);
        var responseContent = await response.Content.ReadAsStringAsync();

        dynamic json = JsonConvert.DeserializeObject(responseContent);
        return json.choices[0].message.content.ToString();
    }
}
