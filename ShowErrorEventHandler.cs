// brian.takita@runbox.com
namespace sliver.AccessQueryAnalyzer {
	using System;

	public delegate void ShowErrorEventHandler (object sender, ShowErrorEventArgs e);
	/// <summary>
	/// Summary description for ShowErrorEventArgs.
	/// </summary>
	public class ShowErrorEventArgs : EventArgs {
		public ShowErrorEventArgs(string message) {
			this.Message_ = message;
		}

		public ShowErrorEventArgs(Exception ex) {
			this.Exception_ = ex;
		}

		#region public Exception Exception {get;}
		private Exception Exception_;

		/// <summary>
		/// Get 
		/// </summary>
		public Exception Exception {
			get {
				return Exception_;
			}
		}
		#endregion

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
