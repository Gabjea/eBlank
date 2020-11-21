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
			//CenterControl(label1);
		}

		private void GetNextClass()
		{
			DateTime myDate = DateTime.ParseExact(DateTime.Now.ToString("dd MMMM yyyy").ToString(), "yyyy-MM-dd HH:mm:ss,fff",
									   System.Globalization.CultureInfo.InvariantCulture);

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

		private string GetClassLink()
		{

			con.OpenCon();
			string cmd = "SELECT * FROM materii WHERE clasa_id=@clasa_id";

			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@clasa_id", user.ClasaId);
	
			using (MySqlDataReader reader = command.ExecuteReader())
			{



				if (reader.Read())
				{
					con.CloseCon();
					return reader[nextclass].ToString();


				}
				else return "";

			}



		}

		private void button1_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(GetClassLink());
		}
	}
}
