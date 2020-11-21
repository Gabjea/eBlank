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
		public Main(User usr)
		{

			InitializeComponent();
			this.MaximumSize = new Size(1300, 750);
			this.MinimumSize = new Size(1300, 750);
			user = usr;
			button5.Text = user.Name;
			
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
			Home h = new Home() {Dock= DockStyle.Fill,TopLevel= false, TopMost= true };
			this.panel3.Controls.Add(h);
			h.Show();
		}

		private void panel4_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(this.Handle, 0x112, 0xf012, 0);

		}

		private void button5_Click(object sender, EventArgs e)
		{

		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		

		
	}
	
}
