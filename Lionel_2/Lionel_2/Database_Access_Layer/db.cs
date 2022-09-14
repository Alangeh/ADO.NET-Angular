using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Lionel_2.Models;

namespace Lionel_2.Database_Access_Layer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public int User_Login(string userid, string password)
        {
            int res = 0;
            SqlCommand command = new SqlCommand("Sp_Login", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@userId", userid);
            command.Parameters.AddWithValue("@password", password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            command.Parameters.Add(oblogin);
            con.Open();
            command.ExecuteNonQuery();
            res = Convert.ToInt32(oblogin.Value);
            return res;
            //con.Close();
        }
    }
}