using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
	public partial class Reader : Form
	{
		public const int MAX_SIZE_PSWD = 10;
		public const int MAX_SIZE_HOMEADR = 80;
		public const int MAX_SIZE_FIO = 50;

		private static Book book;
		private static Register register;

		public Reader()
		{
			InitializeComponent();

			register = new Register();
			book = new Book();

			Register.setReader(this);
			Register.setBook(book);

			Book.setReader(this);
			Book.setRegister(register);

			dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
		}

		private void dbPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			int index = e.RowIndex;
			string indexStr = (index + 1).ToString();
			object header = this.dataGridView1.Rows[index].HeaderCell.Value;
			if ((header == null) || (!header.Equals(indexStr)))
				this.dataGridView1.Rows[index].HeaderCell.Value = indexStr;
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
						|| (dataGridView1.Rows[i].Cells[0].Value.ToString().Trim(' ').Length != MAX_SIZE_PSWD))
					{
						flag = false;
					}

					try
					{
						long.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
					}
					catch (Exception) { flag = false; }
				}
			}

			return flag;
		}

		private bool CheckOrientedData(String pass, String home, String fio)
		{
			if ((home.Length == 0)
				|| (fio.Length == 0)
				|| (home.Trim(' ').Length == 0)
				|| (fio.Trim(' ').Length == 0)
				|| (home.Length > MAX_SIZE_HOMEADR)
				|| (fio.Length > MAX_SIZE_FIO)
				|| (!passwordDataValidate(pass)))
				return false;
			try
			{
				long.Parse(pass);
			}
			catch (Exception) { return false; }

			return true;
		}

		public static bool CheckTextBoxes(List<TextBox> txb)
		{
			if (txb.Count == 0)
				return false;

			foreach (var i in txb)
			{
				if (i.Text.Length == 0)
					return false;
			}

			return true;
		}

		public static bool passwordDataValidate(String psw)
		{
			if (psw.Length != MAX_SIZE_PSWD)
				return false;
			bool flag = true;
			foreach (var i in psw)
				if (!Char.IsDigit(i))
				{
					flag = false;
					break;
				}

			return flag;
		}

		private void _btnInput_Click(object sender, EventArgs e)
		{
			if (!CheckTextBoxes(new List<TextBox> { _txtPasswData, _txtHomeAddress, _txtFIO}))
			{
				MessageBox.Show("Ошибка: не все текстовые поля заполнены!", "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!passwordDataValidate(_txtPasswData.Text))
			{
				MessageBox.Show("Ошибка: не корректные паспортные данные! Паспортные даные" +
					" могут состоять только из набора цифр, длина которых строго равна " + MAX_SIZE_PSWD.ToString(), "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_txtPasswData.Text = _txtPasswData.Text.Trim(new char[] { ' ' });
			_txtHomeAddress.Text = _txtHomeAddress.Text.Trim(new char[] { ' ' });
			_txtFIO.Text = _txtFIO.Text.Trim(new char[] { ' ' });

			addDataToDataBase(_txtPasswData.Text, _txtHomeAddress.Text, _txtFIO.Text);
		}

		public DataRow GetCurrentRow(DataGridView dg)
		{
			CurrencyManager cm = (CurrencyManager)dg.BindingContext[dg.DataSource, dg.DataMember];
			if (cm.Count == 0) { return null; }
			DataRowView drv = (DataRowView)cm.Current;
			return drv.Row;
		}


		private void addDataToDataBase(String pwd, String home, String fname)
		{
			if(!CheckOrientedData(pwd, home, fname))
			{
				MessageBox.Show("Ошибка: добавление записи невозможно! Запись содержит не корректные данные!",
					"Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			this.sqlConnection1.Open();
			this.sqlInsertCommand1.Parameters["@pwd"].Value = long.Parse(pwd);
			this.sqlInsertCommand1.Parameters["@home"].Value = home;
			this.sqlInsertCommand1.Parameters["@fname"].Value = fname;
			this.sqlInsertCommand1.ExecuteScalar();

			int result = Convert.ToInt32(this.sqlInsertCommand1.Parameters["@RETURN_VALUE"].Value);
			this.sqlConnection1.Close();

			if (result < 0)
			{
				MessageBox.Show("Ошибка: невозможно добавить запись с паспортными данными " +
				pwd + ", поскольку данные паспортные данные"
				+ " уже присутствуют в базе даных!", "Ошибка!",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			this.readReaderDataTableAdapter.Fill(this.dataBaseSQLDataSet.ReadReaderData);

			return;
		}

		private void _txtPasswData_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;

			if (!Char.IsDigit(number) && (number != 8))
				e.Handled = true;
			if ((number != 8) && (_txtPasswData.Text + number).Length > MAX_SIZE_PSWD)
				e.Handled = true;
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
			String pwd = dataGridView1.Rows[index].Cells[0].Value.ToString();

			this.sqlConnection1.Open();

			this.sqlDeleteCommand1.Parameters["@pwd"].Value = long.Parse(pwd);
			this.sqlDeleteCommand1.ExecuteScalar();

			int result = Convert.ToInt32(this.sqlDeleteCommand1.Parameters["@RETURN_VALUE"].Value);
			this.sqlConnection1.Close();

			if (result < 0)
			{
				MessageBox.Show("Ошибка: невозможно удалить данную запись!" +
					" Данные паспортные данные зарегистрированы! Чтобы удалить данную" +
					" запись необходимо удалить запись с данными паспортными данными!", "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			this.readReaderDataTableAdapter.Fill(this.dataBaseSQLDataSet.ReadReaderData);
		}

		private void readerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			book.Show();
			this.Hide();
		}

		private void bookToolStripMenuItem_Click(object sender, EventArgs e)
		{
			register.Show();
			this.Hide();
		}

		public static DataGridViewRow CloneWithValues(DataGridViewRow row)
		{
			DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
			for (Int32 index = 0; index < row.Cells.Count; index++)
			{
				clonedRow.Cells[index].Value = row.Cells[index].Value;
			}
			return clonedRow;
		}

		public static bool checkRow(DataGridViewRow row)
		{
			for (int i = 0; i < row.Cells.Count; i++)
				if (row.Cells[i].Value == null)
					return false;
			return true;
		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView1.Rows.Count <= 0)
				return;
			int index = e.RowIndex;
			if (index == dataGridView1.Rows.Count)
				return;

			if ((!checkRow(dataGridView1.Rows[index])) || (!CheckOrientedData(
				dataGridView1.Rows[index].Cells[0].Value.ToString(),
				dataGridView1.Rows[index].Cells[1].Value.ToString(),
				dataGridView1.Rows[index].Cells[2].Value.ToString())))
			{
				MessageBox.Show("Ошибка: введены не корректные параметры! Изменение данных не возможно осуществить!", "Ошибка!",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.readReaderDataTableAdapter.Fill(this.dataBaseSQLDataSet.ReadReaderData);
				return;
			}

			this.sqlConnection1.Open();
			this.sqlUpdateCommand1.Parameters["@pwd"].Value = long.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
			this.sqlUpdateCommand1.Parameters["@newHome"].Value = dataGridView1.Rows[index].Cells[1].Value.ToString();
			this.sqlUpdateCommand1.Parameters["@newFName"].Value = dataGridView1.Rows[index].Cells[2].Value.ToString();
			this.sqlUpdateCommand1.ExecuteNonQuery();
			this.sqlConnection1.Close();
		}

		private void Reader_Load(object sender, EventArgs e)
		{
			this.readReaderDataTableAdapter.Fill(this.dataBaseSQLDataSet.ReadReaderData);
		}
	}
}
