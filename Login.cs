using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eBlank
{
    public partial class Login : Form
    {

        DB con = new DB();
        Thread thread;
        public User usr = new User();
        string invalid_email = "You have entered an invalid e-mail"+ Environment.NewLine+" adress. Please try again.";
        public Login()
        {
            InitializeComponent();
            textBox1.PasswordChar = '\u2022';
            
        }



        private void OpenForm(object obj)
        {
            
            Application.Run(new Main(usr));
        }



        

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);


        }

		private void button2_Click(object sender, EventArgs e)
		{
            Application.Exit();

		}

		private void Login_Load(object sender, EventArgs e)
		{
            this.ActiveControl = pictureBox6;
        }

		private void Email_Enter(object sender, EventArgs e)
		{
            if(Email.Text.Equals("E-mail"))
                Email.Text = "";
		}

		private void Email_Leave(object sender, EventArgs e)
		{
            if(Email.Text.Length==0)
                Email.Text = "E-mail";
		}

		private void textBox1_Enter(object sender, EventArgs e)
		{
            if (textBox1.Text.Equals("Password"))
                textBox1.Text = "";
        }

		private void textBox1_Leave(object sender, EventArgs e)
		{
            if (textBox1.Text.Length == 0)
                textBox1.Text = "Password";
        }


        private void Error(string m, System.Drawing.Color c)
		{
            label2.ForeColor = c;
            label2.Text = m;
		}

        private void login()
		{
			if (!Email.Text.Contains("@"))
			{
                Error(invalid_email, System.Drawing.Color.Red);
                return;
			}
            string com = "SELECT * FROM accounts WHERE email=@email ";
            string[] param = { "@email" };
            string[] vals = { Email.Text };
            if (textBox1.Text.Equals(con.ReadData(com, param, vals, "password")))
            {
                usr.Email = textBox1.Text;
                usr.Function = con.ReadData(com, param, vals, "function");
                usr.Name = con.ReadData(com, param, vals, "username");
                usr.School = con.ReadData(com, param, vals, "school");
                usr.Id = con.ReadData(com, param, vals, "id");
                usr.ClasaId = con.ReadData(com, param, vals, "clasa_id");
                thread = new Thread(OpenForm);
                thread.SetApartmentState(ApartmentState.STA);

                thread.Start();
                this.Close();
			}
			else
			{
                Error("Wrong credentials",System.Drawing.Color.Red);
			}
        }


		private void login_button_Click(object sender, EventArgs e)
		{
            login();
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
            login();
		}
	}
}
