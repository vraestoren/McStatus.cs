using System.Net.Http;
using System.Net.Http.Headers;

namespace MinecraftStatusApi
{
    public class McStatusApi
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://api.mcstatus.io/v2";
        
        public McStatusApi()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetJavaServerStatus(string address)
        {
            var response = await httpClient.GetAsync($"{apiUrl}/status/java/{address}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetBedrockServerStatus(string address)
        {
            var response = await httpClient.GetAsync($"{apiUrl}/status/bedrock/{address}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
