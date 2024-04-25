namespace Proj_BrunoCarmo
{
	partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serv = new System.Windows.Forms.TextBox();
            this.use = new System.Windows.Forms.TextBox();
            this.passwo = new System.Windows.Forms.TextBox();
            this.dB = new System.Windows.Forms.TextBox();
            this.statusServer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Senha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 193);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Banco de Dados";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // serv
            // 
            this.serv.Location = new System.Drawing.Point(180, 71);
            this.serv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.serv.Name = "serv";
            this.serv.Size = new System.Drawing.Size(196, 22);
            this.serv.TabIndex = 4;
            // 
            // use
            // 
            this.use.Location = new System.Drawing.Point(180, 113);
            this.use.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.use.Name = "use";
            this.use.Size = new System.Drawing.Size(196, 22);
            this.use.TabIndex = 5;
            // 
            // passwo
            // 
            this.passwo.Location = new System.Drawing.Point(180, 153);
            this.passwo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwo.Name = "passwo";
            this.passwo.Size = new System.Drawing.Size(196, 22);
            this.passwo.TabIndex = 6;
            this.passwo.UseSystemPasswordChar = true;
            // 
            // dB
            // 
            this.dB.Location = new System.Drawing.Point(180, 191);
            this.dB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dB.Name = "dB";
            this.dB.Size = new System.Drawing.Size(196, 22);
            this.dB.TabIndex = 7;
            // 
            // statusServer
            // 
            this.statusServer.BackColor = System.Drawing.Color.Red;
            this.statusServer.Font = new System.Drawing.Font("Castellar", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusServer.Location = new System.Drawing.Point(158, 247);
            this.statusServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusServer.Name = "statusServer";
            this.statusServer.Size = new System.Drawing.Size(87, 26);
            this.statusServer.TabIndex = 9;
            this.statusServer.Text = "OFFLINE";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 241);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ligar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Proj_BrunoCarmo.Properties.Resources.l2;
            this.pictureBox1.Location = new System.Drawing.Point(128, -10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 73);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Image = global::Proj_BrunoCarmo.Properties.Resources._9111025_circle_x_icon1;
            this.button2.Location = new System.Drawing.Point(404, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 33);
            this.button2.TabIndex = 10;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(449, 298);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.statusServer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dB);
            this.Controls.Add(this.passwo);
            this.Controls.Add(this.use);
            this.Controls.Add(this.serv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Kristen ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox serv;
		private System.Windows.Forms.TextBox use;
		private System.Windows.Forms.TextBox passwo;
		private System.Windows.Forms.TextBox dB;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label statusServer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}