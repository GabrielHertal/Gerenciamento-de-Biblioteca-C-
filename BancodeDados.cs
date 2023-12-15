using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Gerenciamento_de_Biblioteca
{ 
        public class BancodeDados
        {
            //variaveis
            private string str_conexao;

            public FbConnection conexao = new FbConnection();
            public FbCommand comando = new FbCommand();
            public FbDataReader dados;

            public BancodeDados()
            {
                str_conexao = @"User=SYSDBA;Password=masterkey;Database=C:\Users\Gabriel\Desktop\Projetos\Gerenciamento de Biblioteca\bin\Debug\BIBLIOTECA.FDB;DataSource=localhost;Port=3050;";
            }
            //Conectar
            public void Conectar()
            {
                try
                {
                    conexao.ConnectionString = str_conexao;
                    conexao.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //desconectar
            public void Desconectar()
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
            //executar
            public void Executar(string sql)
            {
                try
                {
                    comando.Connection = conexao;
                    comando.CommandText = sql;
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao executar o comando SQL: {ex.Message}", "Erro de Execução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Consulta de dados(select)
            public FbDataReader Consultar(string sql)
            {
                try
                {
                    comando.Connection = conexao;
                    comando.CommandText = sql;
                    dados = comando.ExecuteReader();
                    return dados;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Erro ao consultar o banco de dados: {e.Message}", "Erro de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
           
        }
}

