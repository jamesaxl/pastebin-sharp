using System;
using System.Text.RegularExpressions;

namespace BernamySoup
{
    public class BernamySoupSession : IBernamySoup
    {
        private readonly Soup.Session Session = new Soup.Session();
        public string FpasteScsys(string content, string nick, string channel ,string summary) {
            if (String.IsNullOrEmpty(content))
                throw new System.ArgumentException("Parameter cannot be null or empty", "content");
            if (String.IsNullOrEmpty (nick))
                nick = "Anonymous";
            if (String.IsNullOrEmpty (channel))
                channel = "";
            if (String.IsNullOrEmpty(summary))
                summary = "Nothing";
            var message = new Soup.Message ("POST", "http://fpaste.scsys.co.uk/paste");
            message.SetRequest("application/x-www-form-urlencoded", Soup.MemoryUse.Copy, "paste=" + content + "&channel=#" + channel + "&nick=" + nick +" &summary=" + summary);
            Session.SendMessage (message);
            var url = message.ResponseBodyField.Data;
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

            var message = new Soup.Message ("POST", "http://paste.debian.net/./");
            message.SetRequest("application/x-www-form-urlencoded", Soup.MemoryUse.Copy, "code=" + content +  "&poster=" + nick +"&expire=" + expiry + "&lang=" + language);
            Session.SendMessage (message);
            var url = message.ResponseBodyField.Data;
            var match = Regex.Match(url, @"<a href='//(paste.debian.net/plain/[0-9a-zA-Z]+)'>Show as text</a>", RegexOptions.IgnoreCase);

            if (match.Success) {
                url = match.Groups [1].Value;
                return url;
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
            var message = new Soup.Message ("POST", "http://fpaste.org");
            message.SetRequest("application/x-www-form-urlencoded", Soup.MemoryUse.Copy, "paste_data=" + content + "&paste_user=" + nick +"&paste_expire=" + expiry + "&paste_lang=" + language + "&api_submit=true&mode=json");
            Session.SendMessage (message);
            var url = message.ResponseBodyField.Data;
            var match = Regex.Match(url, @"""id"": ""([0-9a-zA-Z]+)""",RegexOptions.IgnoreCase);

            if (match.Success) {
                url = match.Groups [1].Value;
                return url;
            }
            return "Report the Bug to James Axl";
        }
    }
}

