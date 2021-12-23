using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MainProject
{
    public class SQLprocedure
    {
        private static readonly string Connstr = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStr"].ToString();
        private static readonly SqlConnection Conn = new SqlConnection(Connstr);
        private static SqlCommand _cmd;
        private static SqlDataAdapter _dataAdapter;

        private static string ToMd5(string input)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (var b in hashBytes)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
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
            var mailParameter = new SqlParameter("@mail", SqlDbType.VarChar) {Value = mail.ToLower()};
            _cmd.Parameters.Add(mailParameter);
            
            _dataAdapter = new SqlDataAdapter(_cmd);
            var table = new DataTable();
            _dataAdapter.Fill(table);
            
            return table;
        }
        public static bool LogIn(string mail, string password)
        {
            _cmd = new SqlCommand("LogIn", Conn) { CommandType = CommandType.StoredProcedure };
            var paramss = new SqlParameter[2];
            paramss[0] = new SqlParameter("@mail", SqlDbType.VarChar, 50) {Value = mail.ToLower()};
            paramss[1] = new SqlParameter("@password", SqlDbType.VarChar, 50) {Value = ToMd5(password)};
            _cmd.Parameters.AddRange(paramss);
            
            _dataAdapter = new SqlDataAdapter(_cmd);
            var table = new DataTable();
            _dataAdapter.Fill(table);
            
            return table.Rows.Count > 0;
        }
    }
}