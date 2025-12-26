using System.Globalization;
using System.Text.RegularExpressions;
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

            titleLink = Regex.Replace(titleLink, @"[^0-9a-zA-Z ]+", "");
            titleLink = Regex.Replace(titleLink, "/-+/", " ");
            titleLink = Regex.Replace(titleLink, "\\s+", "-");
            titleLink = Regex.Replace(titleLink, "/-+/", "-");

            return titleLink;
        }

        public static string NumOfCommentsTextDesktop(int numOfComments)
        {
            return numOfComments == 0 ? " " : $"({numOfComments})";
        }

        public static string NumOfCommentsTextMobile(int numOfComments)
        {
            string commentsWord = numOfComments == 1 ? "comment" : "comments";
            return numOfComments == 0 ? " " : $" | {numOfComments} {commentsWord}";
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

        public static string EmoticonLink(char reaction)
        {
            string emoticonName = "NotFound";
            if (reaction == 'L') emoticonName = "Like";
            if (reaction == 'H') emoticonName = "Heart";
            if (reaction == 'F') emoticonName = "Funny";            
            if (reaction == 'W') emoticonName = "Wonder";
            if (reaction == 'S') emoticonName = "Sad";
            if (reaction == 'A') emoticonName = "Angry";
            return $"/Images/Emoticons/{emoticonName}.svg";
        }

        public static string DateFormat(DateTime time)
        {
            return time.ToString("d MMM yyy", CultureInfo.CreateSpecificCulture("en-US"));
        }

        public static string DateTimeFormat(DateTime time)
        {
            return time.ToString("d MMM yyy HH:mm", CultureInfo.CreateSpecificCulture("en-US"));
        }

        public static string Views(int views)
        {
            return views.ToString("##,#") + " " + (views == 1 ? "view" : "views");
        }

        public static string Initials(string name)
        {
            if (name == null || name == string.Empty)
                return "NN";

            string[] parts = name.Replace("'", "").Trim().Split(' ', '.', ',', '-', ':', ';', '/', '&');

            foreach (string part in parts)
            {
                if (part.Length == 0)
                {
                    parts = parts.Where(p => p != part).ToArray();
                }
            }

            if (parts.Length == 0)
                return "NN";

            if (parts.Length == 1 && parts[0].Length != 0)
                return parts[0][..1].ToUpper();

            if (parts.Length > 1 && parts[0].Length != 0 && parts[1].Length != 0)
                return parts[0][..1].ToUpper() + parts[1][..1].ToUpper();

            return "NN";
        }

        public static int ColorIndexFromIp (string ip)
        {
            string[] digits = ip.Split(".");
            int sum = 0;
            foreach (string digit in digits)
            {
                if (int.TryParse(digit, out int number))
                {
                    sum += number;
                }
            }
            return sum % 20;
        }

        public static string CommentTextTrim(string commentText)
        {
            string result = commentText.Trim();

            char[] nn = { '\n', '\n' };
            result = result.Trim(nn);

            char[] rn = { '\r', '\n' };
            result = result.Trim(rn);

            return result;
        }

        public static string CommentTextDecode(string commentText)
        {
            // HTML Decode
            string result = HtmlDecode(commentText);

            char[] nn = { '\n', '\n' };
            result = result.Trim(nn);

            char[] rn = { '\r', '\n' };
            result = result.Trim(rn);

            // Line breaks
            result = result.Replace("\n", "<br />\n");
            result = result.Replace("\r\n", "<br />\r\n");
            result = result.Replace("\n\n", "\r\n<br />\r\n<br />\r\n");

            // Insert hyperlinks
            result = Regex.Replace(result, "((https?://)?www\\.[^\\s]+)", "<a href=\"$1\">$1</a>");

            return result;
        }
    }
}
