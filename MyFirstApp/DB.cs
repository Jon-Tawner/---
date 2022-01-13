using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstApp
{
	public class DB
	{
		MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=averageorganizationdb");

		public void OpenConnection()
		{
			if (connection.State == System.Data.ConnectionState.Closed)
				connection.Open();
		}

		public void CloseConnection()
		{
			if (connection.State == System.Data.ConnectionState.Open)
				connection.Close();
		}

		public MySqlConnection GetConnection()
		{
			return connection;
		}
				
		public int GetIdPositionByName(string position)
		{
			int id = -1;


			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();


			MySqlCommand command = new MySqlCommand("SELECT	`id`" +
													"FROM `position`" +
													"WHERE `Name` = @position",
							GetConnection());
			command.Parameters.Add("@position", MySqlDbType.VarChar).Value = position;

			OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
				id = Convert.ToInt32(table.Rows[0][0]);
			else
				MessageBox.Show("Такую Должность не удалось найти");

			CloseConnection();

			return id;
		}

		public int GetIdSportEquipByName(string name)
		{
			int id = -1;

			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();


			MySqlCommand command = new MySqlCommand("SELECT	`id` FROM `sports_equipment` WHERE `Title` = @name", GetConnection());
			command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;

			OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
				id = Convert.ToInt32(table.Rows[0][0]);
			else
				MessageBox.Show("Инвентарь не был найден");

			CloseConnection();

			return id;
		}

		public int GetIdLastPerson()
		{
			int id = -1;

			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT	`id`" +
													"FROM `person`",
							GetConnection());

			OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
				id = Convert.ToInt32(table.Rows[table.Rows.Count - 1][0]);
			else
				MessageBox.Show("Не удалось найти id последнего в таблице Человека");

			CloseConnection();

			return id;
		}

		public int GetIdRequestByDate(string date)
		{
			int id = -1;

			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT	`id` FROM `request` WHERE `date_request` = @date", GetConnection());
			command.Parameters.Add("@date", MySqlDbType.DateTime).Value = date;

			OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
				id = Convert.ToInt32(table.Rows[0][0]);
			else
				MessageBox.Show("Не удалось найти id запроса по указанной дате");

			CloseConnection();

			return id;
		}

		public string GetPassportNumbClientByIdPerson(int idPerson)
		{
			string passportNumb = null;

			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT	`passport_numb` FROM `client` WHERE `id_person` = @idPerson", GetConnection());
			command.Parameters.Add("@idPerson", MySqlDbType.Int32).Value = idPerson;

			OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
				passportNumb = table.Rows[0][0].ToString();
			else
				MessageBox.Show("Не удалось найти Клиента");

			CloseConnection();

			return passportNumb;
		}

		public string GetNamePositionById(int id)
		{
			string name;

			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT	`Name`" +
													"FROM `position`" +
													"WHERE `id` = @id",
							GetConnection());
			command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
				name = table.Rows[0][0].ToString();
			else
			{
				MessageBox.Show("Такую Должность не удалось найти");
				name = null;
			}

			CloseConnection();

			return name;
		}

		public bool isLoginEmployeExists(string login, string surname, string name, string patron)
		{
			DataTable table = new DataTable();

			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT * FROM `employee`,`person`" +
													"WHERE `employee`.`id_person` = `person`.`id` AND `login` = @login AND (`Surname`<>@surname OR `Name`<>@name OR `Patronymic`<>@patron)",
													GetConnection());
			command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
			command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
			command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
			command.Parameters.Add("@patron", MySqlDbType.VarChar).Value = patron;

			OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
			{
				CloseConnection();
				return true;
			}

			CloseConnection();

			return false;
		}

		public bool isFIOEmplExists(string surname, string name, string patron)
		{
			DataTable table = new DataTable();

			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT * FROM `employee`, `person`  " +
													"WHERE `employee`.`id_person` = `person`.`id` AND `Surname` = @surname AND `Name` = @name AND `Patronymic` = @patron",
													GetConnection());
			command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
			command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
			command.Parameters.Add("@patron", MySqlDbType.VarChar).Value = patron;

			OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
			{
				return true;
			}

			CloseConnection();

			return false;
		}

		public bool isPersonExist(int id)
		{
			DataTable table = new DataTable();

			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT * FROM `person` WHERE `id` = @id", GetConnection());
			command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
			{
				return true;
			}

			CloseConnection();

			return false;
		}

		public bool isClientExistByidperson(int idPerson)
		{
			DataTable table = new DataTable();

			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT * FROM `client` WHERE `id_person` = @idPerson", GetConnection());
			command.Parameters.Add("@idPerson", MySqlDbType.Int32).Value = idPerson;

			OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
			{
				return true;
			}

			CloseConnection();

			return false;
		}

		public bool isPositionExists(string post)
		{
			if (post == "")
			{
				return false;
			}

			DataTable table = new DataTable();

			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand("SELECT * FROM `position`  WHERE `Name` = @name", GetConnection());
			command.Parameters.Add("@name", MySqlDbType.VarChar).Value = post;

			OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
			{
				return true;
			}

			CloseConnection();

			return false;
		}

		/// <summary>
		/// Создаёт Person из формы создания Employee
		/// </summary>
		/// <param name="surnamePerson">Фамилия Человека</param>
		/// <param name="namePerson">Имя Человека</param>
		/// <param name="patronPerson">Фамилия Человека</param>
		public void CreatePerson(string surnamePerson, string namePerson, string patronPerson)
		{
			MySqlCommand comCreatePerson = new MySqlCommand("INSERT INTO `person`(`Surname`, `Name`, `Patronymic`) VALUES (@surname,@name,@patron)", GetConnection());
			comCreatePerson.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surnamePerson;
			comCreatePerson.Parameters.Add("@name", MySqlDbType.VarChar).Value = namePerson;
			comCreatePerson.Parameters.Add("@patron", MySqlDbType.VarChar).Value = patronPerson;

			OpenConnection();

			if (comCreatePerson.ExecuteNonQuery() != 1)
			{
				MessageBox.Show("Не получилось добавить человека в таблицу Person");
			}

			CloseConnection();
		}

		/// <summary>
		/// Создаёт Employee из формы создания Employee
		/// </summary>
		/// <param name="idPerson">id человека, повышаемого до Сотрудника</param>
		/// <param name="position">Должность Сотрудника</param>
		/// <param name="login">Логин Сотрудника</param>
		/// <param name="pass">Пароль Сотрудника</param>
		public void CreateEmployee(int idPerson, string position, string login, string pass)
		{
			int idPosition = GetIdPositionByName(position);

			if (idPosition == -1)
			{
				MessageBox.Show("Не удалось найти Должность по id");
			}

			MySqlCommand comCreateEpml = new MySqlCommand("INSERT INTO `employee`(`id_person`, `id_position`, `login`, `pass`) VALUES (@idPerson, @idPosition, @login, @pass)", GetConnection());
			comCreateEpml.Parameters.Add("@idPerson", MySqlDbType.Int32).Value = idPerson;
			comCreateEpml.Parameters.Add("@idPosition", MySqlDbType.Int32).Value = idPosition;
			comCreateEpml.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
			comCreateEpml.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;

			OpenConnection();

			if (comCreateEpml.ExecuteNonQuery() != 1)
			{
				MessageBox.Show("Не получилось добавить Сотрудника");
			}

			CloseConnection();
		}

		public void CreateSportEquip(string name, int cost)
		{
			MySqlCommand command = new MySqlCommand("INSERT INTO `sports_equipment`(`Title`, `Cost_per_hour`) VALUES (@name, @cost)", GetConnection());
			command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
			command.Parameters.Add("@cost", MySqlDbType.Int32).Value = cost;

			OpenConnection();

			if (command.ExecuteNonQuery() == 0)
			{
				MessageBox.Show("Не получилось добавить Инвентарь");
			}

			CloseConnection();
		}

		public void CreateRequest(int idEquip, int period, string date)
		{
			MySqlCommand command = new MySqlCommand("INSERT INTO `request`(`id_equipment`, `date_request`, `Period`) VALUES (@idEquip, @date, @period)", GetConnection());
			command.Parameters.Add("@idEquip", MySqlDbType.Int32).Value = idEquip;
			command.Parameters.Add("@date", MySqlDbType.DateTime).Value = date;
			command.Parameters.Add("@period", MySqlDbType.Int32).Value = period;

			OpenConnection();

			if (command.ExecuteNonQuery() == 0)
			{
				MessageBox.Show("Не получилось добавить Заказ");
			}

			CloseConnection();
		}

		public void CreateClient(int idPerson, int idRequest, string passportNumb)
		{
			MySqlCommand command = new MySqlCommand("INSERT INTO `client`(`id_person`, `id_request`, `passport_numb`) VALUES (@idPerson, @idRequest, @passportNumb)", GetConnection());
			command.Parameters.Add("@idPerson", MySqlDbType.Int32).Value = idPerson;
			command.Parameters.Add("@idRequest", MySqlDbType.Int32).Value = idRequest;
			command.Parameters.Add("@passportNumb", MySqlDbType.VarChar).Value = passportNumb;

			OpenConnection();

			if (command.ExecuteNonQuery() == 0)
			{
				MessageBox.Show("Не получилось добавить Сотрудника");
			}

			CloseConnection();
		}

		public void DeleteRequest(int id)
		{
			MySqlCommand command = new MySqlCommand("DELETE FROM `request` WHERE `id` = @id",
							GetConnection());
			command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			OpenConnection();

			if (command.ExecuteNonQuery() == 0)
			{
				MessageBox.Show("Не удалить данные");
			}

			CloseConnection();
		}
		public void DeleteEmployee(int id)
		{
			MySqlCommand command = new MySqlCommand("DELETE FROM `employee` WHERE `id` = @id",
								GetConnection());
			command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			OpenConnection();

			if (command.ExecuteNonQuery() == 0)
			{
				MessageBox.Show("Не удалить данные");
			}

			CloseConnection();
		}
		public void DeleteClient(int id)
		{
			MySqlCommand command = new MySqlCommand("DELETE FROM `client` WHERE `id` = @id",
								GetConnection());
			command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			OpenConnection();

			if (command.ExecuteNonQuery() == 0)
			{
				MessageBox.Show("Не удалить данные");
			}

			CloseConnection();
		}
		public void DeleteSportEquip(int id)
		{
			MySqlCommand command = new MySqlCommand("DELETE FROM `sports_equipment` WHERE `id` = @id",
								GetConnection());
			command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			OpenConnection();

			if (command.ExecuteNonQuery() == 0)
			{
				MessageBox.Show("Не удалить данные");
			}

			CloseConnection();
		}
		public void DeletePosition(int id)
		{
			MySqlCommand command = new MySqlCommand("DELETE FROM `position` WHERE `id` = @id",
								GetConnection());
			command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			OpenConnection();

			if (command.ExecuteNonQuery() == 0)
			{
				MessageBox.Show("Не удалить данные");
			}

			CloseConnection();
		}
		public void DeletePerson(int id)
		{
			MySqlCommand command = new MySqlCommand("DELETE FROM `person` WHERE `id` = @id",
								GetConnection());
			command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

			OpenConnection();

			if (command.ExecuteNonQuery() == 0)
			{
				MessageBox.Show("Не удалить данные");
			}

			CloseConnection();
		}
	}
}
