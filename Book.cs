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
	public partial class Book : Form
	{
		public const int MAX_SIZE_REGNUM = 10;
		public const int MAX_SIZE_PAGE = 6;
		public const int MAX_SIZE_YEAR = 4;
		public const int MAX_SIZE_SECTION = 150;

		private static Reader reader;
		private static Register register;

		public Book()
		{
			InitializeComponent();

			this.FormClosing += Book_FormClosing;

			dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
		}

		private void Book_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

		public static void setReader(Reader read)
		{
			reader = read;
		}

		public static void setRegister(Register reg)
		{
			register = reg;
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
						|| (dataGridView1.Rows[i].Cells[0].Value.ToString().Trim(' ').Length != MAX_SIZE_REGNUM))
					{
						flag = false;
					}

					try
					{
						long.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
						short.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
						short.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
					}
					catch (Exception) { flag = false; }
				}
			}

			return flag;
		}

		private bool CheckOrientedData(String reg, String pages, String year, String section)
		{
			if ((pages.Length == 0)
				|| (year.Trim(' ').Length == 0)
				|| (section.Trim(' ').Length == 0)
				|| (pages.Length > MAX_SIZE_PAGE)
				|| (year.Length > MAX_SIZE_YEAR)
				|| (section.Length > MAX_SIZE_SECTION)
				|| (!registerNumberValidate(reg)))
				return false;
			try
			{
				long.Parse(reg);
				short.Parse(pages);
				short.Parse(year);
			}
			catch (Exception) { return false; }

			return true;
		}

		public static bool registerNumberValidate(String psw)
		{
			if (psw.Length != MAX_SIZE_REGNUM)
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

		private void addDataToDataBase(String reg, String pages, String year, String section)
		{
			if (!CheckOrientedData(reg, pages, year, section))
			{
				MessageBox.Show("Ошибка: добавление записи невозможно! Запись содержит не корректные данные!",
					"Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			this.sqlConnection1.Open();
			this.sqlInsertCommand1.Parameters["@reg"].Value = long.Parse(reg);
			this.sqlInsertCommand1.Parameters["@pages"].Value = short.Parse(pages);
			this.sqlInsertCommand1.Parameters["@year"].Value = short.Parse(year);
			this.sqlInsertCommand1.Parameters["@section"].Value = section;
			this.sqlInsertCommand1.ExecuteScalar();

			int result = Convert.ToInt32(this.sqlInsertCommand1.Parameters["@RETURN_VALUE"].Value);
			this.sqlConnection1.Close();

			if (result == (-1))
			{
				MessageBox.Show("Ошибка: невозможно добавить запись с регистрационным номером " +
				reg + ", поскольку данный регистрационный номер"
				+ " уже присутствуют в базе даных!", "Ошибка!",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			else if (result == (-2))
			{
				MessageBox.Show("Ошибка: невозможно добавить запись с годом публикации, который позднее" +
					" текущего года установленного на сервере!", "Ошибка!",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			this.readBookDataTableAdapter.Fill(this.dataBaseSQLDataSet1.ReadBookData);
			return;
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

			String reg = dataGridView1.Rows[index].Cells[0].Value.ToString();

			this.sqlConnection1.Open();
			this.sqlDeleteCommand1.Parameters["@reg"].Value = long.Parse(reg);
			this.sqlDeleteCommand1.ExecuteScalar();

			int result = Convert.ToInt32(this.sqlDeleteCommand1.Parameters["@RETURN_VALUE"].Value);
			this.sqlConnection1.Close();

			if (result < 0)
			{
				MessageBox.Show("Ошибка: невозможно удалить данную запись!" +
					" Данный регистрационный номер зарегистрирован! Чтобы удалить данную" +
					" запись необходимо удалить запись с данным регистрационным номером!", "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			this.readBookDataTableAdapter.Fill(this.dataBaseSQLDataSet1.ReadBookData);
		}

		private void _btnInput_Click(object sender, EventArgs e)
		{
			if (!Reader.CheckTextBoxes(new List<TextBox> { _txtPasswData, _txtCountPage, _txtDataPublish }))
			{
				MessageBox.Show("Ошибка: не все текстовые поля заполнены!", "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!registerNumberValidate(_txtPasswData.Text))
			{
				MessageBox.Show("Ошибка: не корректный регистрационный номер!" +
					" Номер должен состоять из числового набора длиной равной " + MAX_SIZE_REGNUM.ToString(), "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_txtPasswData.Text = _txtPasswData.Text.Trim(new char[] { ' ' });
			_txtCountPage.Text = _txtCountPage.Text.Trim(new char[] { ' ' });
			_txtDataPublish.Text = _txtDataPublish.Text.Trim(new char[] { ' ' });
			_txtSection.Text = _txtSection.Text.Trim(new char[] { ' ' });

			addDataToDataBase(_txtPasswData.Text, _txtCountPage.Text, _txtDataPublish.Text, _txtSection.Text);
		}

		private void _txtPasswData_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;

			if (!Char.IsDigit(number) && (number != 8))
				e.Handled = true;
			if ((number != 8) && ((_txtPasswData.Text + number).Length > MAX_SIZE_REGNUM))
				e.Handled = true;
		}

		private void _txtCountPage_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;

			if (!Char.IsDigit(number) && (number != 8))
				e.Handled = true;
			if ((number != 8) && (_txtCountPage.Text + number).Length > MAX_SIZE_PAGE)
				e.Handled = true;
		}

		private void _txtDataPublish_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;

			if (!Char.IsDigit(number) && (number != 8))
				e.Handled = true;
			if ((number != 8) && (_txtDataPublish.Text + number).Length > MAX_SIZE_YEAR)
				e.Handled = true;
		}

		private void _txtSection_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;

			if ((number != 8) && (_txtSection.Text + number).Length > MAX_SIZE_SECTION)
				e.Handled = true;
		}

		private void readerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			reader.Show();
			this.Hide();
		}

		private void bookToolStripMenuItem_Click(object sender, EventArgs e)
		{
			register.Show();
			this.Hide();
		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView1.Rows.Count <= 0)
				return;
			int index = e.RowIndex;
			if (index == dataGridView1.Rows.Count)
				return;

			if ((!Reader.checkRow(dataGridView1.Rows[index])) || (!CheckOrientedData(
				dataGridView1.Rows[index].Cells[0].Value.ToString(),
				dataGridView1.Rows[index].Cells[1].Value.ToString(),
				dataGridView1.Rows[index].Cells[2].Value.ToString(),
				dataGridView1.Rows[index].Cells[3].Value.ToString())))
			{
				MessageBox.Show("Ошибка: введены не корректные параметры! Изменение данных не возможно осуществить!", "Ошибка!",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.readBookDataTableAdapter.Fill(this.dataBaseSQLDataSet1.ReadBookData);
				return;
			}

			this.sqlConnection1.Open();
			this.sqlUpdateCommand1.Parameters["@reg"].Value = long.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
			this.sqlUpdateCommand1.Parameters["@newPages"].Value = short.Parse(dataGridView1.Rows[index].Cells[1].Value.ToString());
			this.sqlUpdateCommand1.Parameters["@newYear"].Value = short.Parse(dataGridView1.Rows[index].Cells[2].Value.ToString());
			this.sqlUpdateCommand1.Parameters["@newSection"].Value = dataGridView1.Rows[index].Cells[3].Value.ToString();
			this.sqlUpdateCommand1.ExecuteScalar();

			int result = Convert.ToInt32(this.sqlUpdateCommand1.Parameters["@RETURN_VALUE"].Value);
			this.sqlConnection1.Close();

			if (result == (-1))
			{
				MessageBox.Show("Ошибка: дата публикации не должна быть позднее текущей даты, установленной на сервере! Изменение невозможно!", "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.readBookDataTableAdapter.Fill(this.dataBaseSQLDataSet1.ReadBookData);
				return;
			}
			else if (result == (-2))
			{
				MessageBox.Show("Ошибка: дата публикации не должна быть позднее дат, которые уже зарегистрированы для данной книги! Для изменения даты публикации" +
					" книги необходимо удалить записи, содержащие даты выдачи книги позднее года публикации, из таблицы регистрации!", "Ошибка!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.readBookDataTableAdapter.Fill(this.dataBaseSQLDataSet1.ReadBookData);
				return;
			}
		}

		private void Book_Load(object sender, EventArgs e)
		{
			this.readBookDataTableAdapter.Fill(this.dataBaseSQLDataSet1.ReadBookData);
		}
	}
}
