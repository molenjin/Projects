using BlazorForum.Data;
using BlazorForum.Database;
using System.Text.Json;
using System.Xml.Linq;

namespace BlazorForum.Libraries
{
    public class LibExternal(IHttpContextAccessor HttpContextAccessor)
    {
        public async Task<IpInfo> GetIpInfoAsync()
        {
            string ip = "101.189.80.166"; //HttpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "0.0.0.0";
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://ipinfo.io/{ip}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var ipInfo = JsonSerializer.Deserialize<IpInfo>(responseBody) ?? new IpInfo();
            ipInfo.UserAgent = HttpContextAccessor.HttpContext?.Request?.Headers.UserAgent.ToString() ?? "Unknown User-Agent";
            return ipInfo;
        }

        public async Task SendEmailAsync(string methodName, Exception ex)
        {
        }
    }
}
