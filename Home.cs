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
			LoadTodo();
			LoadTests();
			
		}

		private void LoadTodo()
		{
			con.OpenCon();
			string cmd = "SELECT * FROM todo WHERE user_id=@clasa_id";

			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@clasa_id", user.ClasaId);

			using (MySqlDataReader reader = command.ExecuteReader())
			{



				while (reader.Read())
				{

					


				}
				

			}
			con.CloseCon();
		}
		private void LoadTests()
		{

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
					return i;
				}
			}

			return -1;
			



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

		private string GetClassLink(int i)
		{
			

			con.OpenCon();
			string cmd = "SELECT * FROM materii WHERE clasa_id=@clasa_id";

			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@clasa_id", user.ClasaId);
	
			using (MySqlDataReader reader = command.ExecuteReader())
			{



				if (reader.Read())
				{
					
					return reader[i+1].ToString();


				}
				else return "";

			}
			con.CloseCon();


		}

		private void button1_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(GetClassLink(GetNextClass()));
		}

		private void panel4_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
