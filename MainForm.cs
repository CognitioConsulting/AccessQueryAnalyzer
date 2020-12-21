// brian.takita@runbox.com
namespace sliver.AccessQueryAnalyzer {
	using System;
	using System.Drawing;
	using System.Collections;
	using System.ComponentModel;
	using System.Windows.Forms;

	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form {
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private Hashtable ThreadedQueriesHashTable_;
        private System.Windows.Forms.MenuItem menuItem5;
        private IContainer components;

		public MainForm() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.ThreadedQueriesHashTable_ = new Hashtable();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem5});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3});
            this.menuItem1.Text = "&File";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.menuItem3.Text = "&New";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4});
            this.menuItem2.Text = "&Query";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.menuItem4.Text = "&Execute";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "&About";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(684, 273);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Access Query Analyzer";
            this.ResumeLayout(false);

		}
		#endregion

		#region public event EventHandler Execute
		private event EventHandler Execute_;
		public event EventHandler Execute {
			add {
				Execute_+=value;
			}
			remove {
				Execute_-=value;
			}
		}
		
		protected virtual void OnExecute (EventArgs e) {
			if (this.Execute_ != null) {
				this.Execute_ (this, e);
			}
		}
		#endregion

		#region public string QueryText {get;}
		/// <summary>
		/// Get 
		/// </summary>
		public string QueryText {
			get {
				return ((QueryForm) this.ActiveMdiChild).QueryText;
			}
		}
		#endregion

		#region public string FileName {get;}
		/// <summary>
		/// Get 
		/// </summary>
		public string FileName {
			get {
				return ((QueryForm) this.ActiveMdiChild).FileName;
			}
		}
		#endregion

		public void ShowMessage (string s) {
			MessageBox.Show (s, "Access Query Analyzer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public void ShowError (Exception ex) {
			string e = "There was an error while executing the query:\n\n" + ex.ToString ();

			if (ex.InnerException != null)
				e += "\n\nInner Exception:\n" + ex.InnerException.Message;

			this.ShowError (e);
		}

		public void ShowError (string error) {
			MessageBox.Show(error, "Access Query Analyzer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private EventArgs AssignExecuteThread () {
			EventArgs args = new EventArgs();
			this.ThreadedQueriesHashTable_ [args] = this.ActiveMdiChild;
			return args;
		}

		private void menuItem3_Click(object sender, System.EventArgs e) {
			QueryForm form = new QueryForm();
			form.MdiParent = this;
			form.WindowState = FormWindowState.Maximized;
			form.Execute+=new EventHandler(QueryForm_Execute);
			form.Closing+=new CancelEventHandler(QueryForm_Closing);
			form.Show ();
		}

		private void menuItem4_Click(object sender, System.EventArgs e) {
			if (this.ActiveMdiChild != null) {
				this.OnExecute (this.AssignExecuteThread ());
			}
		}

		private void QueryForm_Execute(object sender, EventArgs e) {
			this.OnExecute (this.AssignExecuteThread ());
		}

		private void QueryForm_Closing(object sender, CancelEventArgs e) {
			QueryForm form = (QueryForm) sender;
			form.Execute-=new EventHandler(QueryForm_Execute);
			form.Closing-=new CancelEventHandler(QueryForm_Closing);
		}

		private void menuItem5_Click(object sender, System.EventArgs e) {
			AboutForm form = new AboutForm ();
			form.ShowDialog ();
		}
	}
}
