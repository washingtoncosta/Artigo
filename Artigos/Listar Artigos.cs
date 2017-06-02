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
    public partial class Listar_Artigos : Form
    {
        public Listar_Artigos()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Confirmar exclusão
            DialogResult result = MessageBox.Show("Deseja realmente excluir?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.Cancel) return;
            MessageBox.Show("Excluído com sucesso!");

           
        }
    }
}
