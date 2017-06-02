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
    public partial class Cadastrar : Form
    {
        public int idSelecionado;
        public bool logado = false;
        private Conexao conn;
        private SqlConnection ConnectOpen;
        public int perfilUsuario; 

            public Cadastrar()
        {
            InitializeComponent();
            conn = new Conexao();
            ConnectOpen = conn.ConnectToDatabase();
        }
        public void bamtu()
        {
            this.lblPerfil.Visible = true;
            this.cmbPerfil.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Alterar")
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("update Usuarios set Usuario = @usuario, Senha = @senha, Perfil = @perfil where id = "+idSelecionado);
                
                SqlCommand command = null;

                try
                {
                    if (cmbPerfil.Visible)

                        switch (cmbPerfil.Text)
                        {
                            case "Autores":
                                perfilUsuario = 1;
                                break;
                            case "Revisores":
                                perfilUsuario = 2;
                                break;
                            case "Gerente":
                                perfilUsuario = 3;
                                break;
                        }

                    command = new SqlCommand(sql.ToString(), ConnectOpen);
                    command.Parameters.Add(new SqlParameter("@usuario", txtUsuario.Text));
                    command.Parameters.Add(new SqlParameter("@senha", txtSenha.Text));
                    command.Parameters.Add(new SqlParameter("@perfil", perfilUsuario));
                    command.ExecuteNonQuery();

                    if (cmbPerfil.Visible)

                        switch (cmbPerfil.Text)
                        {
                            case "Autores":
                                perfilUsuario = 1;
                                break;
                            case "Revisores":
                                perfilUsuario = 2;
                                break;
                            case "Gerente":
                                perfilUsuario = 3;
                                break;
                        }

                    MessageBox.Show("Alterado com sucesso");
                    Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar");
                    throw;
                }
            }
        
            else
            {

                StringBuilder sql = new StringBuilder();
                sql.Append("Insert into usuarios(Usuario, senha, perfil) ");
                sql.Append("Values (@usuario, @senha, @perfil)");
                SqlCommand command = null;

                try
                {
                    if (cmbPerfil.Visible)

                        switch (cmbPerfil.Text)
                        {
                            case "Autores":
                                perfilUsuario = 1;
                                break;
                            case "Revisores":
                                perfilUsuario = 2;
                                break;
                            case "Gerente":
                                perfilUsuario = 3;
                                break;
                        }

                    command = new SqlCommand(sql.ToString(), ConnectOpen);
                    command.Parameters.Add(new SqlParameter("@usuario", txtUsuario.Text));
                    command.Parameters.Add(new SqlParameter("@senha", txtSenha.Text));
                    command.Parameters.Add(new SqlParameter("@perfil", perfilUsuario));
                    command.ExecuteNonQuery();

                    if (cmbPerfil.Visible)

                        switch (cmbPerfil.Text)
                        {
                            case "Autores":
                                perfilUsuario = 1;
                                break;
                            case "Revisores":
                                perfilUsuario = 2;
                                break;
                            case "Gerente":
                                perfilUsuario = 3;
                                break;
                        }

                    MessageBox.Show("Cadastro com sucesso");
                    Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar");
                    throw;
                }
            }
        }

        private void LimparTela()
        {
            button1.Text = "Cadastrar";
            Excluir.Visible = false;
            txtSenha.Text = "";
            txtUsuario.Text = "";
            cmbPerfil.Text = "Selecione o perfil"; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPerfil.Text == "Gerente")

            {
                Listar.Visible = true;
            }

            else
            {
                Listar.Visible = false;
            }
            {
                Excluir.Visible = false;
            }
            }

        private void Listar_Click(object sender, EventArgs e)
        {
            var listar = new listar();

            listar.ShowDialog();

            //Verificar se foi selecionado algum item.
            if (listar.UsuarioSelecionado == "")
                return;

            var conn = Login.ConnectOpen;
            //Buscar usuario selecionado
            string sql = "Select * from usuarios where Usuario = '" + listar.UsuarioSelecionado + "'";


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);

            //linda 0, coluna 0
            txtUsuario.Text = dt.Rows[0][0].ToString();

            //Linha 0, coluna 1
            txtSenha.Text = dt.Rows[0][1].ToString();

            idSelecionado = Convert.ToInt16(listar.idSelecionado);

            string PerfilSelecionado;

            switch (dt.Rows[0][2].ToString())
            {
                case "1":
                    PerfilSelecionado = "Autores";
                    break;
                case "2":
                    PerfilSelecionado = "Revisores";
                    break;
                case "3":
                    PerfilSelecionado = "Gerente";
                    break;
                default:
                    PerfilSelecionado = "Autores";
                    break;
            }

            cmbPerfil.Text = PerfilSelecionado;

            //Trocar o text do cadastrar para alterar
            button1.Text = "Alterar";

            //Alterar a visualização do excluir
            Excluir.Visible = true;
        }

            

        private void Cadastrar_Load(object sender, EventArgs e)
        {
            if (Login.perfilUsuario == 3)
            {
                lblPerfil.Visible = true;
                cmbPerfil.Visible = true;
                Listar.Visible = true;
            }
        }

        private void Excluir_Click(object sender, EventArgs e)
        {
            var conn = Login.ConnectOpen;

            //Confirmar exclusão
            DialogResult result = MessageBox.Show("Deseja realmente excluir?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            //Caso o usuário dê ok, a exclusão prossegue
            if (!result.Equals(DialogResult.OK))
                return; // Caso cancele, o código abaxi nao sera executado.

            //Buscar usuário seleciado
            string sql = "Delete from usuarios where id = @id";

            SqlCommand command = null;
            command = new SqlCommand(sql.ToString(), ConnectOpen);
            command.Parameters.Add(new SqlParameter("@id", idSelecionado));
            command.ExecuteNonQuery();
            LimparTela();
            MessageBox.Show("Excluído com sucesso!");
        }
    }
    }

