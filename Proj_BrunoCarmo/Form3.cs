using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj_BrunoCarmo
{
    public partial class Form3 : Form
    {
        public MySqlConnection conexao;
        private DataSet ds;
        private DataTable tabela;
        public Form3()
        {
            InitializeComponent();
            conexao = Connection.ObterConexao();
            tabela = new DataTable();
        }


        private void CarregarDados()
        {
            // Verificar se a DataTable já possui dados
            if (tabela.Rows.Count == 0)
            {
                string consulta = "SELECT c.nome AS 'Cliente', l.titulo AS 'Livro', " +
                    " GROUP_CONCAT(a.nome SEPARATOR ', ') AS 'Autores', " +
                    " e.estimativa_entrega AS 'Data_Hora' " +
                    " FROM tb_livros AS l " +
                    " JOIN tb_conter AS co ON l.id_livro = co.id_livro " +
                    " JOIN tb_encomenda AS e ON co.id_encomenda = e.id_encomenda " +
                    " JOIN tb_cliente AS c ON e.id_cliente = c.id_cliente " +
                    " JOIN tb_escrever AS es ON l.id_livro = es.id_livro " +
                    " JOIN tb_autor AS a ON es.id_autor = a.id_autor " +
                    " GROUP BY l.id_livro, e.estimativa_entrega, c.nome;";

                try
                {
                    // Consulta SQL para selecionar todos os dados da tabela
                    var adaptador = new MySqlDataAdapter(consulta, conexao);
                    adaptador.Fill(tabela);

                    // Vincular o DataGridView aos dados do DataTable
                    dataGridView1.DataSource = tabela;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    PreencherComboBoxColunas();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }

        private void PreencherComboBoxColunas()
        {
            comboBox1.Items.Clear();

            // Adicionar os nomes das colunas ao ComboBox
            foreach (DataColumn column in tabela.Columns)
            {
                comboBox1.Items.Add(column.ColumnName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = null;

            //if (!string.IsNullOrEmpty(textIdEncomendas.Text))
            //{

            //    CarregarDados();

            //}
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            PreencherComboBoxColunas();
        }

        private void LimparTextBoxes()
        {
            // Limpa o texto e o que foi selecionado na combo

            textIdEncomendas.Text = "";
            textIdAutor.Text = "";
            textAutor.Text = "";
            comboBox1.SelectedItem = null;
            
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (tabControl1.SelectedTab.Text == "Encomendas")
            {
                LimparTextBoxes();
                dataGridView1.DataSource = null;
                CarregarDados();
            }
            else
            {
                LimparTextBoxes();
                dataGridView1.DataSource = null;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            conexao = Connection.ObterConexao();


            string comando;
            var adaptador = new MySqlDataAdapter();

            ds = new DataSet();

            if (!string.IsNullOrEmpty(textIdAutor.Text))
            {
                comando = "SELECT id_autor, nome, obras_publicadas FROM tb_autor WHERE id_autor=" + textIdAutor.Text;
                adaptador.SelectCommand = new MySqlCommand(comando, conexao);                       //"@idAutor
                adaptador.SelectCommand.Parameters.AddWithValue("@idAutor", textIdAutor.Text);

            }
            else if (!string.IsNullOrEmpty(textAutor.Text))
            {
                comando = "SELECT id_autor, nome, obras_publicadas FROM tb_autor WHERE nome LIKE CONCAT(@letraAutor, '%')";
                adaptador.SelectCommand = new MySqlCommand(comando, conexao);                   // necessario dar concat
                adaptador.SelectCommand.Parameters.AddWithValue("@letraAutor", textAutor.Text);
            }
            else
            {
                comando = "SELECT id_autor, nome, obras_publicadas FROM tb_autor ";
                adaptador.SelectCommand = new MySqlCommand(comando, conexao);
            }
            try
            {

                adaptador.Fill(ds, "Autor");
                dataGridView1.DataSource = ds.Tables["Autor"];
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao buscar os dados: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // paras limpezas profundas da grid 
            dataGridView1.DataSource = null;

            // coluna  no ComboBox
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma coluna para filtrar.");
                return;
            }

            string textoPesquisa = textIdEncomendas.Text.Trim();
            string colunaSelecionada = comboBox1.SelectedItem?.ToString();

            // coluna selecionada é válida
            if (string.IsNullOrEmpty(colunaSelecionada))
            {
                MessageBox.Show("Por favor, selecione uma coluna para filtrar.");
                return;
            }

            //filtro  da DataGridView
            DataView dv = tabela.DefaultView;
            Type tipoDado = tabela.Columns[colunaSelecionada].DataType;

            //filtro

            if (tipoDado == typeof(DateTime))
            {
                // Extrai o ano da data de pesquisa
                int anoPesquisa;
                if (int.TryParse(textoPesquisa, out anoPesquisa))
                {
                   
                    // Constrói a expressão de filtro para buscar pelo ano
                    dv.RowFilter = string.Format("CONVERT({0},'System.String') LIKE '%{1}%'", colunaSelecionada, anoPesquisa);
                }
                else
                {
                    MessageBox.Show("Por favor, insira um ano válido para pesquisar.");
                    return;
                }
            }
            else
            {

                dv.RowFilter = string.Format("{0} LIKE '%{1}%'", colunaSelecionada, textoPesquisa);
            }


            dataGridView1.DataSource = dv.ToTable();

            // Se não houver resultados após o filtro, mostrar uma mensagem
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum resultado encontrado.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // 

        }


        public void SelecionarTab(string nomeTab)
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                if (tabPage.Text == nomeTab)
                {
                    tabControl1.SelectedTab = tabPage;
                    break;

                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void textIdAutor_TextChanged(object sender, EventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        { 
        }
    }
}
