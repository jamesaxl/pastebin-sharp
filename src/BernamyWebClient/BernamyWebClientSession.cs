using System;
using System.Text.RegularExpressions;

namespace BernamyWebClient
{
    public class BernamyWebClientSession : IBernamyWebClient
    {
        private readonly System.Net.WebClient Session = new System.Net.WebClient();
        public string FpasteScsys(string content, string nick, string channel ,string summary) {
            if (String.IsNullOrEmpty(content))
                throw new System.ArgumentException("Parameter cannot be null or empty", "content");
            if (String.IsNullOrEmpty (nick))
                nick = "Anonymous";
            if (String.IsNullOrEmpty (channel))
                channel = "";
            if (String.IsNullOrEmpty(summary))
                summary = "Nothing";

            var values = new System.Collections.Specialized.NameValueCollection();
            values["paste"] = content;
            values["nick"] = nick;
            values["channel"] = channel;
            values["summary"] = summary;
            Session.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var message = Session.UploadValues("http://fpaste.scsys.co.uk/paste", "POST", values);
            var url = System.Text.Encoding.Default.GetString(message);
            var match = Regex.Match(url, @"(http://fpaste.scsys.co.uk/[0-9a-zA-Z]+)", RegexOptions.IgnoreCase);

            if (match.Success) {
                url = match.Groups [1].Value;
                return url;
            }
            return "Report the Bug to James Axl";
        }

        public string DebianPaste(string content, string nick, string language, string expiry) {
            if (String.IsNullOrEmpty(content))
                throw new System.ArgumentException("Parameter cannot be null or empty", "content");
            if (String.IsNullOrEmpty (nick))
                nick = "Anonymous";
            if (String.IsNullOrEmpty (language))
                language = "-1";
            if (String.IsNullOrEmpty(expiry))
                expiry = "3600";
            var values = new System.Collections.Specialized.NameValueCollection();
            values["code"] = content;
            values["poster"] = nick;
            values["lang"] = language;
            values["expire"] = expiry;

            Session.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var message = Session.UploadValues("http://paste.debian.net/./", "POST", values);
            var url = System.Text.Encoding.Default.GetString(message);

            var match = Regex.Match(url, @"<a href='//(paste.debian.net/plain/[0-9a-zA-Z]+)'>Show as text</a>", RegexOptions.IgnoreCase);

            if (match.Success) {
                url = match.Groups [1].Value;
                return "http://" + url;
            }
            return "Report the Bug to James Axl";
        }

        public string Fpaste(string content, string nick, string language ,string expiry) {
            if (String.IsNullOrEmpty(content))
                throw new System.ArgumentException("Parameter cannot be null or empty", "content");
            if (String.IsNullOrEmpty (nick))
                nick = "Anonymous";
            if (String.IsNullOrEmpty (language))
                language = "text";
            if (String.IsNullOrEmpty(expiry))
                expiry = "1800";
            var values = new System.Collections.Specialized.NameValueCollection();
            values["paste_data"] = content;
            values["paste_user"] = nick;
            values["paste_lang"] = language;
            values["api_submit"] = "true";
            values["mode"] = "json";
            System.Net.ServicePointManager.Expect100Continue = false;
            Session.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var message = Session.UploadValues("http://fpaste.org/", "POST", values);
            var url = System.Text.Encoding.Default.GetString(message);

            var match = Regex.Match(url, @"""id"": ""([0-9a-zA-Z]+)""",RegexOptions.IgnoreCase);

            if (match.Success) {
                url = match.Groups [1].Value;
                return "http://fpaste.org/" + url;
            }
            return "Report the Bug to James Axl";
        }
    }
}
    