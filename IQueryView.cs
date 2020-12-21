// brian.takita@runbox.com
namespace sliver.AccessQueryAnalyzer {
	using System;
	/// <summary>
	/// Summary description for IQueryView.
	/// </summary>
	public interface IQueryView {
		object DataSource {get;set;}
		string StatusText {get;set;}
		string QueryText {get;}
		// TODO: FileName needs to go away to make this application more modular. Assign connection strings somewhere else.
		string FileName {get;}
		void NotifyQueryStart ();
		void ProgressStep ();
		void Invoke (System.Delegate method);
		void Invoke (System.Delegate method, System.Object[] arguments);
	}
}
