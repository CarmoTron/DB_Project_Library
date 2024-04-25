using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proj_BrunoCarmo
{
    public partial class Form1 : Form
    {
        public bool servidorOnline = false;

        public MySqlConnection conexao;

        public Form1()
        {
            InitializeComponent();
            AtualizarStatusServidor();

        }

        // Método para atualizar o status do servidor
        private void AtualizarStatusServidor()
        {
            // Exemplo: atualizar uma label com o status do servidor
            if (servidorOnline == false)
            {
                //labelStatusServidor.Text = "OFFLINE";
                // labelStatusServidor.BackColor = Color.Red;
                labelStatusServidor.Visible = true;
                label2.Visible = false; 
                    
            }
            else 
            {
                //labelStatusServidor.Text = "ONLINE";
                // labelStatusServidor.BackColor = Color.Green;
                labelStatusServidor.Visible = false;
                label2.Visible = true;
            }
        }

        private void ligarToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (servidorOnline == true)
            {
                MessageBox.Show("O servidor já está online.");
                return;
            }
            Form2 novo = new Form2();
            novo.ServidorOnline += Form2_ServidorOnline;
            novo.ShowDialog();

        }

        private void Form2_ServidorOnline(object sender, EventArgs e)
        {
            // Atualizar o status do servidor quando o evento ServidorOnline for acionado pelo Form2
            servidorOnline = true;
            
            AtualizarStatusServidor();
        }

        private void quemEComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 novo = new Form4();

            novo.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!VerificaOnline())
            {
                return;
            }
            else { AbrirTab("Encomendas"); }

        }
        private void autoresToolStripMenuItem_Click(object sender, EventArgs e)

        {
            if (!VerificaOnline())
            {
                return;
            }
            else { AbrirTab("Autores"); }

        }
        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

         //
        }

        private  bool VerificaOnline()
        {
            if (servidorOnline == false)
            {
                MessageBox.Show("O servidor está offline. Não é possível realizar consultas neste momento.");
                return false;
            }
            else { 
                return true; 
            }
        }


        private void AbrirTab(string nomeTab)
        {
            Form3 form = new Form3();

            form.SelecionarTab(nomeTab);
            form.Show();
        }

        private void desligarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("Estou aqui no desligar metodo");
            if (servidorOnline == false)
            {
                MessageBox.Show("O servidor já está offline.");
                return;
            }
            try
            {
                conexao = Connection.ObterConexao();
                DialogResult result = MessageBox.Show("Deseja mesmo desligar o Server?", "Desligar o SERVER", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    //para sair
                    return;
                }

                if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
                {
                    // perguntar à stora pergunta isto não entra aqui..


                    MessageBox.Show("Estou aqui no desligar metodo2");

                    servidorOnline = false;
                    Connection.Close();
                    //Connection.Close();
                    //conexao.ConnectionString = null;
                    MessageBox.Show("The server is OFFLINE ");
                    AtualizarStatusServidor();

                    // tive que por um else porque ele nao entrava sequer dentro o if() 
                    // claro que podia por == null mas... imaginando que ele realmente
                    // fica ligado o problema seria o mesmo xD

                }
                //else
                //{
                //    //conexao = Connection.ObterConexao();
                //    MessageBox.Show("Estou aqui no desligar metodo3");
                //   // conexao.Close();
                //    servidorOnline = false;
                //    MessageBox.Show("The server is OFFLINE ");
                //    AtualizarStatusServidor();

                //}
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("The server is already off" + ex);

            }

        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
