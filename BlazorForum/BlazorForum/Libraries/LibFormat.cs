using System.Web;

namespace BlazorForum.Libraries
{
    public class LibFormat
    {
        public static string HtmlDecode(string text)
        {
            return HttpUtility.HtmlDecode(text);
        }

        public static string TitleLink(string title)
        {
            string titleLink = title.ToLower().Trim();

            titleLink = System.Text.RegularExpressions.Regex.Replace(titleLink, @"[^0-9a-zA-Z ]+", "");
            titleLink = System.Text.RegularExpressions.Regex.Replace(titleLink, "/-+/", " ");
            titleLink = System.Text.RegularExpressions.Regex.Replace(titleLink, "\\s+", "-");
            titleLink = System.Text.RegularExpressions.Regex.Replace(titleLink, "/-+/", "-");

            return titleLink;
        }

        public static string NumberOfCommentsText(int numOfComments)
        {
            return numOfComments == 0 ? " " : $"({numOfComments})";
        }

        public static string NumberOfCommentsLink(int numOfComments)
        {
            return numOfComments == 0 ? " " : $"/{numOfComments}";
        }

        public static string HiddenText(bool hidden)
        {
            return hidden ? $"(hidden) " : " ";
        }

        public static bool FlagExists(string userCountryCode)
        {
            return File.Exists("wwwroot" + FlagLink(userCountryCode));
        }

        public static string FlagLink(string userCountryCode)
        {
            return $"/Images/Flags/{userCountryCode}.png";
        }

        public static string DateTimeFormat(DateTime time)
        {
            return time.ToString("dd MMM yyy HH:mm");
        }
    }
}
