using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.Entities.Enums;
using Task_11.DAL.Interfaces;
using Task_11.Entities.Implementation;
using Task_11.Entities.Interfaces;

namespace Task_11.DAL.Implementation
{
    public class ClientDao : IClientDao
    {
        private string connection_string;

        public ClientDao(string connection_string)
        {
            this.connection_string = connection_string;
        }

        public IClient[] GetAllClients()
        {
            List<Client> res = new List<Client>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllClients";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(new Client
                    {
                        ID = (int)reader["ClientID"],
                        Name = reader["ClientName"] as string,
                        Role = reader["RoleName"] as string
                    });
                }
            }

            return res.ToArray();
        }

        public string[] GetRolesForClient(string user_name)
        {
            int id = GetClientID(user_name);

            if (id < 0) return new string[0];

            List<string> res = new List<string>();

            using (SqlConnection connection = new SqlConnection(connection_string))
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

                while (reader.Read())
                {
                    res.Add(reader["RoleName"] as string);
                }
            }

            return res.ToArray();
        }

        public int GetClientID(string user_name)
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

        public bool SetRoleToClient(int user_id, bool set_admin = false)
        {
            if (user_id < 0) return false;

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
                    Value = user_id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(id_param);

                connection.Open();
                command.ExecuteNonQuery();
            }

            return true;
        }

        public bool AddNewClient(string user_name, string user_pass)
        {
            int id = GetClientID(user_name);

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

        public AuthResult AuthClient(string user_name, string user_pass)
        {
            int id = GetClientID(user_name);
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

            if (res.Count < 1)
            {
                return AuthResult.IncorrectPass;
            }
            return AuthResult.Correct;
        }
    }
}
