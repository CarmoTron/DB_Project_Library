using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj_BrunoCarmo
{

	internal class Connection
	{
		private static MySqlConnection conexao;

		public static MySqlConnection ObterConexao()
		{
			if (conexao == null)
			{
				MessageBox.Show("The server is OFFLINE ");
			}
			//else
			//{
			//	MessageBox.Show("A desligar");
			//}

			return conexao;
		}

		public static void EstabeleceConexao(string strConexao)
		{
			
	
				conexao = new MySqlConnection(strConexao);
				try
				{
					conexao.Open();
					MessageBox.Show("Its ON");
				}
				catch
				{
					MessageBox.Show("Ocorreu um erro ao conectar ao server");
				}
			
		}

		public static void Close() 
		{
			conexao.Close();
		}
	}
}
