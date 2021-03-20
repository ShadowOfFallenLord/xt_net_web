using CSoDnDP.DAL.Interfaces;
using CSoDnDP.Entities.Interfaces;
using CSoDnDP.Entities.Implementation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CSoDnDP.DAL.Implementation
{
    public class UserDao : IUserDao
    {
        private string connection_string;

        public UserDao(string connection_string)
        {
            this.connection_string = connection_string;
        }

        public IUser GetUserByName(string name)
        {
            List<IUser> res = new List<IUser>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserInfoByLogin";

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@user_login",
                    Value = name
                });

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(new User
                    {
                        ID = (int)reader["UserID"],
                        Login = reader["UserLogin"] as string,
                        Password = reader["UserPassword"] as string,
                        Role = reader["UserRoleName"] as string,
                    });
                }
            }

            if (res.Count < 1) return null;
            return res[0];
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            List<IUser> res = new List<IUser>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUsers";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(new User
                    {
                        ID = (int)reader["UserID"],
                        Login = reader["UserLogin"] as string,
                        Password = reader["UserPassword"] as string,
                        Role = reader["UserRoleName"] as string,
                    });
                }
            }

            return res;
        }

        public IEnumerable<string> GetUserRoles(int user_id)
        {
            List<string> res = new List<string>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserRoles";

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@user_id",
                    Value = user_id
                });

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(reader["UserRoleName"] as string);
                }
            }

            return res;
        }

        public bool SetUserRole(int user_id, int role_id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.SetUserRole";

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@user_id",
                        Value = user_id
                    });

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@role",
                        Value = role_id
                    });

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool AddUser(string user_login, string user_pass)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.AddUser";

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.String,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@user_login",
                        Value = user_login
                    });

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.String,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@user_password",
                        Value = user_pass
                    });

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void RemoveUser(int user_id)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveUser";

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@user_id",
                    Value = user_id
                });

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
