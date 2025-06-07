using System.Text.Json.Serialization;

namespace BlazorForum.Data
{
    public class IpInfo
    {
        [JsonPropertyName("ip")]
        public string Ip { get; set; } = string.Empty;
        [JsonPropertyName("postal")]
        public string Postal { get; set; } = string.Empty;
        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;
        [JsonPropertyName("region")]
        public string Region { get; set; } = string.Empty;
        [JsonPropertyName("country")]
        public string CountryCode { get; set; } = string.Empty;
        [JsonPropertyName("hostname")]
        public string HostName { get; set; } = string.Empty;
        [JsonPropertyName("useragent")]
        public string UserAgent { get; set; } = string.Empty;
    }
}
