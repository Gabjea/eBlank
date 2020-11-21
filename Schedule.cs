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
	public partial class Schedule : Form
	{

		DB con = new DB();
		public User user;

		

		public Schedule(User usr)
		{
			InitializeComponent();
			user = usr;
			Label[] luni = { label17, label18, label19, label20, label21, label22, label23, label24, label25 };
			Label[] marti = { label26, label27, label28, label29, label30, label31, label32, label33, label34 };
			Label[] miercuri = { label35, label36, label37, label38, label39, label40, label41, label42, label43 };
			Label[] joi = { label44, label45, label46, label47, label48, label49, label50, label51, label52 };
			Label[] vineri = { label53, label54, label55, label56, label57, label58, label59, label60, label61};
			Label[] ore = { label7, label8, label9, label10, label11, label12, label14, label15, label16};
			GetOre(ore);
			GetMon("luni", luni);
			//GetMon("marti", marti);
			//GetMon("miercuri", miercuri);
			//GetMon("joi", joi);
			//GetMon("vineri", vineri);
		}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

		private void Schedule_Load(object sender, EventArgs e)
		{
			
		}

		
		private void GetOre(Label[] lb)
		{
			con.OpenCon();
			string cmd = "SELECT * FROM ore_cursuri WHERE clasa_id=@clasa_id AND scoala=@scoala";

			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@clasa_id", user.ClasaId);
			command.Parameters.AddWithValue("@scoala", user.School);
			using (MySqlDataReader reader = command.ExecuteReader())
			{



				if (reader.Read())
				{

					for (int i = 0; i < 9; i++)
						lb[i].Text = reader[i + 1].ToString();
				}

			}

			con.CloseCon();
		}

		private void GetMon(string zi, Label[] lb)
		{
			con.OpenCon();
			string cmd = "SELECT * FROM orar WHERE clasa_id=@clasa_id AND ziua=@zi AND scoala=@scoala";

			MySqlCommand command = new MySqlCommand(cmd, con.getCon());

			command.Parameters.AddWithValue("@clasa_id", user.ClasaId) ;
			command.Parameters.AddWithValue("@zi", zi) ;
			command.Parameters.AddWithValue("@scoala", user.School) ;
			using (MySqlDataReader reader = command.ExecuteReader())
			{

				
				
				if (reader.Read())
				{

					for (int i = 0; i < 9;i++)
						lb[i].Text = reader[i + 1].ToString();
				}

			}

			con.CloseCon();
		}


		private void label7_Click(object sender, EventArgs e)
		{

		}

		private void label40_Click(object sender, EventArgs e)
		{

		}

		private void label43_Click(object sender, EventArgs e)
		{


		}

		private void label48_Click(object sender, EventArgs e)
		{

		}
	}
}
