// PASTESHARE - API for sharing your code
//
// Copyright (c) 2014 jamesaxl axlrose112@gmail.com
//
// Full GPL License: <http://www.gnu.org/licenses/gpl.txt>
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307 USA

using System;
using System.Net.Security;

namespace PasteSharp
{
	public interface IBernami
	{
		string Bpase(string content, string language, string expiry);
		string FpasteScsys(string content, string nick, string channel ,string summary);
		string DebianPaste(string content, string nick, string language, string expiry);
		string Fpaste(string content, string nick, string language ,string expiry);
	}

	public class SoupSession : IBernami
	{
		private readonly Soup.Session Session = new Soup.Session();
		public string FpasteScsys(string content, string nick, string channel ,string summary) {
			var message = new Soup.Message ("POST", "http://fpaste.scsys.co.uk/paste");
			message.SetRequest("application/x-www-form-urlencoded", Soup.MemoryUse.Copy, "paste=" + content + "&channel=#" + channel + "&nick=" + nick +" &summary=" + summary);
			Session.SendMessage (message);
			var url = message.ResponseBody.Data;
			return url;
		}

		// Bpaste can be used only with soup-sharp.
		public string Bpase(string content, string language, string expiry) {
			var message = new Soup.Message ("POST", "https://bpaste.net/");
			message.SetRequest("application/x-www-form-urlencoded", Soup.MemoryUse.Copy, "code=" + content + "&lexer=" + language + "&expiry=" + expiry);
			Session.SendMessage (message);
			var url = message.ResponseBody.Data;
			return url;
		}

		public string DebianPaste(string content, string nick, string language, string expiry) {
			var message = new Soup.Message ("POST", "http://paste.debian.net/./");
			message.SetRequest("application/x-www-form-urlencoded", Soup.MemoryUse.Copy, "code=" + content +  "&poster=" + nick +"&expire=" + expiry + "&lang=" + language);
			Session.SendMessage (message);
			var url = message.ResponseBody.Data;
			return url;
		}

		public string Fpaste(string content, string nick, string language ,string expiry) {
			var message = new Soup.Message ("POST", "http://fpaste.org");
			message.SetRequest("application/x-www-form-urlencoded", Soup.MemoryUse.Copy, "paste_data=" + content + "&paste_user=" + nick +"&paste_expire=" + expiry + "&paste_lang=" + language + "&api_submit=true&mode=json");
			Session.SendMessage (message);
			var url = message.ResponseBody.Data;
			return url;
		}
	}

	public class WebClientSession : IBernami {
		private readonly System.Net.WebClient Session = new System.Net.WebClient();
		public string FpasteScsys(string content, string nick, string channel ,string summary) {
			var values = new System.Collections.Specialized.NameValueCollection();
			values["paste"] = content;
			values["nick"] = nick;
			values["channel"] = channel;
			values["summary"] = summary;
			Session.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
			var message = Session.UploadValues("http://fpaste.scsys.co.uk/paste", "POST", values);
			var url = System.Text.Encoding.Default.GetString(message);
			return url;
		}

		public string Bpase(string content, string language, string expiry) {
			var values = new System.Collections.Specialized.NameValueCollection();
			values["code"] = content;
			values["lexer"] = language;
			values["expiry"] = expiry;

			System.Net.ServicePointManager.ServerCertificateValidationCallback = (p1, p2, p3, p4) => true;
			Session.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
			var message = Session.UploadValues("https://bpaste.net/", "POST", values);
			var url = System.Text.Encoding.Default.GetString(message);
			return url;
		}

		public string DebianPaste(string content, string nick, string language, string expiry) {
			var values = new System.Collections.Specialized.NameValueCollection();
			values["code"] = content;
			values["poster"] = nick;
			values["lang"] = language;
			values["expire"] = expiry;

			System.Net.ServicePointManager.ServerCertificateValidationCallback = (p1, p2, p3, p4) => true;
			Session.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
			var message = Session.UploadValues("http://paste.debian.net/./", "POST", values);
			var url = System.Text.Encoding.Default.GetString(message);
			return url;
		}

		public string Fpaste(string content, string nick, string language ,string expiry) {

			var values = new System.Collections.Specialized.NameValueCollection();
			values["paste_data"] = content;
			values["paste_user"] = nick;
			values["paste_lang"] = language;
			values["api_submit"] = "true";
			values["mode"] = "json";

			Session.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
			var message = Session.UploadValues("http://fpaste.org", "POST", values);
			var url = System.Text.Encoding.Default.GetString(message);
			return url;
		}
	}
}