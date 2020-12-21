// brian.takita@runbox.com
namespace sliver.AccessQueryAnalyzer {
	using System;
	using System.Data;
	using System.Data.OleDb;

	/// <summary>
	/// Summary description for QueryRunner.
	/// </summary>
	public class QueryRunner : IDisposable {
		private delegate void BindDataHandler (DataTable table, DateTime startTime);
		private delegate void EmptyHandler ();
		private BindDataHandler BindData_;
		private EmptyHandler ProgressStart_;
		private EmptyHandler ProgressStep_;
		
		public QueryRunner (IQueryView queryView) {
			this.BindData_ = new BindDataHandler (BindData);
			this.ProgressStart_ = new EmptyHandler (ProgressStart);
			this.ProgressStep_ = new EmptyHandler (ProgressStep);
			this.QueryView_ = queryView;
		}

		public void Dispose () {
			this.ShowError_ = null;
			this.ShowMessage_ = null;
		}

		#region public IQueryView QueryView {get;}
		private IQueryView QueryView_;
		
		/// <summary>
		/// Get 
		/// </summary>
		public IQueryView QueryView {
			get {
				return QueryView_;
			}
		}
		#endregion

		#region public event ShowErrorEventHandler ShowError
		private event ShowErrorEventHandler ShowError_;
		public event ShowErrorEventHandler ShowError {
			add {
				ShowError_+=value;
			}
			remove {
				ShowError_-=value;
			}
		}

		protected virtual void OnShowError (ShowErrorEventArgs e) {
			if (this.ShowError_!=null) {
				this.ShowError_ (this, e);
			}
		}
		#endregion

		#region public event ShowMessageEventHandler ShowMessage
		private event ShowMessageEventHandler ShowMessage_;
		public event ShowMessageEventHandler ShowMessage {
			add {
				ShowMessage_+=value;
			}
			remove {
				ShowMessage_-=value;
			}
		}

		protected virtual void OnShowMessage (ShowMessageEventArgs e) {
			if (this.ShowMessage_!=null) {
				this.ShowMessage_ (this, e);
			}
		}
		#endregion

		public void Execute () {
			try {
				this.QueryView_.Invoke (this.ProgressStart_);
				DateTime startTime = DateTime.Now;
				string query = this.QueryView_.QueryText.Trim ();
				string filename = this.QueryView_.FileName.Trim ();
				bool isInsert = query.ToLower().StartsWith ("insert");
				bool isUpdate = query.ToLower().StartsWith("update");
				bool isDelete = query.ToLower().StartsWith("delete");
				bool isCreate = query.ToLower().StartsWith("create");
				bool isAlter = query.ToLower().StartsWith("alter");
				//bool isStoredProcedure = query.ToLower().StartsWith("exec");
				bool isExecutable = isInsert | isUpdate | isDelete | isCreate | isAlter;

				if (query == string.Empty) {
					this.OnShowError (new ShowErrorEventArgs ("Please enter a query."));
					return;
				} else if (filename == string.Empty) {
					this.OnShowError (new ShowErrorEventArgs ("Please enter a database."));
					return;
				}

				OleDbConnection conn = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\"{0}\";", filename));

				if (!isExecutable) {					
					OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
					this.QueryView_.Invoke (this.ProgressStep_);
					DataTable table = new DataTable("Table");
					da.Fill (table);
					this.QueryView_.Invoke (this.ProgressStep_);
					this.QueryView_.Invoke (this.BindData_, new object [] {table, startTime});
				}
				else {
					OleDbCommand cmd = null;
					int modRows = 0;
					try {
						cmd = new OleDbCommand (query, conn);
						conn.Open();
						this.QueryView_.Invoke (this.ProgressStep_);
						modRows = cmd.ExecuteNonQuery ();
						conn.Close();
					}
					finally {
						cmd.Dispose ();
						cmd = null;
						conn = null;
					}
					this.QueryView_.Invoke (this.ProgressStep_);

					if (isCreate) {
						this.OnShowMessage (new ShowMessageEventArgs ("Table Created."));
					}
					else if (isAlter) {
						this.OnShowMessage (new ShowMessageEventArgs ("Altered."));
					}
					else {
						string action = null;
						if (isInsert) {
							action = "inserted";
						}
						else if (isUpdate) {
							action = "updated";
						}
						else if (isDelete) {
							action = "deleted";
						}
						else if (isCreate) {
							action = "created";
						}
//						else if (isStoredProcedure) {
//							action = "affected";
//						}
						this.OnShowMessage (new ShowMessageEventArgs (string.Format("{0} rows {1}.", modRows, action)));
					}
				}
			}
			catch (Exception ex) {
				this.OnShowError (new ShowErrorEventArgs (ex));
			}
			finally {
				this.Dispose ();
			}
		}

		private void ProgressStart () {
			this.QueryView_.NotifyQueryStart ();
		}

		private void ProgressStep () {
			this.QueryView_.ProgressStep ();
		}

		private void BindData (DataTable table, DateTime startTime) {
			TimeSpan ts = DateTime.Now - startTime;
			this.QueryView_.DataSource = table;
			this.QueryView_.StatusText = string.Format("{0} rows in {1:0.####} seconds", table.Rows.Count, ts.TotalSeconds);
		}
	}
}
