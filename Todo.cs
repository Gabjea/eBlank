using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
		List<todo> todosW = new List<todo>();

		List<todo> todosM = new List<todo>();
		Label[] tweek;
		Label[] missing;
		struct todo
		{
			public string id;
			public string title;
			public string description;
			public string link;
			public string file;
			public string user_id;
			public string done;
			public string mat;
			public string duedate;
		}


		public Todo(User usr)
		{
			InitializeComponent();
			user = usr;
			Label[] thisweek = { label4, label5, label6, label7, label8, label9, label10, label11,label12,label13};

			Label[] miss = { label24, label25, label26, label27, label28, label29, label30, label31,label32,label33};
			tweek = thisweek;
			
			missing = miss;
			LoadCombo();
			LoadTodosAllThisWeek();
			LoadTodosLater();
			Display(tweek, todosW);
		
			Display(missing, todosM);
		}

		private void LoadCombo()
		{
			con.OpenCon();
			string cmd = "SELECT * FROM materii WHERE clasa_id=@clasa_id";
			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@clasa_id", user.ClasaId);
			using (MySqlDataReader reader = command.ExecuteReader())
			{
			


				while (reader.Read())
				{
					comboBox1.Items.Add(reader["nume"].ToString());
					
					comboBox3.Items.Add(reader["nume"].ToString());

				}

			}

			con.CloseCon();

		}
		
		private void Display(Label[] lb,List<todo> aa)
		{
			for(int i = 0; i < aa.Count(); i++)
			{
				lb[i].Text = aa[i].title;
			}
		}



		private void LoadTodosLater()
		{
			con.OpenCon();
			string cmd = "SELECT * FROM todo WHERE class_id=@class_id AND done=0";
			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@class_id", user.ClasaId);
			command.Parameters.AddWithValue("@date1", DateTime.Now.ToString("dd MMMM yyyy"));

			using (MySqlDataReader reader = command.ExecuteReader())
			{
				todo todo = new todo();

				
				while (reader.Read())
				{

					//DateTime myDate = Convert.ToDateTime(reader["duedate"].ToString());
					DateTime myDate = DateTime.ParseExact(reader["duedate"].ToString(),"dd MMMM yyyy",CultureInfo.InvariantCulture);

					DateTime now = DateTime.Now;
					if (myDate.Subtract(now).TotalHours < 0)
					{

						todo.id = reader["id"].ToString();
						todo.title = reader["title"].ToString();
						todo.description = reader["description"].ToString();
						todo.link = reader["link"].ToString();
						todo.file = reader["file"].ToString();
						todo.user_id = reader["class_id"].ToString();
						todo.done = reader["done"].ToString();
						todo.mat = reader["mat"].ToString();
						todo.duedate = reader["duedate"].ToString();

						todosM.Add(todo);
					}


				}

			}

			con.CloseCon();

		}
		private void LoadTodosAllThisWeek()
		{

			con.OpenCon();
			string cmd = "SELECT * FROM todo WHERE class_id=@class_id AND done=0 AND duedate BETWEEN @date1 AND @date2";
			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@class_id", user.ClasaId);
			command.Parameters.AddWithValue("@date1", DateTime.Now.ToString("dd MMMM yyyy"));
			command.Parameters.AddWithValue("@date2", DateTime.Now.AddDays(7).ToString("dd MMMM yyyy"));
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
					todo.user_id = reader["class_id"].ToString();
					todo.done = reader["done"].ToString();
					todo.mat = reader["mat"].ToString();
					todo.duedate = reader["duedate"].ToString();
					
					todosW.Add(todo);

				}

			}
			
			con.CloseCon();
			
		}

		

		private void Todo_Load_1(object sender, EventArgs e)
		{
			
		}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

		private void panel4_Paint(object sender, PaintEventArgs e)
		{

		}
		private void DisplaySelected(Label[] lb, ComboBox cb,List<todo> a)
		{
			int k = 0;
			for (int i = 0; i < a.Count(); i++)
			{
				if (a[i].mat == cb.SelectedItem.ToString())
				{

					lb[k++].Text = a[i].title;
					
				}
			}
			for (; k < lb.Length; k++)
			{
				lb[k].Text = "";
			}
		}
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			DisplaySelected(tweek,comboBox1,todosW);

		}

	

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			DisplaySelected(missing, comboBox3,todosM);
		}
	}
}