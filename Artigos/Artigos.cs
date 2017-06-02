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
    public partial class Artigos : Form
    {
        public Artigos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Criar_Artigos calzone = new Criar_Artigos();
            calzone.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listar_Artigos calzone = new Listar_Artigos();
            calzone.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Revisar_Artigo calzone = new Revisar_Artigo();
            calzone.Show();
        }
    }
}
