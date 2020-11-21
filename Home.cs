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


		public Home()
		{
			InitializeComponent();
			timer1.Start();
			//CenterControl(label1);
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


	}
}
