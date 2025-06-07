namespace BlazorForum.Libraries
{
    public class LibExternal(IHttpContextAccessor HttpContextAccessor)
    {
        public string GetIP()
        {
            return HttpContextAccessor.HttpContext?.Request?.Headers["X-Forwarded-For"].ToString() ?? "Unknown IP";
        }

        public string GetUrl()
        {
            return HttpContextAccessor.HttpContext?.Request?.Path.ToString() ?? "Unknown URL";
        }

        public string GetUserAgent()
        {
            return HttpContextAccessor.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "Unknown User-Agent";
        }

        public string GetCountryCode()
        {
            return "";
        }
    }
}
