// jeff.key@sliver.com
// http://www.sliver.com

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace sliver
{
	public class AboutForm : System.Windows.Forms.Form
	{
		private Icon	_icon;
		private string	_company = "";
		private string	_companyUrl = "";
		private string	_copyright = "";
		private string	_version = "";
		private string	_title = "";
		private string	_author = "";
		private string  _disclaimer = "Use at your own risk.";
		private string	_authorUrl = "";

		#region IDEstuff

		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.LinkLabel lblCompany;
		private System.Windows.Forms.Label lblCopyright;
		private System.Windows.Forms.LinkLabel lblAuthor;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblDisclaimer;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblAuthor = new System.Windows.Forms.LinkLabel();
			this.lblCompany = new System.Windows.Forms.LinkLabel();
			this.lblVersion = new System.Windows.Forms.Label();
			this.lblCopyright = new System.Windows.Forms.Label();
			this.lblDisclaimer = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblAuthor
			// 
			this.lblAuthor.Location = new System.Drawing.Point(64, 48);
			this.lblAuthor.Name = "lblAuthor";
			this.lblAuthor.Size = new System.Drawing.Size(204, 16);
			this.lblAuthor.TabIndex = 0;
			this.lblAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAuthor_LinkClicked);
			// 
			// lblCompany
			// 
			this.lblCompany.Location = new System.Drawing.Point(64, 64);
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.Size = new System.Drawing.Size(204, 16);
			this.lblCompany.TabIndex = 1;
			this.lblCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// lblVersion
			// 
			this.lblVersion.Location = new System.Drawing.Point(64, 32);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(212, 16);
			this.lblVersion.TabIndex = 2;
			// 
			// lblCopyright
			// 
			this.lblCopyright.Location = new System.Drawing.Point(64, 80);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.Size = new System.Drawing.Size(208, 16);
			this.lblCopyright.TabIndex = 3;
			// 
			// lblDisclaimer
			// 
			this.lblDisclaimer.Location = new System.Drawing.Point(64, 96);
			this.lblDisclaimer.Name = "lblDisclaimer";
			this.lblDisclaimer.Size = new System.Drawing.Size(200, 16);
			this.lblDisclaimer.TabIndex = 3;
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdOK.Location = new System.Drawing.Point(184, 116);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 4;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(16, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(32, 32);
			this.panel1.TabIndex = 5;
			// 
			// lblTitle
			// 
			this.lblTitle.Location = new System.Drawing.Point(64, 16);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(212, 16);
			this.lblTitle.TabIndex = 2;
			// 
			// AboutForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(270, 148);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.cmdOK,
																		  this.lblCopyright,
																		  this.lblVersion,
																		  this.lblCompany,
																		  this.lblAuthor,
																		  this.lblDisclaimer,
																		  this.lblTitle});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About";
			this.ResumeLayout(false);

		}

		#endregion

		#endregion

		public AboutForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			
			_icon = this.Icon;
			
			Assembly ass = Assembly.GetEntryAssembly();
			_version = Application.ProductVersion;
			
			foreach (Attribute att in ass.GetCustomAttributes(false))
			{
				switch (att.GetType().Name)
				{
					case "AssemblyCompanyAttribute":
						_company = ((AssemblyCompanyAttribute)att).Company;
						break;
					case "AssemblyCopyrightAttribute":
						_copyright = ((AssemblyCopyrightAttribute)att).Copyright;
						break;
					case "AssemblyTitleAttribute":
						_title = ((AssemblyTitleAttribute)att).Title;
						break;
				}
			}
		}

		/// <summary>
		/// Creates instance with values that can't be extracted from the entry assembly's information.
		/// </summary>
		/// <param name="author">The author.</param>
		/// <param name="bigIcon">Icon to show on the form.</param>
		/// <param name="companyUrl">The company URL.</param>
		/// <param name="disclaimer">The dislaimer.</param>
		public AboutForm(string author, Icon bigIcon, string companyUrl, string disclaimer) : this()
		{
			_author = author;
			_icon = bigIcon;
			_companyUrl = companyUrl;
			_disclaimer = disclaimer;
		}

		/// <summary>
		/// The icon to display on the form.  Defaults to the icon of the form.
		/// </summary>
		public Icon BigIcon
		{
			get { return _icon; }
			set { _icon = value; }
		}

		/// <summary>
		/// The company URL.
		/// </summary>
		public string CompanyUrl
		{
			get { return _companyUrl; }
			set { _companyUrl = value; }
		}

		/// <summary>
		/// The company.  Defaults to the entry assembly's company.
		/// </summary>
		public string Company
		{
			get { return _company; }
			set { _company = value; }
		}

		/// <summary>
		/// The copyright.  Defaults to the entry assembly's copyright.
		/// </summary>
		public string Copyright
		{
			get { return _copyright; }
			set { _copyright = value; }
		}

		/// <summary>
		/// The version.  Defaults to the entry assembly's version.
		/// </summary>
		public string Version
		{
			get { return _version; }
			set { _version = value; }
		}

		/// <summary>
		/// The application title.  Defaults to the entry assembly's title.
		/// </summary>
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		/// <summary>
		/// The author of the application
		/// </summary>
		public string Author
		{
			get { return _author; }
			set { _author = value; }
		}

		/// <summary>
		/// The URL of the author.
		/// </summary>
		public string AuthorUrl
		{
			get { return _authorUrl; }
			set { _authorUrl = value; }
		}

		/// <summary>
		/// The disclaimer.
		/// </summary>
		public string Dislaimer
		{
			get { return _disclaimer; }
			set { _disclaimer = value; }
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		protected override void OnLoad(System.EventArgs e)
		{
			lblVersion.Text = _version;
			lblTitle.Text = _title;
			lblCompany.Text = _company;
			lblAuthor.Text = _author;
			if (_authorUrl != "")
				lblAuthor.LinkArea = new LinkArea(0, _author.Length);
			else
				lblAuthor.LinkArea = new LinkArea(0,0);

			lblCopyright.Text = _copyright;
			lblDisclaimer.Text = _disclaimer;

			if (_companyUrl == "")
				lblCompany.Links.Clear();
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			LaunchUrl(_companyUrl);
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);

			Graphics g = panel1.CreateGraphics();
			g.DrawIcon(_icon, panel1.ClientRectangle);
			g.Dispose();
		}

		private void LaunchUrl(string url)
		{
			System.Diagnostics.Process.Start(url);
		}

		private void lblAuthor_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			LaunchUrl(_authorUrl);
		}
	}
}
