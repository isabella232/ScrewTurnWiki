//
//  Authors:
//    Marek Habersack <grendel@twistedcode.net>
//
//  (C) 2011 Marek Habersack
//
//  Redistribution and use in source and binary forms, with or without modification, are permitted
//  provided that the following conditions are met:
//
//     * Redistributions of source code must retain the above copyright notice, this list of
//       conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice, this list of
//       conditions and the following disclaimer in the documentation and/or other materials
//       provided with the distribution.
//     * Neither the name of Marek Habersack nor the names of its contributors may be used to
//       endorse or promote products derived from this software without specific prior written
//       permission.
//
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
//  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
//  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
//  A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
//  CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
//  EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
//  PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
//  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
//  LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
//  NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//  SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//

using System;

using ScrewTurn.Wiki.PluginFramework;

namespace MediaWikiCompat
{
	public class MediaWikiCompatPlugin : IFormatterProviderV30
	{
		public bool PerformPhase1 {
			get { return true; }
		}

		public bool PerformPhase2 {
			get { return false; }
		}

		public bool PerformPhase3 {
			get { return false; }
		}

		public int ExecutionPriority {
			get { return 100; }
		}

		public ComponentInformation Information {
			get {
				return new ComponentInformation (
					"DekiWiki syntax compatibility",
					"Marek Habersack",
					"0.1.0",
					"http://twistedcode.net/blog",
					"http://twistedcode.net/no-updates-for-this-plugin"
				);
			}
		}

		public string ConfigHelpHtml {
			get {
				return "<div>No configuration required for this plugin</div>";
			}
		}
		
		public string Format (string raw, ContextInformation context, FormattingPhase phase)
		{
			if (phase != FormattingPhase.Phase1)
				return raw;
			
			return Table.Parse (raw);
		}

		public string PrepareTitle (string title, ContextInformation context)
		{
			return title;
		}

		public void Init (IHostV30 host, string config)
		{
			// no-op
		}

		public void Shutdown ()
		{
			// no-op
		}
	}
}