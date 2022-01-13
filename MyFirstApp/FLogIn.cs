using MySql.Data.MySqlClient;
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

namespace MyFirstApp
{
	public partial class FLogIn : Form
	{
		DB _db;
		Form _parent;

		public FLogIn()
		{
			InitializeComponent();
			_db = new DB();
			_parent = null;
		}

		public FLogIn(Form parent, DB db)
		{
			InitializeComponent();
			_parent = parent;
			_db = db;

		}

		private void FLogIn_Load(object sender, EventArgs e)
		{
			this.PassField.AutoSize = false;
			this.PassField.Size = new Size(this.PassField.Size.Width, 47);

			LoginField.Text = "Введите логин";
			PassField.Text = "Введите пароль";
			PassField.UseSystemPasswordChar = false;
			PassField.ForeColor = LoginField.ForeColor = Color.Gray;
		}

		private void CloseButton_Click(object sender, EventArgs e){Application.Exit();}

		private void CloseButton_MouseEnter(object sender, EventArgs e){closeButton.ForeColor = Color.Red;}

		private void CloseButton_MouseLeave(object sender, EventArgs e){closeButton.ForeColor = Color.White;}

		Point lastPoin;
		private void Panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.Left += e.X - lastPoin.X;
				this.Top += e.Y - lastPoin.Y;
			} 
		}

		private void Panel1_MouseDown(object sender, MouseEventArgs e){lastPoin = new Point(e.X, e.Y);}


		private void ButtonLogin_Click(object sender, EventArgs e)
		{
			string loginUser = LoginField.Text;
			string passUser = PassField.Text;

			DataTable table = new DataTable();

			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT `id_position` FROM `employee`  WHERE `login` = @uL AND `pass` = @uP", _db.GetConnection());
			command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
			command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

			_db.OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0) {
				int id = Convert.ToInt32(table.Rows[0][0]);
				string position = _db.GetNamePositionById(id);
				if (position == "Admin")
				{
					this.Hide();
					Admin admin = new Admin(this, _db);
					admin.Show();
				}
			}
			else
				MessageBox.Show("Пользователь не найден");

			_db.CloseConnection();
		}

		private void LoginField_Enter(object sender, EventArgs e)
		{
			if (LoginField.Text == "Введите логин")
			{
				LoginField.Text = "";
				LoginField.ForeColor = Color.Black;
			}
		}

		private void LoginField_Leave(object sender, EventArgs e)
		{

			if (LoginField.Text == "")
			{
				LoginField.Text = "Введите логин";
				LoginField.ForeColor = Color.Gray;
			}
		}

		private void PassField_Enter(object sender, EventArgs e)
		{
			if (PassField.Text == "Введите пароль")
			{
				PassField.Text = "";
				PassField.ForeColor = Color.Black;
				PassField.UseSystemPasswordChar = true;
			}

		}

		private void PassField_Leave(object sender, EventArgs e)
		{
			if (PassField.Text == "")
			{
				PassField.Text = "Введите пароль";
				PassField.ForeColor = Color.Gray;
				PassField.UseSystemPasswordChar = false; 
			}

		}

		private void StoreButton_Click(object sender, EventArgs e)
		{
			_parent?.Show();
			this.Close();
		}

	}
}
