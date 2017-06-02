using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Artigos
{
    public partial class listar : Form
    {
        public string idSelecionado;
        public string UsuarioSelecionado = "";
        public bool logado = false;
        private Conexao conn;
        public static SqlConnection ConnectOpen = null;
        
        public listar()
        {
            conn = new Conexao();
            ConnectOpen = conn.ConnectToDatabase();
            InitializeComponent();
        }

        private void listar_Load(object sender, EventArgs e)
        {
            var conn = Login.ConnectOpen;
            string sqlCommand = "Select * from usuarios";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand, conn);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //Recuperar a linha selecionadas.
            UsuarioSelecionado = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           // MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            idSelecionado = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
           // MessageBox.Show(idSelecionado);
            //Fechar a tela
            Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
