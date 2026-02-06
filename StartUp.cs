// jeff.key@sliver.com
// http://www.sliver.com
// brian.takita@runbox.com

using System;
using System.Threading;
using System.Windows.Forms;

namespace sliver.AccessQueryAnalyzer
{
	public class StartUp
	{
		#region Static
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			StartUp start = new StartUp();
			start.MainForm = new MainForm();
			// start.MainForm.WindowState = FormWindowState.Maximized;
			Application.Run(start.MainForm);
		}
		#endregion

		public StartUp()
		{
			this.MainFormChanged += new EventHandler(StartUp_MainFormChanged);
			this.MainFormChanging += new EventHandler(StartUp_MainFormChanging);
		}

		#region public MainForm MainForm {get;set;}
		private MainForm MainForm_;

		/// <summary>
		/// Get/Set 
		/// </summary>
		public MainForm MainForm
		{
			get
			{
				return MainForm_;
			}
			set
			{
				if (MainForm_ != value)
				{
					OnMainFormChanging(EventArgs.Empty);
					MainForm_ = value;
					OnMainFormChanged(EventArgs.Empty);
				}
			}
		}

		private event EventHandler MainFormChanging_;
		public event EventHandler MainFormChanging
		{
			add
			{
				MainFormChanging_ += value;
			}
			remove
			{
				MainFormChanging_ -= value;
			}
		}

		protected virtual void OnMainFormChanging(EventArgs e)
		{
			if (this.MainFormChanging_ != null)
			{
				this.MainFormChanging_(this, e);
			}
		}

		private event EventHandler MainFormChanged_;
		public event EventHandler MainFormChanged
		{
			add
			{
				MainFormChanged_ += value;
			}
			remove
			{
				MainFormChanged_ -= value;
			}
		}

		protected virtual void OnMainFormChanged(EventArgs e)
		{
			if (this.MainFormChanged_ != null)
			{
				this.MainFormChanged_(this, e);
			}
		}
		#endregion

		private void StartUp_MainFormChanged(object sender, EventArgs e)
		{
			this.MainForm.Execute += new EventHandler(MainForm_Execute);
		}

		private void StartUp_MainFormChanging(object sender, EventArgs e)
		{
			if (this.MainForm_ != null)
			{
				this.MainForm_.Execute -= new EventHandler(MainForm_Execute);
			}
		}

		private void MainForm_Execute(object sender, EventArgs e)
		{
			// Use the MainForm.ActiveQueryView (tabbed UI) as the IQueryView source
			IQueryView activeView = this.MainForm_.ActiveQueryView;
			if (activeView == null)
			{
				this.MainForm_.ShowError("No active query tab.");
				return;
			}

			QueryRunner runner = new QueryRunner(activeView);
			runner.ShowError += new ShowErrorEventHandler(QueryRunner_ShowError);
			runner.ShowMessage += new ShowMessageEventHandler(QueryRunner_ShowMessage);
			Thread t = new Thread(new ThreadStart(runner.Execute));
			t.Start();
		}

		private void QueryRunner_ShowError(object sender, ShowErrorEventArgs e)
		{
			if (e.Exception != null)
			{
				this.MainForm_.ShowError(e.Exception);
			}
			else if (e.Message != null)
			{
				this.MainForm_.ShowError(e.Message);
			}
			else
			{
				this.MainForm_.ShowError("An Error has occurred.");
			}
		}

		private void QueryRunner_ShowMessage(object sender, ShowMessageEventArgs e)
		{
			this.MainForm_.ShowMessage(e.Message);
		}
	}
}
