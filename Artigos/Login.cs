﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Artigos
{
    public partial class Login : Form
    {
        public bool logado = false;
        private Conexao conn;
        public static SqlConnection ConnectOpen = null;
        public static int perfilUsuario;
        public Login()
        {
            conn = new Conexao();
            ConnectOpen = conn.ConnectToDatabase();
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string strCommand = "Select * from usuarios where usuario = '" + txtUsuario.Text + "' and " + "Senha = '" + txtSenha.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(strCommand,ConnectOpen);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                this.Hide();
                logado = true;

                perfilUsuario = Convert.ToInt16(dt.Rows[0][2]);

                //MessageBox.Show("Usuario Logado com sucesso!");
            }
            else
                MessageBox.Show("Usuário ou senha incorreto(s)!");

        }

        private void Focus(object sender, EventArgs e)
        {
            var btn = (TextBox)sender;
            btn.Text = string.Empty;
            btn.ForeColor = Color.Black;
        }
        private void Login_Load(object sender, EventArgs e)
        {
            txtUsuario.GotFocus += Focus;
            txtSenha.GotFocus += Focus;

        }

  
        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            var cadastrar = new Cadastrar();
            cadastrar.perfilUsuario = 1;
            cadastrar.ShowDialog();

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
