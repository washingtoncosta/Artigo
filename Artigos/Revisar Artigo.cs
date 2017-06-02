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
    public partial class Revisar_Artigo : Form
    {
        public Revisar_Artigo()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Confirmar Revisão
            DialogResult result = MessageBox.Show("Deseja realmente enviar o artigo para revisão?", "Revisão", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.Cancel) return;
            MessageBox.Show("Artigo revisado com sucesso!");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //Confirmar Publicação
            DialogResult result = MessageBox.Show("Deseja realmente publicar o artigo?", "Publicar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.Cancel) return;
            
            MessageBox.Show("Artigo publicado com sucesso!");
        }
    }
}
