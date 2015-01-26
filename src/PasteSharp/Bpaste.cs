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
using System.Text.RegularExpressions;

namespace PasteSharp
{
	public class Bpaste : Bridge
	{
		public Bpaste () : base()
		{
		}

		public void SendContentRequest(string content, string language, string expiry) {
			var match = Regex.Match(Session.Bpase (content, language, expiry), @"/raw/([0-9a-zA-Z]+)",RegexOptions.IgnoreCase);

			if (match.Success) {
			    GetUrlRequest = "https://bpaste.net/show/" + match.Groups [1].Value;
			}
		}
	}
}

