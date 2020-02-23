using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data;

namespace HW_Task_11
{
    public enum AuthResult
    {
        IncorrectLogin = 0,
        IncorrectPass = 1,
        Correct = 2
    }

    public class DarkRoleProvider : RoleProvider
    {
        private string connection_string = @"Data Source=DARKMASHINE\SQLEXPRESS;Initial Catalog=UsersDB;Integrated Security=True";

        public override bool IsUserInRole(string username, string roleName)
        {
            return GetRolesForUser(username).Contains(roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            int id = GetUserID(username);

            if (id < 0) return new string[0];

            List<string> res = new List<string>();

            using(SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetClientRoles";

                SqlParameter id_param = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@user_id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(id_param);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    res.Add(reader["RoleName"] as string);
                }
            }

            return res.ToArray();
        }

        public int GetUserID(string user_name)
        {
            List<int> res = new List<int>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.HasClient";

                SqlParameter name_param = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@user_name",
                    Value = user_name,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(name_param);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add((int)reader["ClientID"]);
                }
            }

            if (res.Count < 1) return -1;
            return res[0];
        }

        public bool SetRole(string user_name, bool set_admin = false)
        {
            int id = GetUserID(user_name);

            if (id < 0) return false;

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                if (set_admin)
                {
                    command.CommandText = "dbo.MakeClientAdmin";
                }
                else
                {
                    command.CommandText = "dbo.MakeClientUser";
                }

                SqlParameter id_param = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@user_id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(id_param);

                connection.Open();
                command.ExecuteNonQuery();
            }

            return true;
        }

        public bool AddNewUser(string user_name, string user_pass)
        {
            int id = GetUserID(user_name);

            if (id > 0) return false;

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddClient";

                SqlParameter name_param = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@user_name",
                    Value = user_name,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(name_param);

                SqlParameter pass_param = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@user_pass",
                    Value = user_pass,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(pass_param);

                connection.Open();
                command.ExecuteNonQuery();
            }

            return true;
        }

        public AuthResult AuthUser(string user_name, string user_pass)
        {
            int id = GetUserID(user_name);

            if (id < 0) return AuthResult.IncorrectLogin;

            List<int> res = new List<int>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.CheckAuth";

                SqlParameter name_param = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@user_name",
                    Value = user_name,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(name_param);

                SqlParameter pass_param = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@user_pass",
                    Value = user_pass,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(pass_param);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add((int)reader["ClientID"]);
                }
            }

            if (res.Count < 1) return AuthResult.IncorrectPass;
            return AuthResult.Correct;
        }

        #region NOT_IMPLEMENTED

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}