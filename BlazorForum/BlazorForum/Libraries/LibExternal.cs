using BlazorForum.Data;
using System.Net;
using System.Net.Mail;
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
            // 1. SMTP Settings (Plesk)
            string smtpHost = "accn-australia.com"; // Usually mail.domain.com
            int smtpPort = 465; // Use 587 for TLS or 465 for SSL
            string smtpUsername = "admin@accn-australia.com"; // Your full Plesk email address
            string smtpPassword = "aWedft67$j"; // Password for this mailbox

            // 2. Email Address Details
            MailAddress fromAddress = new MailAddress(smtpUsername, "Sender Display Name");
            MailAddress toAddress = new MailAddress("molenjin@gmail.com");

            // 3. Create the Message
            using (MailMessage message = new MailMessage(fromAddress, toAddress))
            {
                message.Subject = "Test Email from C#";
                message.Body = "This is a test email sent from a C# application via Plesk SMTP.";
                message.IsBodyHtml = false;

                // 4. Configure SMTP Client
                using (SmtpClient smtp = new SmtpClient(smtpHost, smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtp.EnableSsl = true; // Required for modern email security
                    smtp.UseDefaultCredentials = false;

                    try
                    {
                        smtp.Send(message);
                        Console.WriteLine("Email sent successfully!");
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine("Error: " + ex2.Message);
                    }
                }
            }

            //using (var client = new SmtpClient())
            //{
            //    try
            //    {
            //        await client.ConnectAsync("accn-australia.com", 8080, SecureSocketOptions.StartTls);
            //        await client.AuthenticateAsync("admin@accn-australia.com", "aWedft67$j");

            //        // Create the email message
            //        var message = new MimeKit.MimeMessage();
            //        message.From.Add(new MimeKit.MailboxAddress("accn-australia admin", "admin@accn-australia.com"));
            //        message.To.Add(new MimeKit.MailboxAddress("admin", "molenjin@gmail.com"));
            //        message.Subject = $"Exception in {methodName}";
            //        message.Body = new MimeKit.TextPart("plain")
            //        {
            //            Text = $"An exception occurred in {methodName}:\n\n{ex}"
            //        };

            //        await client.SendAsync(message);
            //    }
            //    finally
            //    {
            //        // Disconnect from the server
            //        await client.DisconnectAsync(true);
            //    }
            //}
        }
    }
}
