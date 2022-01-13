using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstApp
{
	public partial class Admin : Form
	{
		DB _db;
		Form _parent;

		public Admin()
		{
			InitializeComponent();

			_parent = null;
			_db = new DB();
		}

		public Admin(Form parent, DB db)
		{
			InitializeComponent();
			_db = db;
			_parent = parent;

		}

		private void Admin_Load(object sender, EventArgs e)
		{
			ToolTip TT_orLabel = new ToolTip();
			TT_orLabel.SetToolTip(orLabelEmpl, "При указании id сущ. человека все\n" +
										   "поля ФИО заполнятся автоматически.\n");

			ToolTip TT_optLabel = new ToolTip();
			TT_optLabel.SetToolTip(optLabel, "Поле id не обязательное для заполнения.\n" +
										   "При заполнении id ФИО будет не доступно\n" +
										   "для заполнения");

		}

		Point lastPoin;

		private void Panel1_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoin = new Point(e.X, e.Y);
		}
		private void Panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.Left += e.X - lastPoin.X;
				this.Top += e.Y - lastPoin.Y;
			}
		}
		private void EquipmentButton_Click(object sender, EventArgs e)
		{
			TabCreate.SelectedTab = FrameCreateSprtEquip;
			tabList.SelectedTab = FrameListSprtEquip;
		}
		private void EmployeeButton_Click(object sender, EventArgs e)
		{
			TabCreate.SelectedTab = FrameCreateEmpl;
			tabList.SelectedTab = FrameListEmpl;
		}
		private void ClientButton_Click(object sender, EventArgs e)
		{
			TabCreate.SelectedTab = FrameCreateClient;
			tabList.SelectedTab = FrameListClient;
		}
		private void RequestButton_Click(object sender, EventArgs e)
		{
			TabCreate.SelectedTab = FrameCreateClient;
			tabList.SelectedTab = FrameListReqst;
		}
		private void PositionButton_Click(object sender, EventArgs e)
		{
			TabCreate.SelectedTab = FrameCreatePosit;
			tabList.SelectedTab = FrameListPosit;
		}
		
		/// <summary>
		/// Добавление сотрудника по введённым данным в форму добавления сотрудника
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CreateButtonEmpl_Click(object sender, EventArgs e)
		{
			string surnamePerson = surnameFieldEmpl.Text;
			string namePerson = nameFieldEmpl.Text;
			string patronPerson = patronFieldEmpl.Text;
			string position = positionFieldEmpl.Text;
			string login = loginFieldEmpl.Text;
			string pass = passFieldEmpl.Text;

			//Проверка на валидность формы
			{
				if (_db.isLoginEmployeExists(login, surnamePerson, namePerson, patronPerson))
				{
					MessageBox.Show(loginFieldEmpl, "Сотрудник с таким логином уже существует, введите другой логин");
					return;
				}
				if (surnamePerson == "")
				{
					MessageBox.Show(surnameFieldEmpl, "Заполните поле Фамилия");
					return;
				}
				if (namePerson == "")
				{
					MessageBox.Show(nameFieldEmpl, "Заполните поле Имя");
					return;
				}
				if (patronPerson == "")
				{
					MessageBox.Show(patronFieldEmpl, "Заполните поле Отчество");
					return;
				}
				if (login == "")
				{
					MessageBox.Show(loginFieldEmpl, "Заполните поле Логин");
					return;
				}
				if (pass == "")
				{
					MessageBox.Show(passFieldEmpl, "Заполните поле Пароль");
					return;
				}
				if (!_db.isPositionExists(position))
				{
					MessageBox.Show(positionFieldEmpl, "Данной Должности не существуют");
					return;
				}
			}

			int idPerson;
			if (idFieldEmpl.Text == "")
			{
				_db.CreatePerson(surnamePerson, namePerson, patronPerson);

				idPerson = _db.GetIdLastPerson();
			}
			else
			{
				idPerson = Convert.ToInt32(idFieldEmpl.Text);
			}

			if (_db.isFIOEmplExists(surnamePerson, namePerson, patronPerson))
			{
				DialogResult dialogResult = MessageBox.Show("Данный сотрудник уже существует, применить изменения?", "Сообщение", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					UpdateEmployeeByIdPerson(idPerson);
				}
				else
				{
					return;
				}
			}
			else
				_db.CreateEmployee(idPerson, position, login, pass);

			ClearCreateForm();
		}

		private void CreateButtonClient_Click(object sender, EventArgs e)
		{
			//Проверка на валидность формы
			{
				if (surnameFieldClient.Text == "")
				{
					MessageBox.Show(surnameFieldClient, "Заполните поле Фамилия");
					return;
				}
				if (nameFieldClient.Text == "")
				{
					MessageBox.Show(nameFieldClient, "Заполните поле Фамилия");
					return;
				}
				if (patronFieldClient.Text == "")
				{
					MessageBox.Show(patronFieldClient, "Заполните поле Фамилия");
					return;
				}
				if (periodFieldClient.Text == "")
				{
					MessageBox.Show(periodFieldClient, "Заполните поле Фамилия");
					return;
				}
				if (sportEquipFieldClient.Text == "")
				{
					MessageBox.Show(sportEquipFieldClient, "Заполните поле Фамилия");
					return;
				}
				if (passportNumbFieldClient.Text == "")
				{
					MessageBox.Show(passportNumbFieldClient, "Заполните поле Паспорт");
					return;
				}
			}

			string surnamePerson = surnameFieldClient.Text;
			string namePerson = nameFieldClient.Text;
			string patronPerson = patronFieldClient.Text;
			string sportEquip = sportEquipFieldClient.Text;
			int period = Convert.ToInt32(periodFieldClient.Text);
			string passportNumb = passportNumbFieldClient.Text;
			DateTime date = new DateTime();
			date = DateTime.Now;
			
			string month = date.Month>10 ? date.Month.ToString(): '0'+ date.Month.ToString();
			string day = date.Day > 10 ? date.Day.ToString() : '0' + date.Day.ToString();
			string hour = date.Hour > 10 ? date.Hour.ToString() : '0' + date.Hour.ToString();
			string minute = date.Minute > 10 ? date.Minute.ToString() : '0' + date.Minute.ToString();
			string second = date.Second > 10 ? date.Second.ToString() : '0' + date.Second.ToString();
			string date_s = date.Year.ToString() + '-' + month + '-' + day + ' ' + hour + ':' + minute + ':' + second;
			
			_db.CreatePerson(surnamePerson, namePerson, patronPerson);

			int idPerson = _db.GetIdLastPerson();
			int idSportEquip = _db.GetIdSportEquipByName(sportEquip);

			if (idPerson == -1 || idSportEquip == -1)
			{
				return;
			}

			_db.CreateRequest(idSportEquip, period, date_s);

			int idRequest = _db.GetIdRequestByDate(date_s);

			if (idRequest == -1)
			{
				return;
			}

			_db.CreateClient(idPerson, idRequest, passportNumb);

			ClearCreateForm();
		}

		private void CreateSportEquipButton_Click(object sender, EventArgs e)
		{
			//Проверка на валидность формы
			{
				if (sportEquipFieldSportEquip.Text == "")
				{
					MessageBox.Show(sportEquipFieldSportEquip, "Введите название нового Инвентаря");
					return;
				}
				if (costFieldSportEquip.Text == "")
				{
					MessageBox.Show(costFieldSportEquip, "Введите стоимость нового Инвентаря");
					return;
				}
			}

			string name = sportEquipFieldSportEquip.Text;
			int cost = Convert.ToInt32(costFieldSportEquip.Text);

			_db.CreateSportEquip(name, cost);

			ClearCreateForm();
		}

		private void CreateButtonPost_Click(object sender, EventArgs e)
		{
			string namePost = positionFieldPost.Text;
			string salary = salaryFieldPost.Text;

			//Проверка на валидность формы
			{
				if (namePost == "")
				{
					MessageBox.Show(positionFieldPost, "Заполните поле Должность");
					return;
				}
				if (_db.isPositionExists(namePost))
				{
					MessageBox.Show(positionFieldPost, "Данная Должность уже существует");
					return;
				}
				if (salaryFieldPost.Text == "")
				{
					MessageBox.Show(salaryFieldPost, "Заполните поле Зарплата");
					return;
				}
			}

			MySqlCommand command = new MySqlCommand("INSERT INTO `position`(`Name`, `Salary`) VALUES (@name,@salary)", _db.GetConnection());
			command.Parameters.Add("@name", MySqlDbType.VarChar).Value = namePost;
			command.Parameters.Add("@salary", MySqlDbType.VarChar).Value = salary;

			_db.OpenConnection();

			if (command.ExecuteNonQuery() != 1)
			{
				MessageBox.Show("Не получилось добавить новую Должность");
			}

			_db.CloseConnection();

			ClearCreateForm();
		}

		/// <summary>
		/// Очищает текущую открытую форму
		/// </summary>
		private void ClearCreateForm()
		{
			TabPage Selectedpage = TabCreate.SelectedTab;
			foreach (var textBox in Selectedpage.Controls.OfType<TextBox>())
			{
				textBox.Text = "";
			}
		}

		/// <summary>
		/// Автозаполняет поля ФИО при указании в поле id(Панель добавления Сотрудников) существующего человека
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IdFieldEmpl_TextChanged(object sender, EventArgs e)
		{
			string idPerson = idFieldEmpl.Text;

			if (idPerson == "")
			{
				surnameFieldEmpl.Enabled = true;
				nameFieldEmpl.Enabled = true;
				patronFieldEmpl.Enabled = true;
				return;
			}

			DataTable table = new DataTable();

			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT * FROM `person`  WHERE `id` = @id ", _db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.VarChar).Value = idPerson;

			_db.OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0){
				surnameFieldEmpl.Text = Convert.ToString(table.Rows[0][1]);
				nameFieldEmpl.Text = Convert.ToString(table.Rows[0][2]);
				patronFieldEmpl.Text = Convert.ToString(table.Rows[0][3]);

				surnameFieldEmpl.Enabled = false;
				nameFieldEmpl.Enabled = false;
				patronFieldEmpl.Enabled = false;
			}
			else
			{
				MessageBox.Show(idFieldEmpl, "Данного id не существует. Очистите поле id и введите ФИО");
				ClearCreateForm();
				idFieldEmpl.Text = idPerson;
			}

			_db.CloseConnection();
		}

		/// <summary>
		/// Обновляет listView содержимым таблицы Сотрудники(employee)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateListEmplButton_Click(object sender, EventArgs e)
		{
			listViewEmpl.Items.Clear();

			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			_db.OpenConnection();

			MySqlCommand command = new MySqlCommand("SELECT	`employee`.`id`,`Surname`,`person`.`Name`,`Patronymic`,`position`.`Name`,`login` " +
													"FROM `employee`, `person`, `position`" +
													"WHERE `employee`.`id_person` = `person`.`id` AND `employee`.`id_position` = `position`.`id`",
							_db.GetConnection());

			adapter.SelectCommand = command;
			adapter.Fill(table);

			for (int i = 0; i < table.Rows.Count; i++)
			{
				ListViewItem item = new ListViewItem(table.Rows[i][0].ToString());
				item.SubItems.Add(table.Rows[i][1].ToString());
				item.SubItems.Add(table.Rows[i][2].ToString());
				item.SubItems.Add(table.Rows[i][3].ToString());
				item.SubItems.Add(table.Rows[i][4].ToString());
				item.SubItems.Add(table.Rows[i][5].ToString());

				listViewEmpl.Items.Add(item);
			}

			_db.CloseConnection();
		}

		/// <summary>
		/// Изменяем должность, логин, пароль записи таблицы Employee 
		/// </summary>
		private void UpdateEmployeeByIdPerson(int idPerson)
		{
			DB _db = new DB();

			int newIdPosition = _db.GetIdPositionByName(positionFieldEmpl.Text);
			string newLogin = loginFieldEmpl.Text;
			string newPass = passFieldEmpl.Text;

			MySqlCommand comCreatePerson = new MySqlCommand("UPDATE `employee` SET `id_position` = @newIdPost, `login` = @newLogin, `pass` = @newPass " +
															"WHERE `employee`.`id_person`=@idPerson",
															_db.GetConnection());
			comCreatePerson.Parameters.Add("@newIdPost", MySqlDbType.Int32).Value = newIdPosition;
			comCreatePerson.Parameters.Add("@newLogin", MySqlDbType.VarChar).Value = newLogin;
			comCreatePerson.Parameters.Add("@newPass", MySqlDbType.VarChar).Value = newPass;
			comCreatePerson.Parameters.Add("@idPerson", MySqlDbType.VarChar).Value = idPerson;

			_db.OpenConnection();

			if (comCreatePerson.ExecuteNonQuery() == 0)
			{
				MessageBox.Show("Не получилось Изменить данные сотрудника");
			}

			_db.CloseConnection();
		}

		/// <summary>
		/// Обновляет listView содержимым таблицы Клиент(client)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateListClientButton_Click(object sender, EventArgs e)
		{
			listViewClient.Items.Clear();

			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT	`id_person`,`Surname`,`person`.`Name`,`Patronymic`,`id_request`" +
													"FROM `client`, `person`" +
													"WHERE `client`.`id_person` = `person`.`id`",
							_db.GetConnection());

			_db.OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			for (int i = 0; i < table.Rows.Count; i++)
			{
				ListViewItem item = new ListViewItem(table.Rows[i][0].ToString());
				item.SubItems.Add(table.Rows[i][1].ToString());
				item.SubItems.Add(table.Rows[i][2].ToString());
				item.SubItems.Add(table.Rows[i][3].ToString());
				item.SubItems.Add(table.Rows[i][4].ToString());

				listViewClient.Items.Add(item);
			}

			_db.CloseConnection();
		}

		/// <summary>
		/// Обновляет listView содержимым таблицы Спортивный инвентарь(sports_equipment)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateListSportEquipButton_Click(object sender, EventArgs e)
		{
			listViewSportEquip.Items.Clear();

			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT	`id`,`Title`,`Cost_per_hour`" +
													"FROM `sports_equipment`",
							_db.GetConnection());

			_db.OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			for (int i = 0; i < table.Rows.Count; i++)
			{
				ListViewItem item = new ListViewItem(table.Rows[i][0].ToString());
				item.SubItems.Add(table.Rows[i][1].ToString());
				item.SubItems.Add(table.Rows[i][2].ToString());

				listViewSportEquip.Items.Add(item);
			}

			_db.CloseConnection();
		}

		/// <summary>
		/// Обновляет listView содержимым таблицы Заказы(request)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateListRequestButton_Click(object sender, EventArgs e)
		{
			listViewRequest.Items.Clear();

			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT	`request`.`id`,`sports_equipment`.`Title`,`date_request`,`Period`" +
													"FROM `request`, `sports_equipment`" +
													"WHERE `request`.`id_equipment` = `sports_equipment`.`id`",
							_db.GetConnection());

			_db.OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			for (int i = 0; i < table.Rows.Count; i++)
			{
				ListViewItem item = new ListViewItem(table.Rows[i][0].ToString());
				item.SubItems.Add(table.Rows[i][1].ToString());
				item.SubItems.Add(table.Rows[i][2].ToString());
				item.SubItems.Add(table.Rows[i][3].ToString());

				listViewRequest.Items.Add(item);
			}

			_db.CloseConnection();
		}

		/// <summary>
		/// Обновляет listView содержимым таблицы Должность(position)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateListPositionButton_Click(object sender, EventArgs e)
		{
			listViewPosition.Items.Clear();

			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT	`id`,`Name`,`Salary`" +
													"FROM `position`",
							_db.GetConnection());

			_db.OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			for (int i = 0; i < table.Rows.Count; i++)
			{
				ListViewItem item = new ListViewItem(table.Rows[i][0].ToString());
				item.SubItems.Add(table.Rows[i][1].ToString());
				item.SubItems.Add(table.Rows[i][2].ToString());

				listViewPosition.Items.Add(item);
			}

			_db.CloseConnection();
		}

		private void UpdateListPersonButton_Click(object sender, EventArgs e)
		{
			listViewPerson.Items.Clear();

			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT	`id`,`Surname`,`Name`,`Patronymic`" +
													"FROM `person`",
							_db.GetConnection());

			_db.OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			for (int i = 0; i < table.Rows.Count; i++)
			{
				ListViewItem item = new ListViewItem(table.Rows[i][0].ToString());
				item.SubItems.Add(table.Rows[i][1].ToString());
				item.SubItems.Add(table.Rows[i][2].ToString());
				item.SubItems.Add(table.Rows[i][3].ToString());

				listViewPerson.Items.Add(item);
			}

			_db.CloseConnection();
		}

		/// <summary>
		/// Установка полей формы создания Employee при нажатии id в таблице Employee
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ListViewEmpl_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewEmpl.SelectedItems.Count > 0)
			{
				int idSelected = Convert.ToInt32(listViewEmpl.SelectedItems[0].Text);
				ClearCreateForm();

				DataTable table = new DataTable();
				MySqlDataAdapter adapter = new MySqlDataAdapter();

				MySqlCommand command = new MySqlCommand("SELECT	`employee`.`id_person`,`Surname`,`person`.`Name`,`Patronymic`,`position`.`Name`,`login`,`pass` " +
														"FROM `position`,`employee`,`person` " +
														"WHERE " +
															"`employee`.`id` = @id AND " +
															"`position`.`id` = `employee`.`id_position` AND " +
															"`employee`.`id_person` = `person`.`id`",
								_db.GetConnection());
				command.Parameters.Add("@id", MySqlDbType.Int32).Value = idSelected;

				_db.OpenConnection();

				adapter.SelectCommand = command;
				adapter.Fill(table);

				if(table.Rows.Count > 0)
				{
					idFieldEmpl.Text = table.Rows[0][0].ToString();
					surnameFieldEmpl.Text = table.Rows[0][1].ToString();
					nameFieldEmpl.Text = table.Rows[0][2].ToString();
					patronFieldEmpl.Text = table.Rows[0][3].ToString();
					positionFieldEmpl.Text = table.Rows[0][4].ToString();
					loginFieldEmpl.Text = table.Rows[0][5].ToString();
					passFieldEmpl.Text = table.Rows[0][6].ToString();
				}

				_db.CloseConnection();
			}
		}

		private void ListViewClient_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewClient.SelectedItems.Count > 0)
			{
				int idSelected = Convert.ToInt32(listViewClient.SelectedItems[0].Text);
				ClearCreateForm();

				DataTable table = new DataTable();
				MySqlDataAdapter adapter = new MySqlDataAdapter();

				MySqlCommand command = new MySqlCommand("SELECT	`client`.`id_person`,`Surname`,`Name`,`Patronymic`,`Title`,`Period`,`passport_numb` " +
														"FROM `client`,`person`,`request`,`sports_equipment` " +
														"WHERE " +
															"`client`.`id` = @id AND " +
															"`client`.`id_person` = `person`.`id` AND" +
															"`client`.`id_request` = `request`.`id` AND " +
															"`request`.`id_equipment` = `sports_equipment`.`id`",
								_db.GetConnection());
				command.Parameters.Add("@id", MySqlDbType.Int32).Value = idSelected;

				_db.OpenConnection();

				adapter.SelectCommand = command;
				adapter.Fill(table);

				if (table.Rows.Count > 0)
				{
					surnameFieldClient.Text = table.Rows[0][1].ToString();
					nameFieldClient.Text = table.Rows[0][2].ToString();
					patronFieldClient.Text = table.Rows[0][3].ToString();
					periodFieldClient.Text = table.Rows[0][4].ToString();
					sportEquipFieldClient.Text = table.Rows[0][5].ToString();
					passportNumbFieldClient.Text = table.Rows[0][6].ToString();
				}
				else
					MessageBox.Show("Не удалось найти данные");

				_db.CloseConnection();
			}
		}

		private void ListViewSportEquip_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewSportEquip.SelectedItems.Count > 0)
			{
				int idSelected = Convert.ToInt32(listViewSportEquip.SelectedItems[0].Text);
				ClearCreateForm();

				DataTable table = new DataTable();
				MySqlDataAdapter adapter = new MySqlDataAdapter();

				MySqlCommand command = new MySqlCommand("SELECT `Title`,`Cost_per_hour` FROM `sports_equipment` WHERE `id` = @id",
								_db.GetConnection());
				command.Parameters.Add("@id", MySqlDbType.Int32).Value = idSelected;

				_db.OpenConnection();

				adapter.SelectCommand = command;
				adapter.Fill(table);

				if (table.Rows.Count > 0)
				{
					sportEquipFieldSportEquip.Text = table.Rows[0][0].ToString();
					costFieldSportEquip.Text = table.Rows[0][1].ToString();
				}
				else
					MessageBox.Show("Не удалось найти данные");

				_db.CloseConnection();
			}
		}

		private void ListViewPosition_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewPosition.SelectedItems.Count > 0)
			{
				int idSelected = Convert.ToInt32(listViewPosition.SelectedItems[0].Text);
				ClearCreateForm();

				DataTable table = new DataTable();
				MySqlDataAdapter adapter = new MySqlDataAdapter();

				MySqlCommand command = new MySqlCommand("SELECT	`Name`,`Salary` FROM `position` WHERE `id` = @id",
								_db.GetConnection());
				command.Parameters.Add("@id", MySqlDbType.Int32).Value = idSelected;

				_db.OpenConnection();

				adapter.SelectCommand = command;
				adapter.Fill(table);

				if (table.Rows.Count > 0)
				{
					positionFieldPost.Text = table.Rows[0][0].ToString();
					salaryFieldPost.Text = table.Rows[0][1].ToString();
				}
				else
					MessageBox.Show("Не удалось найти данные");

				_db.CloseConnection();
			}
		}


		private void PayWagesButton_Click(object sender, EventArgs e)
		{
			if (listViewEmpl.SelectedItems.Count > 0)
			{
				DialogResult result = MessageBox.Show("Выдать зарплату указанным сотрудникам?","Оплата", MessageBoxButtons.YesNo);
				if (result == DialogResult.OK)
				{
					MessageBox.Show("Деньги выплачены");
				}
			}
			else
			{
				DialogResult result = MessageBox.Show("Выдать всем сотрудникам?", "Оплата", MessageBoxButtons.YesNo);
				if (result == DialogResult.OK)
				{
					MessageBox.Show("Деньги выплачены");
				}
			}
		}

		private void ClearCreateForm(object sender, EventArgs e)
		{
			ClearCreateForm();
		}

		private void DeleteListEmplButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < listViewEmpl.SelectedItems.Count ; ++i)
			{
				int idSelected = Convert.ToInt32(listViewEmpl.SelectedItems[i].Text);

				_db.DeleteEmployee(idSelected);
			}
		}

		private void DeleteListClientButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < listViewClient.SelectedItems.Count; ++i)
			{
				int idSelected = Convert.ToInt32(listViewClient.SelectedItems[i].Text);

				_db.DeleteClient(idSelected);
			}
		}

		private void DeleteListSportEquipButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < listViewSportEquip.SelectedItems.Count; ++i)
			{
				int idSelected = Convert.ToInt32(listViewSportEquip.SelectedItems[i].Text);

				_db.DeleteSportEquip(idSelected);
			}
		}

		private void DeleteListRequestButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < listViewRequest.SelectedItems.Count; ++i)
			{
				int idSelected = Convert.ToInt32(listViewRequest.SelectedItems[i].Text);

				_db.DeleteRequest(idSelected);
			}
		}
		
		private void DeleteListPositionButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < listViewPosition.SelectedItems.Count; ++i)
			{
				int idSelected = Convert.ToInt32(listViewPosition.SelectedItems[i].Text);

				_db.DeletePosition(idSelected);
			}
		}

		private void DeleteListPersonButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < listViewPerson.SelectedItems.Count; ++i)
			{
				int idSelected = Convert.ToInt32(listViewPerson.SelectedItems[i].Text);

				_db.DeletePerson(idSelected);
			}
		}

		private void LogInButton_Click(object sender, EventArgs e)
		{
			_parent?.Show();
			this.Close();
		}

		private void CloseButton_Click(object sender, EventArgs e){ Application.Exit(); }

	}
}
