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
    public partial class Painel_de_revisor : Form
    {
        public Painel_de_revisor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Revisão_de_artigos calzone = new Revisão_de_artigos();
            calzone.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Outros_Artigos calzone = new Outros_Artigos();
            calzone.Show();
         }
    }
}
