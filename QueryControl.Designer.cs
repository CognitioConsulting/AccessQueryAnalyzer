namespace sliver.AccessQueryAnalyzer
{
	using System;
	using System.ComponentModel;
	using System.Windows.Forms;

	partial class QueryControl
	{
		private System.Windows.Forms.TextBox txtQuery;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TextBox txtFilename;
		private System.Windows.Forms.Button cmdSelectFile;
		private System.Windows.Forms.Button cmdExecute;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dg;
		private System.Windows.Forms.StatusBar sb;
		private System.Windows.Forms.ProgressBar progressBar1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtQuery = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dg = new System.Windows.Forms.DataGridView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.txtFilename = new System.Windows.Forms.TextBox();
			this.cmdSelectFile = new System.Windows.Forms.Button();
			this.cmdExecute = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.sb = new System.Windows.Forms.StatusBar();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
			this.SuspendLayout();
			// 
			// txtQuery
			// 
			this.txtQuery.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtQuery.Location = new System.Drawing.Point(0, 0);
			this.txtQuery.Multiline = true;
			this.txtQuery.Name = "txtQuery";
			this.txtQuery.Size = new System.Drawing.Size(620, 104);
			this.txtQuery.TabIndex = 0;
			this.txtQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuery_KeyDown);
			this.txtQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuery_KeyPress);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.dg);
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.txtQuery);
			this.panel1.Location = new System.Drawing.Point(8, 37);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(620, 357);
			this.panel1.TabIndex = 2;
			// 
			// dg
			// 
			this.dg.AllowUserToAddRows = false;
			this.dg.AllowUserToDeleteRows = false;
			this.dg.ColumnHeadersHeight = 29;
			this.dg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dg.Location = new System.Drawing.Point(0, 110);
			this.dg.Name = "dg";
			this.dg.ReadOnly = true;
			this.dg.RowHeadersWidth = 51;
			this.dg.Size = new System.Drawing.Size(620, 247);
			this.dg.TabIndex = 2;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 104);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(620, 6);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// txtFilename
			// 
			this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFilename.Location = new System.Drawing.Point(68, 7);
			this.txtFilename.Name = "txtFilename";
			this.txtFilename.Size = new System.Drawing.Size(452, 24);
			this.txtFilename.TabIndex = 3;
			// 
			// cmdSelectFile
			// 
			this.cmdSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdSelectFile.Location = new System.Drawing.Point(520, 7);
			this.cmdSelectFile.Name = "cmdSelectFile";
			this.cmdSelectFile.Size = new System.Drawing.Size(24, 22);
			this.cmdSelectFile.TabIndex = 4;
			this.cmdSelectFile.Text = "...";
			this.cmdSelectFile.Click += new System.EventHandler(this.cmdSelectFile_Click);
			// 
			// cmdExecute
			// 
			this.cmdExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdExecute.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdExecute.Location = new System.Drawing.Point(552, 7);
			this.cmdExecute.Name = "cmdExecute";
			this.cmdExecute.Size = new System.Drawing.Size(75, 22);
			this.cmdExecute.TabIndex = 5;
			this.cmdExecute.Text = "Execute";
			this.cmdExecute.Click += new System.EventHandler(this.cmdExecute_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 15);
			this.label1.TabIndex = 6;
			this.label1.Text = "Database";
			// 
			// sb
			// 
			this.sb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sb.Dock = System.Windows.Forms.DockStyle.None;
			this.sb.Location = new System.Drawing.Point(8, 398);
			this.sb.Name = "sb";
			this.sb.Size = new System.Drawing.Size(516, 15);
			this.sb.TabIndex = 7;
			this.sb.Text = "Ready";
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(528, 401);
			this.progressBar1.Maximum = 30;
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(100, 12);
			this.progressBar1.TabIndex = 8;
			// 
			// QueryControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.sb);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmdExecute);
			this.Controls.Add(this.cmdSelectFile);
			this.Controls.Add(this.txtFilename);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.progressBar1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "QueryControl";
			this.Size = new System.Drawing.Size(636, 418);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
