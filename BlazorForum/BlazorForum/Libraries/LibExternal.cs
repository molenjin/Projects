using BlazorForum.Data;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Text.Json;

namespace BlazorForum.Libraries
{
    public class LibExternal(IHttpContextAccessor HttpContextAccessor)
    {
        public async Task<IpInfo> GetIpInfoAsync()
        {
            string ip = HttpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "0.0.0.0";
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://ipinfo.io/{ip}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var ipInfo = JsonSerializer.Deserialize<IpInfo>(responseBody) ?? new IpInfo();
            ipInfo.UserAgent = HttpContextAccessor.HttpContext?.Request?.Headers.UserAgent.ToString() ?? "Unknown User-Agent";
            return ipInfo;
        }

        public async Task SendExceptionEmailAsync(string methodName, Exception ex)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync("accn-australia.com", 8080, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("admin@accn-australia.com", "aWedft67$j");

                    // Create the email message
                    var message = new MimeKit.MimeMessage();
                    message.From.Add(new MimeKit.MailboxAddress("accn-australia admin", "admin@accn-australia.com"));
                    message.To.Add(new MimeKit.MailboxAddress("admin", "molenjin@gmail.com"));
                    message.Subject = $"Exception in {methodName}";
                    message.Body = new MimeKit.TextPart("plain")
                    {
                        Text = $"An exception occurred in {methodName}:\n\n{ex}"
                    };

                    await client.SendAsync(message);
                }
                finally
                {
                    // Disconnect from the server
                    await client.DisconnectAsync(true);
                }
            }
        }
    }
}
