using System;
using System.Collections.Generic;
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
            _cmd = new SqlCommand("CreateUser", Conn) { CommandType = CommandType.StoredProcedure };
            var paramss = new SqlParameter[6];
            paramss[0] = new SqlParameter("@Name", SqlDbType.VarChar, 50) {Value = user.Name.Trim()};
            paramss[2] = new SqlParameter("@Password", SqlDbType.VarChar, 50) {Value = ToMd5(user.Password.Trim())};
            paramss[1] = new SqlParameter("@Lastname", SqlDbType.VarChar, 50) {Value = user.Lastname.Trim()};
            paramss[3] = new SqlParameter("@Phone", SqlDbType.VarChar, 50) {Value = user.PhoneNumber.Trim()};            
            paramss[4] = new SqlParameter("@Time", SqlDbType.VarChar, 50) {Value = DateTime.UtcNow};           
            paramss[5] = new SqlParameter("@mail", SqlDbType.VarChar, 50) {Value = user.Mail.Trim()};

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
            SqlDataAdapter da = new SqlDataAdapter(_cmd);
            var paramss = new SqlParameter[2];
            paramss[0] = new SqlParameter("@mail", SqlDbType.VarChar, 50) {Value = mail.ToLower()};
            paramss[1] = new SqlParameter("@password", SqlDbType.VarChar, 50) {Value = ToMd5(password)};
            _cmd.Parameters.AddRange(paramss);

            Conn.Open();
            var result = _cmd.ExecuteScalar();
            Conn.Close();
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static List<Item> SelectUserItems(int id)
        {
            List<Item> items = new List<Item>();
            SqlCommand cmd = new SqlCommand("SelectUserItems", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter parameter = new SqlParameter("@User_Id", SqlDbType.Int);
            parameter.Value = id;
            cmd.Parameters.Add(parameter);
            Conn.Open();
            var result = cmd.ExecuteReader();
            while (result.Read())
            {
                items.Add(new Item((IDataRecord)result));
            }
            result.Close();
            Conn.Close();
            return items;
        }

        public static List<Item> SelectAllItem(int id)
        {
            List<Item> items = new List<Item>();
            SqlCommand cmd = new SqlCommand("SelectAllItem", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter parameter = new SqlParameter("@User_Id", SqlDbType.Int);
            parameter.Value = id;
            cmd.Parameters.Add(parameter);
            Conn.Open();
            var result = cmd.ExecuteReader();
            while (result.Read())
            {
                items.Add(new Item((IDataRecord)result));
            }
            result.Close();
            Conn.Close();
            return items;
        }

        public static User GetUser(string mail)
        {
            SqlCommand cmd = new SqlCommand("SelectUserByMail", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter parameter = new SqlParameter("@Mail", SqlDbType.VarChar, 50);
            parameter.Value = mail;
            cmd.Parameters.Add(parameter);
            Conn.Open();
            var result = cmd.ExecuteReader();
            User target = null;
            while (result.Read())
            {
                target = new User((IDataRecord)result);
            }
            result.Close();
            Conn.Close();
            if (target != null)
            {
                target.GetItems();
            }
            return target;
        }
        public static User GetUser(int id)
        {
            SqlCommand cmd = new SqlCommand("SelectUserById", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter parameter = new SqlParameter("@User_Id", SqlDbType.Int);
            parameter.Value = id;
            cmd.Parameters.Add(parameter);
            Conn.Open();
            var result = cmd.ExecuteReader();
            User target = null;
            while (result.Read())
            {
                target = new User((IDataRecord)result);
            }
            result.Close();
            Conn.Close();
            return target;
        }

        public static GlobalSettings GetSettings(int id)
        {
            SqlCommand cmd = new SqlCommand("SelectSettings", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter parameter = new SqlParameter("@User_Id", SqlDbType.Int);
            parameter.Value = id;
            cmd.Parameters.Add(parameter);
            Conn.Open();
            var result = cmd.ExecuteReader();
            GlobalSettings target = null;
            while (result.Read())
            {
                target = new GlobalSettings((IDataRecord)result);
            }
            result.Close();
            Conn.Close();
            return target;
        }

        public static bool AreFriends(int firstId, int secondId)
        {
            SqlCommand cmd = new SqlCommand("FriendshipCheck", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@First_Id", SqlDbType.Int);
            parameters[0].Value = firstId;
            parameters[1] = new SqlParameter("@Second_Id", SqlDbType.Int);
            parameters[1].Value = secondId;
            cmd.Parameters.AddRange(parameters);
            Conn.Open();
            var result = cmd.ExecuteScalar();
            Conn.Close();
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Item GetItemById(int id)
        {
            SqlCommand cmd = new SqlCommand("SelectItemById", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter parameter = new SqlParameter("@Item_Id", SqlDbType.Int);
            parameter.Value = id;
            cmd.Parameters.Add(parameter);
            Conn.Open();
            var result = cmd.ExecuteReader();
            Item target = null;
            while (result.Read())
            {
                target = new Item((IDataRecord)result);
            }
            result.Close();
            Conn.Close();
            return target;
        }

        public static void ChangeItemQuantity(int id, int amount)
        {
            SqlCommand cmd = new SqlCommand("ChangeItemQuantity", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Item_Id", SqlDbType.Int);
            parameters[0].Value = id;
            parameters[1] = new SqlParameter("@Amount", SqlDbType.Int);
            parameters[1].Value = amount;
            cmd.Parameters.AddRange(parameters);

            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();
        }

        public static void ChangeBalance(int id, double amount)
        {
            SqlCommand cmd = new SqlCommand("ChangeBalance", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@User_Id", SqlDbType.Int);
            parameters[0].Value = id;
            parameters[1] = new SqlParameter("@Amount", SqlDbType.Float);
            parameters[1].Value = amount;
            cmd.Parameters.AddRange(parameters);

            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();
        }
    }
}