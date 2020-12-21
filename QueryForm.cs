// jeff.key@sliver.com 
// http://www.sliver.com
// brian.takita@runbox.com

using System;
using System.ComponentModel;
using System.Windows.Forms;
using sliver.AccessQueryAnalyzer.Properties;

namespace sliver.AccessQueryAnalyzer
{
    public partial class QueryForm : Form, IQueryView
    {
        private bool _handled = false;
        private delegate void GetQueryStringDelegate(out string queryString);

        #region public event EventHandler Execute

        private event EventHandler Execute_;

        public event EventHandler Execute
        {
            add { Execute_ += value; }
            remove { Execute_ -= value; }
        }

        protected virtual void OnExecute(EventArgs e)
        {
            if (Execute_ != null)
            {
                Execute_(this, e);
            }
        }

        #endregion

        #region public string QueryText {get;}

        /// <summary>
        /// Get 
        /// </summary>
        public string QueryText
        {
            get
            {
                string queryText;
                GetQueryText(out queryText);

                return queryText;
            }
        }

        private void GetQueryText(out string queryText)
        {
            if (InvokeRequired)
            {
                object[] values = new object[1];
                Invoke(new GetQueryStringDelegate(GetQueryText), values);
                queryText = Convert.ToString(values[0]);
            }
            else
            {
                queryText = txtQuery.SelectionLength == 0 ? txtQuery.Text : txtQuery.SelectedText;
            }
        }

        #endregion

        #region public string FileName {get;}

        /// <summary>
        /// Get 
        /// </summary>
        public string FileName
        {
            get { return txtFilename.Text; }
        }

        #endregion

        #region public string StatusText {get;set;}

        /// <summary>
        /// Get/Set 
        /// </summary>
        public string StatusText
        {
            get { return sb.Text; }
            set
            {
                if (sb.Text != value)
                {
                    sb.Text = value;
                    OnStatusBarTextChanged(EventArgs.Empty);
                }
            }
        }

        private event EventHandler StatusBarTextChanged_;

        public event EventHandler StatusBarTextChanged
        {
            add { StatusBarTextChanged_ += value; }
            remove { StatusBarTextChanged_ -= value; }
        }

        protected virtual void OnStatusBarTextChanged(EventArgs e)
        {
            if (StatusBarTextChanged_ != null)
            {
                StatusBarTextChanged_(this, e);
            }
        }

        #endregion

        #region public object DataSource {get;set;}

        /// <summary>
        /// Get/Set 
        /// </summary>
        public object DataSource
        {
            get { return dg.DataSource; }
            set
            {
                if (dg.DataSource != value)
                {
                    dg.DataSource = value;
                    OnDataSourceChanged(EventArgs.Empty);
                }
            }
        }

        private event EventHandler DataSourceChanged_;

        public event EventHandler DataSourceChanged
        {
            add { DataSourceChanged_ += value; }
            remove { DataSourceChanged_ -= value; }
        }

        protected virtual void OnDataSourceChanged(EventArgs e)
        {
            if (DataSourceChanged_ != null)
            {
                DataSourceChanged_(this, e);
            }
        }

        #endregion

        public QueryForm()
        {
            InitializeComponent();
            cmdExecute.Height = txtFilename.Height;
            cmdSelectFile.Height = txtFilename.Height;
            txtFilename.Text = Settings.Default.LastDatabase;
        }

        public void NotifyQueryStart()
        {
            progressBar1.Value = 0;
            progressBar1.PerformStep();
        }

        public void ProgressStep()
        {
            progressBar1.PerformStep();
        }

        #region IQueryView Implementation

        void IQueryView.Invoke(Delegate method)
        {
            BeginInvoke(method);
        }

        void IQueryView.Invoke(Delegate method, object[] args)
        {
            BeginInvoke(method, args);
        }

        #endregion

        #region Events

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            frm.Icon = Icon;
            frm.BigIcon = Icon;
            frm.Author = "Jeff Key";
            frm.AuthorUrl = "mailto:jeff.key@sliver.com";
            frm.Company = "www.sliver.com";
            frm.CompanyUrl = "http://www.sliver.com/";
            frm.ShowDialog();
        }

        private void cmdExecute_Click(object sender, EventArgs e)
        {
            OnExecute(EventArgs.Empty);
        }

        private void cmdSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                txtFilename.Text = diag.FileName;
            }
        }

        private void mnuQueryExecute_Click(object sender, EventArgs e)
        {
            OnExecute(EventArgs.Empty);
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                _handled = true;
                OnExecute(EventArgs.Empty);
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                _handled = true;
                txtQuery.SelectAll();
            }
            else
            {
                _handled = false;
            }
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select a database, enter a query and press F5 or CTRL+E (or click execute if " +
                            "you're into that kind of thing).  View results.  Rinse.  Repeat.\n\n" +
                            "If any text is selected, it will be used for the query.",
                            "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_handled)
                e.Handled = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Settings.Default.LastDatabase = txtFilename.Text;
            Settings.Default.Save();
        }

        #endregion
    }
}