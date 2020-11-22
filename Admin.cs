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
	public partial class Admin : Form
	{
		DB con = new DB();
		User user;
		public Admin(User usr)
		{
			InitializeComponent();
			user = usr;
		}

		private string GetClasaId(string a)
		{
			string com = "SELECT * FROM classes WHERE name=@name ";
			string[] param = { "@name" };
			string[] vals = { a };
			return con.ReadData(com, param, vals,"id");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string cmd = "INSERT INTO accounts (username,email,password,school,function,clasa_id) VALUES (@user,@email,@pass,@school,@function,@clasa_id)";
			string[] param = { "@user","@email","@pass","@school","@function","@clasa_id"};
			string[] vals = {textBox1.Text,textBox2.Text,textBox3.Text,user.School,textBox5.Text,GetClasaId(textBox6.Text) };
			con.InsertData(cmd, param, vals);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string cmd = "INSERT INTO classes (name,school) VALUES (@user,@school)";
			string[] param = { "@user","@school"};
			string[] vals = { textBox4.Text, user.School };
			con.InsertData(cmd, param, vals);
		}
	}
}
