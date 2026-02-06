// brian.takita@runbox.com
using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace sliver.AccessQueryAnalyzer
{
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private Hashtable ThreadedQueriesHashTable_;
		private System.Windows.Forms.MenuItem menuItem5;
		private IContainer components;

		// New: tab control to host QueryControl instances
		private System.Windows.Forms.TabControl tabControl;

		// Context menu for tabs (close command)
		private ContextMenuStrip tabContextMenu;
		private ToolStripMenuItem closeTabMenuItem;
		private ToolStripMenuItem closeOtherTabsMenuItem;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.ThreadedQueriesHashTable_ = new Hashtable();
		}

		protected override void OnLoad(EventArgs e)
		{
			CreateNewTab();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.closeTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeOtherTabsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabContextMenu.SuspendLayout();
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
			// tabControl
			// 
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(1006, 647);
			this.tabControl.TabIndex = 0;
			this.tabControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseUp);
			// 
			// tabContextMenu
			// 
			this.tabContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.tabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeTabMenuItem,
            this.closeOtherTabsMenuItem});
			this.tabContextMenu.Name = "tabContextMenu";
			this.tabContextMenu.Size = new System.Drawing.Size(189, 52);
			// 
			// closeTabMenuItem
			// 
			this.closeTabMenuItem.Name = "closeTabMenuItem";
			this.closeTabMenuItem.Size = new System.Drawing.Size(188, 24);
			this.closeTabMenuItem.Text = "Close Tab";
			this.closeTabMenuItem.Click += new System.EventHandler(this.closeTabMenuItem_Click);
			// 
			// closeOtherTabsMenuItem
			// 
			this.closeOtherTabsMenuItem.Name = "closeOtherTabsMenuItem";
			this.closeOtherTabsMenuItem.Size = new System.Drawing.Size(188, 24);
			this.closeOtherTabsMenuItem.Text = "Close Other Tabs";
			this.closeOtherTabsMenuItem.Click += new System.EventHandler(this.closeOtherTabsMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
			this.ClientSize = new System.Drawing.Size(1006, 647);
			this.Controls.Add(this.tabControl);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Menu = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "Access Query Analyzer";
			this.tabContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#region public event EventHandler Execute
		private event EventHandler Execute_;
		public event EventHandler Execute
		{
			add
			{
				Execute_ += value;
			}
			remove
			{
				Execute_ -= value;
			}
		}

		protected virtual void OnExecute(EventArgs e)
		{
			if (this.Execute_ != null)
			{
				this.Execute_(this, e);
			}
		}
		#endregion

		#region public string QueryText {get;}
		public string QueryText
		{
			get
			{
				var active = this.ActiveQueryView;
				return active != null ? active.QueryText : string.Empty;
			}
		}
		#endregion

		#region public string FileName {get;}
		public string FileName
		{
			get
			{
				var active = this.ActiveQueryView;
				return active != null ? active.FileName : string.Empty;
			}
		}
		#endregion

		public IQueryView ActiveQueryView
		{
			get
			{
				if (this.tabControl == null || this.tabControl.SelectedTab == null || this.tabControl.SelectedTab.Controls.Count == 0)
				{
					return null;
				}

				return this.tabControl.SelectedTab.Controls[0] as IQueryView;
			}
		}

		public void ShowMessage(string s)
		{
			MessageBox.Show(s, "Access Query Analyzer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public void ShowError(Exception ex)
		{
			string e = "There was an error while executing the query:\n\n" + ex.ToString();

			if (ex.InnerException != null)
				e += "\n\nInner Exception:\n" + ex.InnerException.Message;

			this.ShowError(e);
		}

		public void ShowError(string error)
		{
			MessageBox.Show(error, "Access Query Analyzer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private EventArgs AssignExecuteThread()
		{
			EventArgs args = new EventArgs();
			// store the active query view (QueryControl) instead of MDI child
			this.ThreadedQueriesHashTable_[args] = this.ActiveQueryView;
			return args;
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			// Create a new tab with a QueryControl inside
			this.CreateNewTab();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			if (this.tabControl.SelectedTab != null)
			{
				// update tab title to show filename if available before executing
				this.UpdateTabTitleFromView(this.ActiveQueryView, this.tabControl.SelectedTab);
				this.OnExecute(this.AssignExecuteThread());
			}
		}

		private void QueryControl_Execute(object sender, EventArgs e)
		{
			Control ctl = sender as Control;
			if (ctl != null)
			{
				TabPage page = GetTabPageForControl(ctl);
				if (page != null)
				{
					UpdateTabTitleFromView(ctl as IQueryView, page);
				}
			}

			this.OnExecute(this.AssignExecuteThread());
		}

		private void CreateNewTab()
		{
			var newTabIndex = GetNextTabIndex();
			QueryControl qc = new QueryControl(newTabIndex);
			qc.Dock = DockStyle.Fill;
			qc.Execute += new EventHandler(this.QueryControl_Execute);

			string title = qc.TabTitle;
			TabPage page = new TabPage(title);
			page.Controls.Add(qc);

			// When the control is disposed remove event handlers
			qc.Disposed += (s, e) =>
			{
				try
				{
					qc.Execute -= new EventHandler(this.QueryControl_Execute);
				}
				catch
				{
					// ignore
				}
			};

			this.tabControl.TabPages.Add(page);
			this.tabControl.SelectedTab = page;
		}

		private int GetNextTabIndex()
		{
			var maxIndex = 0;

			foreach (TabPage page in this.tabControl.TabPages)
			{
				if (page.Controls[0] is QueryControl qc)
				{
					if (qc.Id > maxIndex)
						maxIndex = qc.Id;
				}
			}

			return maxIndex+1;
		}

		private string GetDefaultTabTitle(int index)
		{
			string t = string.Format("Query {0}", index);
			return t;
		}

		private TabPage GetTabPageForControl(Control ctl)
		{
			if (ctl == null || this.tabControl == null)
				return null;

			foreach (TabPage p in this.tabControl.TabPages)
			{
				if (p.Controls.Count > 0 && object.ReferenceEquals(p.Controls[0], ctl))
					return p;
			}

			return null;
		}

		private void UpdateTabTitleFromView(IQueryView view, TabPage page)
		{
			if (view == null || page == null)
				return;

			try
			{
				page.Text = view.TabTitle;
			}
			catch
			{
				// ignore any path issues and leave existing title
			}
		}

		private void QueryForm_Closing(object sender, CancelEventArgs e)
		{
			// Not used with tabbed UI. Keep for compatibility if any code calls it.
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			AboutForm form = new AboutForm();
			form.ShowDialog();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if ((keyData & Keys.Control) == Keys.Control && (keyData & Keys.KeyCode) == Keys.T)
			{
				this.CreateNewTab();
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		#region Tab context menu and close helpers

		private void tabControl_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				for (int i = 0; i < this.tabControl.TabCount; i++)
				{
					var rect = this.tabControl.GetTabRect(i);
					if (rect.Contains(e.Location))
					{
						// store index on Tag so handlers know which tab to act on
						this.tabContextMenu.Tag = i;
						this.tabContextMenu.Show(this.tabControl, e.Location);
						break;
					}
				}
			}
		}

		private void closeTabMenuItem_Click(object sender, EventArgs e)
		{
			if (this.tabContextMenu.Tag is int idx)
			{
				CloseTab(idx);
			}
		}

		private void closeOtherTabsMenuItem_Click(object sender, EventArgs e)
		{
			if (this.tabContextMenu.Tag is int idx)
			{
				CloseOtherTabs(idx);
			}
		}

		private void CloseTab(int index)
		{
			if (index < 0 || index >= this.tabControl.TabCount)
				return;

			TabPage page = this.tabControl.TabPages[index];
			if (page.Controls.Count > 0)
			{
				try
				{
					if (page.Controls[0] is QueryControl queryControl)
						queryControl.SaveSettings();

					page.Controls[0].Dispose();
				}
				catch
				{
					// ignore
				}
			}

			this.tabControl.TabPages.RemoveAt(index);

			// adjust selection if needed
			if (this.tabControl.TabCount > 0)
			{
				this.tabControl.SelectedIndex = Math.Max(0, index - 1);
			}
		}

		private void CloseOtherTabs(int keepIndex)
		{
			if (keepIndex < 0 || keepIndex >= this.tabControl.TabCount)
				return;

			for (int i = this.tabControl.TabCount - 1; i >= 0; i--)
			{
				if (i == keepIndex)
					continue;

				CloseTab(i);
			}
		}

		#endregion
	}
}
