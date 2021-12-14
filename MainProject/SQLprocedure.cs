using System;
using System.Data;
using System.Data.SqlClient;

namespace MainProject
{
    public class SQLprocedure
    {
        private static readonly string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStr"].ToString();
        private static SqlConnection conn = new SqlConnection(connstr);
        private static SqlCommand Cmd;
        public static SqlDataAdapter DataAdapter;

        public void InsertUser(string name, string password, string lastName, string phoneNumber,string mail, string role)
        {
            Cmd = new SqlCommand("InsertUser", conn) { CommandType = CommandType.StoredProcedure };
            var paramss = new SqlParameter[7];
            paramss[0] = new SqlParameter("@name", SqlDbType.Int) {Value = name};
            paramss[1] = new SqlParameter("@password", SqlDbType.VarChar, 50) {Value = password};
            paramss[2] = new SqlParameter("@lastname", SqlDbType.VarChar, 50) {Value = lastName};
            paramss[3] = new SqlParameter("@phone_number", SqlDbType.VarChar, 50) {Value = phoneNumber};            
            paramss[4] = new SqlParameter("@creation_date", SqlDbType.VarChar, 50) {Value = DateTime.Now};           
            paramss[5] = new SqlParameter("@mail", SqlDbType.VarChar, 50) {Value = mail};
            paramss[6] = new SqlParameter("@role", SqlDbType.VarChar, 50) {Value = "default"};

            Cmd.Parameters.AddRange(paramss);
            conn.Open();
            Cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}