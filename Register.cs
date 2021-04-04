﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DataBase
{
	public partial class Register : Form
	{
		public const int MAX_SIZE_DATA = 10;

		private static Reader reader;
		private static Book book;

		public Register()
		{
			InitializeComponent();

			this.FormClosing += Register_FormClosing;
			
			dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

			openFileDialog1.Filter = "Excel files(*.xlsx)|*.xlsx|All files(*.*)|*.*";
			saveFileDialog1.Filter = "Excel files(*.xlsx)|*.xlsx|All files(*.*)|*.*";
		}

		private void Register_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

		public static void setReader(Reader read)
		{
			reader = read;
		}

		public static void setBook(Book bk)
		{
			book = bk;
		}

		private void dbPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			int index = e.RowIndex;
			string indexStr = (index + 1).ToString();
			object header = this.dataGridView1.Rows[index].HeaderCell.Value;
			if ((header == null) || (!header.Equals(indexStr)))
				this.dataGridView1.Rows[index].HeaderCell.Value = indexStr;
		}

		private void readerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			reader.Show();
			this.Hide();
		}

		private void bookToolStripMenuItem_Click(object sender, EventArgs e)
		{
			book.Show();
			this.Hide();
		}

		private void _btnDelete_Click(object sender, EventArgs e)
		{
			if (dataGridView1.CurrentRow == null)
			{
				MessageBox.Show("Ошибка: не выбрана строка для удаления", "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int index = dataGridView1.CurrentRow.Index;

			this.sqlConnection1.Open();
			this.sqlDeleteCommand1.Parameters["@id"].Value = index;
			this.sqlDeleteCommand1.ExecuteNonQuery();
			this.sqlConnection1.Close();

			this.readRegisterDataTableAdapter.Fill(this.dataBaseSQLDataSet2.ReadRegisterData);
		}

		private bool CheckData()
		{
			if (dataGridView1 == null)
				return false;

			bool flag = true;

			for (int i = 0; (i < (dataGridView1.Rows.Count - 1)) && (flag == true); i++)
			{
				for (int j = 0; (j < dataGridView1.Rows[i].Cells.Count) && (flag == true); j++)
				{
					if ((dataGridView1.Rows[i].Cells[j].Value == null)
						|| (dataGridView1.Rows[i].Cells[j].Value.ToString() == "")
						|| (dataGridView1.Rows[i].Cells[j].Value.ToString().Trim(' ') == "")
						|| (dataGridView1.Rows[i].Cells[0].Value.ToString().Trim(' ').Length != Book.MAX_SIZE_REGNUM)
						|| (dataGridView1.Rows[i].Cells[1].Value.ToString().Trim(' ').Length != Reader.MAX_SIZE_PSWD)
						|| (!checkDateEntry(dataGridView1.Rows[i].Cells[2].Value.ToString()))
						|| (!checkDateEntry(dataGridView1.Rows[i].Cells[3].Value.ToString())))
					{
						flag = false;
					}

					try
					{
						long.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
						long.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
					}
					catch (Exception) { flag = false; }
				}
			}

			return flag;
		}

		private bool CheckOrientedData(String reg, String pwd, String dateIssue, String dateReturn)
		{
			if ((!Reader.passwordDataValidate(pwd))
				|| (!Book.registerNumberValidate(reg))
				|| (!checkDateEntry(dateIssue))
				|| (!checkDateEntry(dateReturn)))
			{
				return false;
			}

			try
			{
				long.Parse(reg);
				long.Parse(pwd);
			}
			catch (Exception) { return false; }

			return true;
		}

		private bool checkDateEntry(String date)
		{
			if (date.Length != MAX_SIZE_DATA)
				return false;

			if(date.Count((char i) => (i == '.')) != 2)
			{
				return false;
			}

			foreach (var i in date)
				if ((!Char.IsDigit(i)) && (i != '.'))
					return false;

			string[] dateSplit = date.Split(new char[] { '.' });
			if ((dateSplit[2].Length != 4) || (dateSplit[1].Length != 2) || (dateSplit[0].Length != 2))
				return false;

			try
			{
				int value = int.Parse(dateSplit[0]);
				if ((value <= 0) || (value > 31))
					return false;
				value = int.Parse(dateSplit[1]);
				if ((value <= 0) || (value > 12))
					return false;
				value = int.Parse(dateSplit[2]);
				if ((value <= 0) || (value > 9999))
					return false;
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		private void _btnInput_Click(object sender, EventArgs e)
		{
			if (!Reader.CheckTextBoxes(new List<TextBox> { _txtPasswData1, _txtPasswData2, _txtDataIssue, _txtDataReturn }))
			{
				MessageBox.Show("Ошибка: не все текстовые поля заполнены!", "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!Book.registerNumberValidate(_txtPasswData1.Text))
			{
				MessageBox.Show("Ошибка: не корректный регистрационный номер!" +
					" Номер должен состоять из числового набора длиной равной " + Book.MAX_SIZE_REGNUM.ToString(), "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!Reader.passwordDataValidate(_txtPasswData2.Text))
			{
				MessageBox.Show("Ошибка: не корректные паспортные данные! Паспортные даные" +
					" могут состоять только из набора цифр, длина которых строго равна " + Reader.MAX_SIZE_PSWD.ToString(), "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_txtPasswData1.Text = _txtPasswData1.Text.Trim(new char[] { ' ' });
			_txtPasswData2.Text = _txtPasswData2.Text.Trim(new char[] { ' ' });
			_txtDataIssue.Text = _txtDataIssue.Text.Trim(new char[] { ' ' });
			_txtDataReturn.Text = _txtDataReturn.Text.Trim(new char[] { ' ' });

			if((!checkDateEntry(_txtDataIssue.Text)) || (!checkDateEntry(_txtDataReturn.Text))){
				MessageBox.Show("Ошибка: неверный формат даты! Дата выдачи и возврата должна быть" +
					" в формате ДД.ММ.ГГГГ", "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			addDataToDataBase(_txtPasswData1.Text, _txtPasswData2.Text, _txtDataIssue.Text, _txtDataReturn.Text);
		}

		private void addDataToDataBase(String reg, String pwd, String dateIssue, String dateReturn)
		{
			if (!CheckOrientedData(reg, pwd, dateIssue, dateReturn))
			{
				MessageBox.Show("Ошибка: добавление записи невозможно! Запись содержит не корректные данные!",
					"Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string[] dateString = dateIssue.Split(new char[] { '.' });
			DateTime date1 = new DateTime(int.Parse(dateString[2]), int.Parse(dateString[1]),
						int.Parse(dateString[0]));

			dateString = dateReturn.Split(new char[] { '.' });
			DateTime date2 = new DateTime(int.Parse(dateString[2]), int.Parse(dateString[1]),
						int.Parse(dateString[0]));

			this.sqlConnection1.Open();
			this.sqlInsertCommand1.Parameters["@id"].Value = dataGridView1.Rows.Count;
			this.sqlInsertCommand1.Parameters["@reg"].Value = long.Parse(reg);
			this.sqlInsertCommand1.Parameters["@pwd"].Value = long.Parse(pwd);
			this.sqlInsertCommand1.Parameters["@dateIssue"].Value = date1;
			this.sqlInsertCommand1.Parameters["@dateReturn"].Value = date2;
			this.sqlInsertCommand1.ExecuteScalar();

			int result = Convert.ToInt32(this.sqlInsertCommand1.Parameters["@RETURN_VALUE"].Value);
			this.sqlConnection1.Close();

			string[] names = { "регистрационные данные", "паспортные данные" };

			if ((result < 0) && (result > (-3)))
			{
				MessageBox.Show("Ошибка: в записи содержаться не существующие "
					+ names[(result == (-2)) ? 0 : 1] + "!", "Ошибка!",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			else if (result == (-3))
			{
				MessageBox.Show("Ошибка: дата возврата не может быть раньше даты получения, дата возврата не может быть" +
					" позднее текущей даты, установленной на сервере и дата получения не может быть раньше даты публикации книги!", "Ошибка!",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			else if (result == (-4))
			{
				MessageBox.Show("Ошибка: записи с данным id не присутствует в базе данных, изменение невозможно!", "Ошибка!",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			this.readRegisterDataTableAdapter.Fill(this.dataBaseSQLDataSet2.ReadRegisterData);
			return;
		}

		private void _txtPasswData1_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;

			if (!Char.IsDigit(number) && (number != 8))
				e.Handled = true;
			if ((number != 8) && (_txtPasswData1.Text + number).Length > Book.MAX_SIZE_REGNUM)
				e.Handled = true;
		}

		private void _txtPasswData2_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;

			if (!Char.IsDigit(number) && (number != 8))
				e.Handled = true;
			if ((number != 8) && (_txtPasswData2.Text + number).Length > Reader.MAX_SIZE_PSWD)
				e.Handled = true;
		}
		private void _txtDataIssue_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;

			if (!Char.IsDigit(number) && (number != '.') && (number != 8))
				e.Handled = true;
			if ((number != 8) && (_txtDataIssue.Text + number).Length > MAX_SIZE_DATA)
				e.Handled = true;
		}

		private void _txtDataReturn_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;

			if (!Char.IsDigit(number) && (number != '.') && (number != 8))
				e.Handled = true;
			if ((number != 8) && (_txtDataReturn.Text + number).Length > MAX_SIZE_DATA)
				e.Handled = true;
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;

			if (!Char.IsDigit(number) && (number != 8))
				e.Handled = true;
		}

		private int numberBorrowedBooks(string passwordNumber)
		{
			if (dataGridView1.Rows.Count <= 0)
			{
				throw new Exception("Ошибка: в базе данных нет записей!");
			}

			int count = 0;
			for(int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				if (dataGridView1.Rows[i].Cells[1].Value.ToString().Equals(passwordNumber))
					count++;
			}

			return count;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(textBox1.Text.Length == 0)
			{
				MessageBox.Show("Ошибка: не введено число месяц(-а/-ев)!", "Ошибка!",
					   MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			dataGridView2.Rows.Clear();

			using (SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DataBaseSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
			{
				sqlConnection.Open();

				using (SqlCommand command = new SqlCommand("dbo.TaskOneT", sqlConnection))
				{
					command.CommandType = System.Data.CommandType.StoredProcedure;
					
					command.Parameters.AddWithValue("@monthValue", int.Parse(textBox1.Text));
					SqlDataReader sqlReader = command.ExecuteReader();
					if (sqlReader.HasRows)
					{
						while (sqlReader.Read())
						{
							String fullName = sqlReader.GetValue(0).ToString();
							String pwd = sqlReader.GetValue(1).ToString();
							String reg = sqlReader.GetValue(2).ToString();

							while (pwd.Length != 10)
								pwd = ("0" + pwd);

							while (reg.Length != 10)
								reg = ("0" + reg);

							dataGridView2.Rows.Add(fullName, pwd, reg,
								sqlReader.GetValue(3).ToString().Split(new char[] { ' ' })[0],
								sqlReader.GetValue(4).ToString().Split(new char[] { ' ' })[0],
								"0");
						}
					}
					sqlReader.Close();
				}

				for (int i = 0; i < dataGridView2.Rows.Count; i++)
				{
					using (SqlCommand command2 = new SqlCommand("dbo.DefineBookCounter", sqlConnection))
					{
						command2.CommandType = System.Data.CommandType.StoredProcedure;

						SqlParameter valueReturn = new SqlParameter("valueReturn", SqlDbType.Int);
						valueReturn.Direction = ParameterDirection.ReturnValue;

						command2.Parameters.Add(valueReturn);
						command2.Parameters.AddWithValue("@pwd", long.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString()));
						command2.ExecuteScalar();

						dataGridView2.Rows[i].Cells[dataGridView2.Rows[i].Cells.Count - 1].Value = Convert.ToString(valueReturn.Value);
					}
				}

				sqlConnection.Close();
			}
		}

		private void _txtInputE2_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;

			if (!Char.IsDigit(number) && (number != 8))
				e.Handled = true;
			if ((number != 8) && (_txtInputE2.Text + number).Length > Reader.MAX_SIZE_PSWD)
				e.Handled = true;
		}

		private void _btnExecute2_Click(object sender, EventArgs e)
		{
			if(_txtInputE2.Text.Length != Reader.MAX_SIZE_PSWD)
			{
				MessageBox.Show("Ошибка: не введены паспортные данные!", "Ошибка!",
					   MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			richTextBox1.Clear();

			List<DataElement> elements = new List<DataElement>();

			using (SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DataBaseSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
			{
				sqlConnection.Open();

				using (SqlCommand command = new SqlCommand("dbo.TaskTwot", sqlConnection))
				{
					command.CommandType = System.Data.CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@pwd", long.Parse(_txtInputE2.Text));
					SqlDataReader sqlReader = command.ExecuteReader();
					if (sqlReader.HasRows)
					{
						while (sqlReader.Read())
						{
							String reg = sqlReader.GetValue(0).ToString();

							while (reg.Length != 10)
								reg = ("0" + reg);

							elements.Add(new DataElement(reg,
								sqlReader.GetValue(1).ToString().Split(new char[] { ' ' })[0],
							int.Parse(sqlReader.GetValue(2).ToString()),
							sqlReader.GetValue(3).ToString()));
						}
					}
					sqlReader.Close();
				}

				sqlConnection.Close();
			}

			elements.Sort(new Comparison<DataElement>(compare));
			for (int i = 0; i < elements.Count; i++)
			{
				richTextBox1.Text = richTextBox1.Text + elements[i].ToString() + "\n";
			}
		}

		int compare(DataElement o1, DataElement o2)
		{
			string[] dateString = o1.dataIssue.Split(new char[] { '.' });
			DateTime date1 = new DateTime(int.Parse(dateString[2]), int.Parse(dateString[1]),
				int.Parse(dateString[0]));

			dateString = o2.dataIssue.Split(new char[] { '.' });
			DateTime date2 = new DateTime(int.Parse(dateString[2]), int.Parse(dateString[1]),
				int.Parse(dateString[0]));

			return date1.CompareTo(date2);
		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView1.Rows.Count <= 1)
				return;
			int index = e.RowIndex;
			if (index == dataGridView1.Rows.Count)
				return;

			if ((!Reader.checkRow(dataGridView1.Rows[index])) || (!CheckOrientedData(
				dataGridView1.Rows[index].Cells[0].Value.ToString(),
				dataGridView1.Rows[index].Cells[1].Value.ToString(),
				dataGridView1.Rows[index].Cells[2].Value.ToString().Split(new char[] { ' ' })[0],
				dataGridView1.Rows[index].Cells[3].Value.ToString().Split(new char[] { ' ' })[0])))
			{
				MessageBox.Show("Ошибка: введены не корректные параметры! Изменение данных не возможно осуществить!", "Ошибка!",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.readRegisterDataTableAdapter.Fill(this.dataBaseSQLDataSet2.ReadRegisterData);
				return;
			}

			string[] dateString = dataGridView1.Rows[index].Cells[2].Value.ToString().Split(new char[] { ' ' })[0].Split(new char[] { '.' });
			DateTime date1 = new DateTime(int.Parse(dateString[2]),
				int.Parse(dateString[1]),
				int.Parse(dateString[0]));
			dateString = dataGridView1.Rows[index].Cells[3].Value.ToString().Split(new char[] { ' ' })[0].Split(new char[] { '.' });

			DateTime date2 = new DateTime(int.Parse(dateString[2]),
				int.Parse(dateString[1]),
				int.Parse(dateString[0]));

			this.sqlConnection1.Open();
			this.sqlUpdateCommand1.Parameters["@id"].Value = index;
			this.sqlUpdateCommand1.Parameters["@reg"].Value = long.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
			this.sqlUpdateCommand1.Parameters["@pwd"].Value = long.Parse(dataGridView1.Rows[index].Cells[1].Value.ToString());
			this.sqlUpdateCommand1.Parameters["@dateIssue"].Value = date1;
			this.sqlUpdateCommand1.Parameters["@dateReturn"].Value = date2;
			this.sqlUpdateCommand1.ExecuteScalar();

			int result = Convert.ToInt32(this.sqlUpdateCommand1.Parameters["@RETURN_VALUE"].Value);
			this.sqlConnection1.Close();

			string[] names = { "регистрационные данные", "паспортные данные" };
			if ((result < 0) && (result > (-3)))
			{
				MessageBox.Show("Ошибка: в записи содержаться не существующие "
					+ names[(result == (-2)) ? 0 : 1] + "!", "Ошибка!",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.readRegisterDataTableAdapter.Fill(this.dataBaseSQLDataSet2.ReadRegisterData);
				return;
			}
			else if (result == (-3))
			{
				MessageBox.Show("Ошибка: дата возврата не может быть раньше даты получения, дата возврата не может быть" +
					" позднее текущей даты, установленной на сервере и дата получения не может быть раньше даты публикации книги!", "Ошибка!",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.readRegisterDataTableAdapter.Fill(this.dataBaseSQLDataSet2.ReadRegisterData);
				return;
			}
		}


		private void _btnSaveExcel_Click(object sender, EventArgs e)
		{
			if(dataGridView2.Rows.Count == 0)
			{
				MessageBox.Show("Ошибка: нет данных для сохранения!", "Ошибка!",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
				return;

			string filename = saveFileDialog1.FileName;
			Excel.Application excelApp = new Excel.Application();
			excelApp.Workbooks.Add();
			Excel.Worksheet workSheet = excelApp.ActiveSheet;

			workSheet.Cells[1, "A"] = "ФИО";
			workSheet.Cells[1, "B"] = "Паспортные данные";
			workSheet.Cells[1, "C"] = "Регистрационный номер книги";
			workSheet.Cells[1, "D"] = "Дата выдачи";
			workSheet.Cells[1, "E"] = "Дата возврата";
			workSheet.Cells[1, "F"] = "Количество выданных книг";

			for(int i = 0; i < dataGridView2.Rows.Count; i++)
			{
				workSheet.Cells[(i + 2), "A"] = dataGridView2.Rows[i].Cells[0].Value.ToString();
				workSheet.Cells[(i + 2), "B"] = dataGridView2.Rows[i].Cells[1].Value.ToString();
				workSheet.Cells[(i + 2), "C"] = dataGridView2.Rows[i].Cells[2].Value.ToString();
				workSheet.Cells[(i + 2), "D"] = dataGridView2.Rows[i].Cells[3].Value.ToString();
				workSheet.Cells[(i + 2), "E"] = dataGridView2.Rows[i].Cells[4].Value.ToString();
				workSheet.Cells[(i + 2), "F"] = dataGridView2.Rows[i].Cells[5].Value.ToString();
			}

			try
			{
				workSheet.SaveAs(filename);
				MessageBox.Show("Данные сохранены!", "Информация",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch(Exception)
			{
				MessageBox.Show("Ошибка: неудалось сохранить файл!", "Ошибка!",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			excelApp.Quit();
			System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
		}

		private void _btnReadExcel_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
				return;

			dataGridView2.Rows.Clear();

			string filename = openFileDialog1.FileName;

			Excel.Application excelApp = new Excel.Application();
			Excel.Workbook excelBook = excelApp.Workbooks.Open(filename);
			Excel._Worksheet excelSheet = excelBook.Sheets[1];
			Excel.Range excelRange = excelSheet.UsedRange;

			int rows = excelRange.Rows.Count;
			int cols = excelRange.Columns.Count;
			List<List<string>> maping = new List<List<string>>();
			for (int i = 1; i <= rows; i++)
			{
				maping.Add(new List<string>());
				for (int j = 1; j <= cols; j++)
				{
					if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
						maping[(i-1)].Add(excelRange.Cells[i, j].Value2.ToString());
				}
			}

			excelBook.Close();
			excelApp.Quit();
			System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

			for (int i = 1; i < maping.Count; i++)
			{
				dataGridView2.Rows.Add(
					maping[i][0],
					maping[i][1],
					maping[i][2],
					maping[i][3],
					maping[i][4],
					maping[i][5]);
			}

			dataGridView2.Refresh();

			MessageBox.Show("Данные считаны!", "Информация",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void Register_Load(object sender, EventArgs e)
		{
			this.readRegisterDataTableAdapter.Fill(this.dataBaseSQLDataSet2.ReadRegisterData);
		}
	}

	struct DataElement
	{
		public string register;
		public string dataIssue;
		public int pages;
		public string section;

		public DataElement(string reg, string data, int pages, string section)
		{
			this.register = reg;
			this.dataIssue = data;
			this.pages = pages;
			this.section = section;
		}

		public override string ToString()
		{
			return register + ", " + dataIssue + ", " + pages.ToString()
				+ ", " + section;
		}
	}
}
