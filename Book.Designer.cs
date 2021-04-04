
namespace DataBase
{
	partial class Book
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.readerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.registerNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.countPagesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.yearPublishingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sectionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.readBookDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dataBaseSQLDataSet1 = new DataBase.DataBaseSQLDataSet1();
			this._btnDelete = new System.Windows.Forms.Button();
			this._btnInput = new System.Windows.Forms.Button();
			this._txtDataPublish = new System.Windows.Forms.TextBox();
			this._txtCountPage = new System.Windows.Forms.TextBox();
			this._txtPasswData = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this._txtSection = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.readBookDataTableAdapter = new DataBase.DataBaseSQLDataSet1TableAdapters.ReadBookDataTableAdapter();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.readBookDataBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataBaseSQLDataSet1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readerToolStripMenuItem,
            this.bookToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1303, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// readerToolStripMenuItem
			// 
			this.readerToolStripMenuItem.Name = "readerToolStripMenuItem";
			this.readerToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
			this.readerToolStripMenuItem.Text = "Reader";
			this.readerToolStripMenuItem.Click += new System.EventHandler(this.readerToolStripMenuItem_Click);
			// 
			// bookToolStripMenuItem
			// 
			this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
			this.bookToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
			this.bookToolStripMenuItem.Text = "Register";
			this.bookToolStripMenuItem.Click += new System.EventHandler(this.bookToolStripMenuItem_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.registerNumberDataGridViewTextBoxColumn,
            this.countPagesDataGridViewTextBoxColumn,
            this.yearPublishingDataGridViewTextBoxColumn,
            this.sectionDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.readBookDataBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(531, 49);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(748, 293);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dbPrePaint);
			// 
			// registerNumberDataGridViewTextBoxColumn
			// 
			this.registerNumberDataGridViewTextBoxColumn.DataPropertyName = "Register_Number";
			this.registerNumberDataGridViewTextBoxColumn.HeaderText = "Регистрационный номер";
			this.registerNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.registerNumberDataGridViewTextBoxColumn.Name = "registerNumberDataGridViewTextBoxColumn";
			this.registerNumberDataGridViewTextBoxColumn.ReadOnly = true;
			this.registerNumberDataGridViewTextBoxColumn.Width = 125;
			// 
			// countPagesDataGridViewTextBoxColumn
			// 
			this.countPagesDataGridViewTextBoxColumn.DataPropertyName = "Count_Pages";
			this.countPagesDataGridViewTextBoxColumn.HeaderText = "Количество страниц";
			this.countPagesDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.countPagesDataGridViewTextBoxColumn.Name = "countPagesDataGridViewTextBoxColumn";
			this.countPagesDataGridViewTextBoxColumn.Width = 125;
			// 
			// yearPublishingDataGridViewTextBoxColumn
			// 
			this.yearPublishingDataGridViewTextBoxColumn.DataPropertyName = "Year_Publishing";
			this.yearPublishingDataGridViewTextBoxColumn.HeaderText = "Год публикации";
			this.yearPublishingDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.yearPublishingDataGridViewTextBoxColumn.Name = "yearPublishingDataGridViewTextBoxColumn";
			this.yearPublishingDataGridViewTextBoxColumn.Width = 125;
			// 
			// sectionDataGridViewTextBoxColumn
			// 
			this.sectionDataGridViewTextBoxColumn.DataPropertyName = "Section";
			this.sectionDataGridViewTextBoxColumn.HeaderText = "Раздел";
			this.sectionDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.sectionDataGridViewTextBoxColumn.Name = "sectionDataGridViewTextBoxColumn";
			this.sectionDataGridViewTextBoxColumn.Width = 125;
			// 
			// readBookDataBindingSource
			// 
			this.readBookDataBindingSource.DataMember = "ReadBookData";
			this.readBookDataBindingSource.DataSource = this.dataBaseSQLDataSet1;
			// 
			// dataBaseSQLDataSet1
			// 
			this.dataBaseSQLDataSet1.DataSetName = "DataBaseSQLDataSet1";
			this.dataBaseSQLDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// _btnDelete
			// 
			this._btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this._btnDelete.Location = new System.Drawing.Point(17, 224);
			this._btnDelete.Name = "_btnDelete";
			this._btnDelete.Size = new System.Drawing.Size(151, 35);
			this._btnDelete.TabIndex = 17;
			this._btnDelete.Text = "Удалить";
			this._btnDelete.UseVisualStyleBackColor = true;
			this._btnDelete.Click += new System.EventHandler(this._btnDelete_Click);
			// 
			// _btnInput
			// 
			this._btnInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this._btnInput.Location = new System.Drawing.Point(271, 224);
			this._btnInput.Name = "_btnInput";
			this._btnInput.Size = new System.Drawing.Size(202, 35);
			this._btnInput.TabIndex = 16;
			this._btnInput.Text = "Добавить";
			this._btnInput.UseVisualStyleBackColor = true;
			this._btnInput.Click += new System.EventHandler(this._btnInput_Click);
			// 
			// _txtDataPublish
			// 
			this._txtDataPublish.Location = new System.Drawing.Point(271, 127);
			this._txtDataPublish.Name = "_txtDataPublish";
			this._txtDataPublish.Size = new System.Drawing.Size(202, 22);
			this._txtDataPublish.TabIndex = 15;
			this._txtDataPublish.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this._txtDataPublish.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtDataPublish_KeyPress);
			// 
			// _txtCountPage
			// 
			this._txtCountPage.Location = new System.Drawing.Point(271, 88);
			this._txtCountPage.Name = "_txtCountPage";
			this._txtCountPage.Size = new System.Drawing.Size(202, 22);
			this._txtCountPage.TabIndex = 14;
			this._txtCountPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this._txtCountPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtCountPage_KeyPress);
			// 
			// _txtPasswData
			// 
			this._txtPasswData.Location = new System.Drawing.Point(271, 49);
			this._txtPasswData.Name = "_txtPasswData";
			this._txtPasswData.Size = new System.Drawing.Size(202, 22);
			this._txtPasswData.TabIndex = 13;
			this._txtPasswData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this._txtPasswData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtPasswData_KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label3.Location = new System.Drawing.Point(13, 129);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(122, 20);
			this.label3.TabIndex = 12;
			this.label3.Text = "Год издания:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label2.Location = new System.Drawing.Point(12, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(188, 20);
			this.label2.TabIndex = 11;
			this.label2.Text = "Количество страниц:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label1.Location = new System.Drawing.Point(12, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(221, 20);
			this.label1.TabIndex = 10;
			this.label1.Text = "Регистрационный номер:";
			// 
			// _txtSection
			// 
			this._txtSection.Location = new System.Drawing.Point(271, 167);
			this._txtSection.Name = "_txtSection";
			this._txtSection.Size = new System.Drawing.Size(202, 22);
			this._txtSection.TabIndex = 19;
			this._txtSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this._txtSection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtSection_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label4.Location = new System.Drawing.Point(13, 169);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 20);
			this.label4.TabIndex = 18;
			this.label4.Text = "Раздел:";
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DataBaseSQL;Integrated Securit" +
    "y=True";
			this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "dbo.ReadBookData";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "dbo.WriteBookData";
			this.sqlInsertCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@reg", System.Data.SqlDbType.BigInt, 8, "Register_Number"),
            new System.Data.SqlClient.SqlParameter("@pages", System.Data.SqlDbType.SmallInt, 2, "Count_Pages"),
            new System.Data.SqlClient.SqlParameter("@year", System.Data.SqlDbType.SmallInt, 2, "Year_Publishing"),
            new System.Data.SqlClient.SqlParameter("@section", System.Data.SqlDbType.NVarChar, 150, "Section")});
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "dbo.UpdateBookData";
			this.sqlUpdateCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@reg", System.Data.SqlDbType.BigInt, 8, "Register_Number"),
            new System.Data.SqlClient.SqlParameter("@newPages", System.Data.SqlDbType.SmallInt, 2, "Count_Pages"),
            new System.Data.SqlClient.SqlParameter("@newYear", System.Data.SqlDbType.SmallInt, 2, "Year_Publishing"),
            new System.Data.SqlClient.SqlParameter("@newSection", System.Data.SqlDbType.NVarChar, 150, "Section")});
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DeleteBookData";
			this.sqlDeleteCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@reg", System.Data.SqlDbType.BigInt, 0, "Register_Number")});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ReadBookData", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Register_Number", "Register_Number"),
                        new System.Data.Common.DataColumnMapping("Count_Pages", "Count_Pages"),
                        new System.Data.Common.DataColumnMapping("Year_Publishing", "Year_Publishing"),
                        new System.Data.Common.DataColumnMapping("Section", "Section")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// readBookDataTableAdapter
			// 
			this.readBookDataTableAdapter.ClearBeforeFill = true;
			// 
			// Book
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1303, 386);
			this.Controls.Add(this._txtSection);
			this.Controls.Add(this.label4);
			this.Controls.Add(this._btnDelete);
			this.Controls.Add(this._btnInput);
			this.Controls.Add(this._txtDataPublish);
			this.Controls.Add(this._txtCountPage);
			this.Controls.Add(this._txtPasswData);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Book";
			this.Text = "Book";
			this.Load += new System.EventHandler(this.Book_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.readBookDataBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataBaseSQLDataSet1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem readerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button _btnDelete;
		private System.Windows.Forms.Button _btnInput;
		private System.Windows.Forms.TextBox _txtDataPublish;
		private System.Windows.Forms.TextBox _txtCountPage;
		private System.Windows.Forms.TextBox _txtPasswData;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _txtSection;
		private System.Windows.Forms.Label label4;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private DataBaseSQLDataSet1 dataBaseSQLDataSet1;
		private System.Windows.Forms.BindingSource readBookDataBindingSource;
		private DataBaseSQLDataSet1TableAdapters.ReadBookDataTableAdapter readBookDataTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn registerNumberDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn countPagesDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn yearPublishingDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn sectionDataGridViewTextBoxColumn;
	}
}