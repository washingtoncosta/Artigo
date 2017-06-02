using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artigos
{
    public class Conexao
    {
        SqlConnection conn = null;

        public SqlConnection ConnectToDatabase()
        {
            try
            {
                //Criar uma nova instancia
                conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\executaveis liberados\ArtigosW\Artigos\database.mdf;Integrated Security=True;Connect Timeout=30";
                conn.Open();
                return conn;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
