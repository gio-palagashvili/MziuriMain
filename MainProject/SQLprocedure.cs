using System;
using System.Data;
using System.Data.SqlClient;

namespace MainProject
{
    public class SQLprocedure
    {
        private static readonly string Connstr = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStr"].ToString();
        private static readonly SqlConnection Conn = new SqlConnection(Connstr);
        private static SqlCommand _cmd;
        private static SqlDataAdapter _dataAdapter;

        public static void InsertUser(User user)
        {
            _cmd = new SqlCommand("InsertUser", Conn) { CommandType = CommandType.StoredProcedure };
            var paramss = new SqlParameter[7];
            paramss[0] = new SqlParameter("@name", SqlDbType.VarChar, 50) {Value = user.Name};
            paramss[1] = new SqlParameter("@password", SqlDbType.VarChar, 50) {Value = user.password};
            paramss[2] = new SqlParameter("@lastname", SqlDbType.VarChar, 50) {Value = user.Lastname};
            paramss[3] = new SqlParameter("@phone_number", SqlDbType.VarChar, 50) {Value = user.PhoneNumber};            
            paramss[4] = new SqlParameter("@creation_date", SqlDbType.VarChar, 50) {Value = DateTime.Now};           
            paramss[5] = new SqlParameter("@mail", SqlDbType.VarChar, 50) {Value = user.Mail};
            paramss[6] = new SqlParameter("@role", SqlDbType.VarChar, 50) {Value = "default"};

            _cmd.Parameters.AddRange(paramss);
            Conn.Open();
            _cmd.ExecuteNonQuery();
            Conn.Close();
        }

        public static DataTable SelectUserByMail(string mail)
        {
            _cmd = new SqlCommand("SelectUserByMail", Conn) { CommandType = CommandType.StoredProcedure };
            var mailParameter = new SqlParameter("@mail", SqlDbType.VarChar) {Value = mail};
            _cmd.Parameters.Add(mailParameter);
            
            _dataAdapter = new SqlDataAdapter(_cmd);
            var table = new DataTable();
            _dataAdapter.Fill(table);
            
            return table;
        }
    }
}