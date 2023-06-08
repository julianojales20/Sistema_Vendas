using Sistema_Vendas.BLLClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Vendas.DALdados
{
    class LoginDal
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public bool loginCheck(LoginBll l)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(myconnstring))
                {
                    string sql = "SELECT * FROM tbl_users WHERE CONVERT(nvarchar(max), username) = @username AND CONVERT(nvarchar(max), password) = @password AND CONVERT(nvarchar(max), user_type) = @user_type";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", l.username);
                    cmd.Parameters.AddWithValue("@password", l.password);
                    cmd.Parameters.AddWithValue("@user_type", l.user_type);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    isSuccess = (dt.Rows.Count > 0);
                }
            }
            catch (Exception ex)
            {
                // Lide com a exceção adequadamente, como registrar ou tratá-la de outra forma
                MessageBox.Show("Ocorreu um erro ao verificar o login: " + ex.Message);
            }

            return isSuccess;
        }


    }
}
