using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace eBlank
{
	public partial class Main : Form
	{
		public User user;

		private Button curentbtn;
		private Panel leftborder;

		public Main(User usr)
		{

			InitializeComponent();
			this.MaximumSize = new Size(1300, 750);
			this.MinimumSize = new Size(1300, 750);
			user = usr;
			button5.Text = user.Name;
			leftborder = new Panel();
			leftborder.Size = new Size(7, 60);
			panel2.Controls.Add(leftborder);
		}
		
		private struct RGBColors
		{
			public static Color color1 = Color.FromArgb(172, 126, 241);
			public static Color color2 = Color.FromArgb(249, 118, 176);
			public static Color color3 = Color.FromArgb(253,138,114);
			public static Color color4 = Color.FromArgb(95, 77, 221);
			public static Color color5 = Color.FromArgb(24,161,251);
		}

		private void ActiveButton(object senderBtn, Color color)
		{
			if(senderBtn != null)
			{
				DisableButton();
				curentbtn = (Button)senderBtn;
				curentbtn.BackColor = Color.FromArgb(37, 36, 81);
				curentbtn.ForeColor = color;
				curentbtn.TextAlign = ContentAlignment.MiddleCenter;
			}

		}

		private void DisableButton()
		{
			if(curentbtn!= null)
			{
				curentbtn.BackColor = Color.FromArgb(31, 30, 68);
				curentbtn.ForeColor = Color.Gainsboro;
				curentbtn.TextAlign = ContentAlignment.MiddleCenter;
			}
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

		private void button1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		

		private void button2_Click(object sender, EventArgs e)
		{
			switch (this.WindowState.ToString())
			{
				case "Normal":
					this.WindowState = FormWindowState.Maximized;
					break;
				case "Minimized":
					this.WindowState = FormWindowState.Maximized;
					break;
				case "Maximized":
					this.WindowState = FormWindowState.Normal;
					break;

			}
		}


		private void button3_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ActiveButton(sender,RGBColors.color1);
			FormOpen(new Home());


		}

		private void FormOpen(Form a)
		{
			a.Dock = DockStyle.Fill;
			a.TopLevel = false;
			a.TopMost = true;
			this.panel3.Controls.Add(a);
			a.Show();
		}

		private void panel4_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(this.Handle, 0x112, 0xf012, 0);

		}

		

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(this.Handle, 0x112, 0xf012, 0);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			ActiveButton(sender, RGBColors.color2);
			FormOpen(new Classes());
		}

		private void button7_Click(object sender, EventArgs e)
		{
			ActiveButton(sender, RGBColors.color3);
			FormOpen(new Schedule());
		}

		private void button8_Click(object sender, EventArgs e)
		{
			ActiveButton(sender, RGBColors.color4);
			FormOpen(new Todo());
		}

		private void button5_Click(object sender, EventArgs e)
		{
			ActiveButton(sender, RGBColors.color5);
			FormOpen(new Catalogue());
		}
	}
	
}
