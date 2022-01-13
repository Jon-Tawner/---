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
	public partial class FStore : Form
	{
		DB _db;

		public FStore()
		{
			InitializeComponent();

			_db = new DB();
		}

		private void LogIn_Click(object sender, EventArgs e)
		{
			this.Hide();
			FLogIn newForm = new FLogIn(this, _db);
			newForm.Show();
		}

		private void FStore_Load(object sender, EventArgs e){printLV();}
		private void updateLV_Click(object sender, EventArgs e) { printLV(); }
		private void printLV()
		{
			listView.Items.Clear();

			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT	`Title`,`Cost_per_hour`" +
													"FROM `sports_equipment`",
							_db.GetConnection());

			_db.OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			for (int i = 0; i < table.Rows.Count; i++)
			{
				ListViewItem item = new ListViewItem(i.ToString());
				item.SubItems.Add(table.Rows[i][0].ToString());
				item.SubItems.Add(table.Rows[i][1].ToString());

				listView.Items.Add(item);
			}

			_db.CloseConnection();
		}

		private void CloseButton_Click(object sender, EventArgs e){Application.Exit();}
		private void CloseButton_MouseEnter(object sender, EventArgs e) { closeButton.ForeColor = Color.Red; }
		private void CloseButton_MouseLeave(object sender, EventArgs e) { closeButton.ForeColor = Color.White; }

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

	}
}
