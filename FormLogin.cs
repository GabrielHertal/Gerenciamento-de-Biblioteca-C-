using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciamento_de_Biblioteca
{
    public partial class FormLogin : Form
    {
        public int idusuarioconectado = 0;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            BancodeDados bancodedados = new BancodeDados();
            string usuario = txt_usuario.Text;
            string senha = txt_senha.Text;

            if (usuario == "" || senha == "")
            {
                MessageBox.Show("Existem campos vazios, verifique!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bancodedados.Conectar();
            string sql = $"SELECT id_usuario FROM usuarios WHERE usuario = '{usuario}' AND senha = '{senha}'";
            bancodedados.Consultar(sql);
            if (bancodedados.dados != null && bancodedados.dados.Read())
            {
                idusuarioconectado = (int)bancodedados.dados["id_usuario"];
                MessageBox.Show("Usuário conectado com sucesso!", "Login efetuado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form_Telaprincipal telaprincipal = new Form_Telaprincipal();
                telaprincipal.Show();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos, verifique!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
