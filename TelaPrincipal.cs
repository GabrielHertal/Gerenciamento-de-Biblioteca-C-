using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciamento_de_Biblioteca
{
    public partial class Form_Telaprincipal : Form
    {
        public Form_Telaprincipal()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_alunos_Click(object sender, EventArgs e)
        {
            Form_Alunos formalunos = new Form_Alunos();
                formalunos.TopLevel = false;
                formalunos.FormBorderStyle = FormBorderStyle.None;
                formalunos.Dock = DockStyle.Fill;
            
                formalunos.Show();
                panel1.Controls.Add(formalunos);
                formalunos.Show();
        }
    }
}
