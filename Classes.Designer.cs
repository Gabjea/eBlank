﻿
namespace eBlank
{
	partial class Classes
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel1.Location = new System.Drawing.Point(75, 62);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(301, 207);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel2.Location = new System.Drawing.Point(75, 614);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(301, 207);
			this.panel2.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel3.Location = new System.Drawing.Point(411, 62);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(301, 207);
			this.panel3.TabIndex = 1;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel4.Location = new System.Drawing.Point(754, 62);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(301, 207);
			this.panel4.TabIndex = 2;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::eBlank.Properties.Resources.class_pane11;
			this.pictureBox1.Location = new System.Drawing.Point(75, 275);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(300, 210);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// Classes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1242, 726);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Classes";
			this.Text = "Classes";
			this.Load += new System.EventHandler(this.Classes_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}