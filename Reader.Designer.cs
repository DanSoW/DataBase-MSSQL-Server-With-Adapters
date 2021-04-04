
namespace DataBase
{
	partial class Reader
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.readerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this._txtPasswData = new System.Windows.Forms.TextBox();
			this._txtHomeAddress = new System.Windows.Forms.TextBox();
			this._txtFIO = new System.Windows.Forms.TextBox();
			this._btnInput = new System.Windows.Forms.Button();
			this._btnDelete = new System.Windows.Forms.Button();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.dataBaseSQLDataSet = new DataBase.DataBaseSQLDataSet();
			this.readReaderDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.readReaderDataTableAdapter = new DataBase.DataBaseSQLDataSetTableAdapters.ReadReaderDataTableAdapter();
			this.passwordDataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.homeAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataBaseSQLDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.readReaderDataBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.passwordDataDataGridViewTextBoxColumn,
            this.homeAddressDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.readReaderDataBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(488, 48);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(595, 284);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dbPrePaint);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readerToolStripMenuItem,
            this.bookToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1111, 28);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// readerToolStripMenuItem
			// 
			this.readerToolStripMenuItem.Name = "readerToolStripMenuItem";
			this.readerToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
			this.readerToolStripMenuItem.Text = "Book";
			this.readerToolStripMenuItem.Click += new System.EventHandler(this.readerToolStripMenuItem_Click);
			// 
			// bookToolStripMenuItem
			// 
			this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
			this.bookToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
			this.bookToolStripMenuItem.Text = "Register";
			this.bookToolStripMenuItem.Click += new System.EventHandler(this.bookToolStripMenuItem_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label1.Location = new System.Drawing.Point(12, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(187, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Паспортные данные:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label2.Location = new System.Drawing.Point(12, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(159, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Домашний адрес:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label3.Location = new System.Drawing.Point(13, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "ФИО:";
			// 
			// _txtPasswData
			// 
			this._txtPasswData.Location = new System.Drawing.Point(205, 48);
			this._txtPasswData.Name = "_txtPasswData";
			this._txtPasswData.Size = new System.Drawing.Size(202, 22);
			this._txtPasswData.TabIndex = 5;
			this._txtPasswData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this._txtPasswData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtPasswData_KeyPress);
			// 
			// _txtHomeAddress
			// 
			this._txtHomeAddress.Location = new System.Drawing.Point(205, 87);
			this._txtHomeAddress.Name = "_txtHomeAddress";
			this._txtHomeAddress.Size = new System.Drawing.Size(202, 22);
			this._txtHomeAddress.TabIndex = 6;
			this._txtHomeAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _txtFIO
			// 
			this._txtFIO.Location = new System.Drawing.Point(205, 126);
			this._txtFIO.Name = "_txtFIO";
			this._txtFIO.Size = new System.Drawing.Size(202, 22);
			this._txtFIO.TabIndex = 7;
			this._txtFIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _btnInput
			// 
			this._btnInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this._btnInput.Location = new System.Drawing.Point(205, 165);
			this._btnInput.Name = "_btnInput";
			this._btnInput.Size = new System.Drawing.Size(202, 35);
			this._btnInput.TabIndex = 8;
			this._btnInput.Text = "Добавить";
			this._btnInput.UseVisualStyleBackColor = true;
			this._btnInput.Click += new System.EventHandler(this._btnInput_Click);
			// 
			// _btnDelete
			// 
			this._btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this._btnDelete.Location = new System.Drawing.Point(16, 166);
			this._btnDelete.Name = "_btnDelete";
			this._btnDelete.Size = new System.Drawing.Size(151, 35);
			this._btnDelete.TabIndex = 9;
			this._btnDelete.Text = "Удалить";
			this._btnDelete.UseVisualStyleBackColor = true;
			this._btnDelete.Click += new System.EventHandler(this._btnDelete_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DataBaseSQL;Integrated Securit" +
    "y=True";
			this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "dbo.ReadReaderData";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "dbo.WriteReaderData";
			this.sqlInsertCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@pwd", System.Data.SqlDbType.BigInt, 8, "Password_Data"),
            new System.Data.SqlClient.SqlParameter("@home", System.Data.SqlDbType.NVarChar, 80, "Home_Address"),
            new System.Data.SqlClient.SqlParameter("@fname", System.Data.SqlDbType.NVarChar, 50, "Full_Name")});
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "dbo.UpdateReaderData";
			this.sqlUpdateCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@pwd", System.Data.SqlDbType.BigInt, 8, "Password_Data"),
            new System.Data.SqlClient.SqlParameter("@newHome", System.Data.SqlDbType.NVarChar, 80, "Home_Address"),
            new System.Data.SqlClient.SqlParameter("@newFName", System.Data.SqlDbType.NVarChar, 50, "Full_Name")});
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "dbo.DeleteReaderData";
			this.sqlDeleteCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@pwd", System.Data.SqlDbType.BigInt, 8, "Password_Data")});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ReadReaderData", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Password_Data", "Password_Data"),
                        new System.Data.Common.DataColumnMapping("Home_Address", "Home_Address"),
                        new System.Data.Common.DataColumnMapping("Full_Name", "Full_Name")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// dataBaseSQLDataSet
			// 
			this.dataBaseSQLDataSet.DataSetName = "DataBaseSQLDataSet";
			this.dataBaseSQLDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// readReaderDataBindingSource
			// 
			this.readReaderDataBindingSource.DataMember = "ReadReaderData";
			this.readReaderDataBindingSource.DataSource = this.dataBaseSQLDataSet;
			// 
			// readReaderDataTableAdapter
			// 
			this.readReaderDataTableAdapter.ClearBeforeFill = true;
			// 
			// passwordDataDataGridViewTextBoxColumn
			// 
			this.passwordDataDataGridViewTextBoxColumn.DataPropertyName = "Password_Data";
			this.passwordDataDataGridViewTextBoxColumn.HeaderText = "Паспортные данные";
			this.passwordDataDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.passwordDataDataGridViewTextBoxColumn.Name = "passwordDataDataGridViewTextBoxColumn";
			this.passwordDataDataGridViewTextBoxColumn.ReadOnly = true;
			this.passwordDataDataGridViewTextBoxColumn.Width = 125;
			// 
			// homeAddressDataGridViewTextBoxColumn
			// 
			this.homeAddressDataGridViewTextBoxColumn.DataPropertyName = "Home_Address";
			this.homeAddressDataGridViewTextBoxColumn.HeaderText = "Домашний адрес";
			this.homeAddressDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.homeAddressDataGridViewTextBoxColumn.Name = "homeAddressDataGridViewTextBoxColumn";
			this.homeAddressDataGridViewTextBoxColumn.Width = 125;
			// 
			// fullNameDataGridViewTextBoxColumn
			// 
			this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "Full_Name";
			this.fullNameDataGridViewTextBoxColumn.HeaderText = "ФИО";
			this.fullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
			this.fullNameDataGridViewTextBoxColumn.Width = 125;
			// 
			// Reader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1111, 405);
			this.Controls.Add(this._btnDelete);
			this.Controls.Add(this._btnInput);
			this.Controls.Add(this._txtFIO);
			this.Controls.Add(this._txtHomeAddress);
			this.Controls.Add(this._txtPasswData);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Reader";
			this.Text = "Reader";
			this.Load += new System.EventHandler(this.Reader_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataBaseSQLDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.readReaderDataBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem readerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox _txtPasswData;
		private System.Windows.Forms.TextBox _txtHomeAddress;
		private System.Windows.Forms.TextBox _txtFIO;
		private System.Windows.Forms.Button _btnInput;
		private System.Windows.Forms.Button _btnDelete;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private DataBaseSQLDataSet dataBaseSQLDataSet;
		private System.Windows.Forms.BindingSource readReaderDataBindingSource;
		private DataBaseSQLDataSetTableAdapters.ReadReaderDataTableAdapter readReaderDataTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn homeAddressDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
	}
}

