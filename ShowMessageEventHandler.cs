// brian.takita@runbox.com
namespace sliver.AccessQueryAnalyzer {
	using System;

	public delegate void ShowMessageEventHandler (object sender, ShowMessageEventArgs e);
	/// <summary>
	/// Summary description for ShowMessageEventHandler.
	/// </summary>
	public class ShowMessageEventArgs : EventArgs {
		public ShowMessageEventArgs(string message) {
			this.Message_ = message;
		}
		
		#region public string Message {get;}
		private string Message_;

		/// <summary>
		/// Get 
		/// </summary>
		public string Message {
			get {
				return Message_;
			}
		}
		#endregion
	}
}
