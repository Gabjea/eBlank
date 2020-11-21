using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eBlank
{

	public partial class Todo : Form
	{

		public User user;
		DB con = new DB();
		List<todo> todos = new List<todo>();

		struct todo
		{
			public string id;
			public string title;
			public string description;
			public string link;
			public string file;
			public string user_id;
			public string done;
		}


		public Todo(User usr)
		{
			InitializeComponent();
			user = usr;
			LoadTodos();
			
		}


		private void LoadTodos()
		{

			con.OpenCon();
			string cmd = "SELECT * FROM todo WHERE user_id=@user_id";
			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@user_id", user.Id);
			using (MySqlDataReader reader = command.ExecuteReader())
			{
				todo todo = new todo();


				while (reader.Read())
				{
					todo.id = reader["id"].ToString();
					todo.title = reader["title"].ToString();
					todo.description = reader["description"].ToString();
					todo.link = reader["link"].ToString();
					todo.file = reader["file"].ToString();
					todo.user_id = reader["user_id"].ToString();
					todo.done = reader["done"].ToString();
					todos.Add(todo);

				}

			}

			con.CloseCon();
			
		}

		

		private void Todo_Load_1(object sender, EventArgs e)
		{
			
		}
	}
}