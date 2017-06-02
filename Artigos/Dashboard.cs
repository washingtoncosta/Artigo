using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Artigos
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
           var frmLogin = new Login();
            frmLogin.ShowDialog();

          if (frmLogin.logado == false)
                Close();
            verificarAcesso();
        }

        private void verificarAcesso()
        {
            if (Login.perfilUsuario == 3)
            {
                btnCadastrar.Enabled= true;
                button1.Enabled = true;
            }
            if (Login.perfilUsuario == 2)
            {
                button1.Enabled = true;
            }

            if (Login.perfilUsuario == 1)
            {
                button3.Enabled = true;
            }

        }

           private void button1_Click(object sender, EventArgs e)
        {
            var Cadastrar = new Cadastrar();
            if (Login.perfilUsuario == 3)
                Cadastrar.bamtu();
            Cadastrar.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frmLogin = new Login();
            frmLogin.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Login.perfilUsuario == 1)
            {
                button3.Enabled = true;
            }

            Artigos calzone = new Artigos();
            calzone.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Painel_de_revisor calzone = new Painel_de_revisor();
            calzone.Show();
        }
    }
}
