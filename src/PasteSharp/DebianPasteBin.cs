using System;
using System.Text.RegularExpressions;

namespace PasteSharp
{
	public class DebianPasteBin : Bridge
	{
		public DebianPasteBin () : base()
		{
		}

		public void SendContentRequest(string content, string nick, string language, string expiry) {

			 var match = Regex.Match(Session.DebianPaste(content, nick, language, expiry), 
				@"<a href='//(paste.debian.net/plain/[0-9a-zA-Z]+)'>Show as text</a>",RegexOptions.IgnoreCase);

			if (match.Success) {
				GetUrlRequest = "http://" + match.Groups [1].Value;
			}
		}
	}
}

