using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Proj_BrunoCarmo
{
	public partial class Form2 : Form
	{
		public MySqlConnection conexao;
		public event EventHandler ServidorOnline;


		public Form2()
		{
			InitializeComponent();
		}

		private void OnServidorOnline()
		{
			ServidorOnline?.Invoke(this, EventArgs.Empty);
		}

		private void Form2_Load(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{

			var strconexao = "server="+serv.Text+";uid="+use.Text+";pwd="+passwo.Text+";database="+dB.Text;

			//conexao = new MySqlConnection(strconexao);
			
			try
			{
                //conexao.Open();
                Connection.EstabeleceConexao(strconexao);
                MessageBox.Show("The server is ON");
				statusServer.Text = "ONLINE";
				statusServer.BackColor = Color.Green;
				
				OnServidorOnline();
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocorreu algo inesperado, verifique se inseriu bem os dados - " + ex.Message);
			}
			passwo.Text = string.Empty;
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{

			e.Cancel = true;

			this.Hide();
		}

		private void Form2_FormClosed(object sender, FormClosedEventArgs e)
		{

		}

        private void label5_Click(object sender, EventArgs e)
        {
			
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
