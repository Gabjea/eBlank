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

namespace eBlank
{
	public partial class Home : Form
	{
		public User user;
		DB con = new DB();

		string[] ore = new string[9];

		public string nextclass = "romana";

		public Home(User usr)
		{
			InitializeComponent();
			timer1.Start();
			user = usr;
			Label[] todos = { label4, label5, label6, label7 };
			Label[] test_name = { label9, label10, label12, label14 };
			Label[] test_mat = { label8, label11, label13, label15 };
			Label[] test_date = { label16, label17, label18, label19 };
			LoadTodo(todos);
			LoadTests(test_name,test_mat,test_date);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
		}


		private void CenterControl(Control c)
		{

			c.Location = new Point(
				this.Width / 2 - c.Size.Width / 2,
				c.Location.Y
				);
		}

		private void Home_Load(object sender, EventArgs e)
		{
			GetHour();

			label21.Text = GetClassLink(GetNextClass());


		}

		private void LoadTodo(Label[] lb)
		{
			con.OpenCon();
			string cmd = "SELECT * FROM todo WHERE class_id=@class_id AND done=0";

			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@class_id", user.ClasaId);

			using (MySqlDataReader reader = command.ExecuteReader())
			{

				int k = 0;
				while(reader.Read())
				{
					lb[k++].Text = reader[1].ToString();
				}

				
				

			}
			con.CloseCon();
		}
		private void LoadTests(Label[] name, Label[] mat, Label[] date)
		{
			con.OpenCon();
			string cmd = "SELECT * FROM tests WHERE clasa_id=@clasa_id AND open=1";

			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@clasa_id", user.ClasaId);

			using (MySqlDataReader reader = command.ExecuteReader())
			{

				int k = 0;
				while (reader.Read())
				{
					name[k].Text = reader[1].ToString();
					mat[k].Text = reader[3].ToString();
					date[k++].Text = reader[4].ToString();
				}




			}
			con.CloseCon();
		}


		private string GetHour()
		{
			con.OpenCon();
			string cmd = "SELECT * FROM ore_cursuri WHERE clasa_id=@clasa_id";

			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@clasa_id", user.ClasaId);

			using (MySqlDataReader reader = command.ExecuteReader())
			{



				if (reader.Read())
				{
					for (int i = 0; i < 9; i++)
						ore[i] = reader[i + 1].ToString();


				}
				

			}
			 
			con.CloseCon();



			return "";

		}

		private int GetNextClass()
		{
			for(int i = 0; i < ore.Length; i++)
			{
				//DateTime myDate = DateTime.ParseExact($"{DateTime.Now.ToString("dd MMMM yyyy")} {ore[i]}", "dd MMMM yyyy HH:mm",
				//						   System.Globalization.CultureInfo.InvariantCulture);

				
				DateTime myDate = Convert.ToDateTime($"{DateTime.Now.ToString("dd MMMM yyyy")} {ore[i]}");
				DateTime now = DateTime.Now;
				if (myDate.Subtract(now).TotalHours>0 && (myDate.Subtract(now).TotalHours<1))
				{
					
					return ++i;
				}
			}

			return -1;
			



		}

		private string GetClassLinkFromName(string n)
		{
			con.OpenCon();
			string cmd = "SELECT * FROM materii WHERE clasa_id=@clasa_id AND nume=@name";

			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@clasa_id", user.ClasaId);
			command.Parameters.AddWithValue("@name", n);

			using (MySqlDataReader reader = command.ExecuteReader())
			{



				if (reader.Read())
				{
					return reader["link"].ToString();

				}
				else return "https://classroom.google.com";

			}

			
		}

		private string GetClassLink(int i)
		{
			
			if (i < 0)
				return "https://classroom.google.com";
			con.OpenCon();
			string cmd = "SELECT * FROM orar WHERE clasa_id=@clasa_id AND ziua=@day";

			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@clasa_id", user.ClasaId);
			command.Parameters.AddWithValue("@day", DateTime.Now.ToString("dddd"));
	
			using (MySqlDataReader reader = command.ExecuteReader())
			{



				if (reader.Read())
				{
					string aux = reader[i].ToString();
					con.CloseCon();
					
					return aux;

				}
				else {
					con.CloseCon();
					return "https://classroom.google.com"; }


			}
			


		}

		private void button1_Click(object sender, EventArgs e)
		{
			
		}

		private void panel4_Paint(object sender, PaintEventArgs e)
		{

		}

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			
		}

		private void label21_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(GetClassLinkFromName(GetClassLink(GetNextClass())));
		}

		private void panel1_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(GetClassLinkFromName(GetClassLink(GetNextClass())));
		}
	}
}
