using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.Entities.Interfaces;
using Task_11.Entities.Implementation;
using Task_11.DAL.Interfaces;

namespace Task_11.DAL.Implementation
{
    public class UserDao : IUserDao
    {
        private string connection_string;

        public UserDao(string connection_string)
        {
            this.connection_string = connection_string;
        }

        public int AddUser(string name, DateTime dob)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUser";

                SqlParameter name_param = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@name",
                    Value = name,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(name_param);

                SqlParameter dob_param = new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@date_of_birth",
                    Value = dob,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(dob_param);

                SqlParameter img_param = new SqlParameter()
                {
                    ParameterName = "@user_image",
                    Value = DefaultImage.Image,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(img_param);

                SqlParameter id_param = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = 0,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(id_param);

                connection.Open();
                command.ExecuteNonQuery();
                return (int)id_param.Value;
            }
        }

        public bool UpdateUser(int id, string name, DateTime dob, byte[] img)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateUser";

                SqlParameter id_param = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(id_param);

                SqlParameter name_param = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@name",
                    Value = name,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(name_param);

                SqlParameter dob_param = new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@date_of_birth",
                    Value = dob,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(dob_param);

                SqlParameter img_param = new SqlParameter()
                {
                    ParameterName = "@user_image",
                    Value = img,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(img_param);

                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool UpdateUser(int id, string name, DateTime dob)
        {
            return UpdateUser(id, name, dob, DefaultImage.Image);
        }

        public bool RemoveUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveUser";

                SqlParameter id_param = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(id_param);

                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public IUser GetUserByID(int id)
        {
            List<User> res = new List<User>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserById";

                SqlParameter id_param = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(id_param);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(new User
                    {
                        ID = (int)reader["ID"],
                        Name = reader["Name"] as string,
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Image = reader["UserImage"] as byte[]
                    });
                }
            }

            if (res.Count < 1) return null;
            return res[0];
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            List<User> res = new List<User>();

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
                        ID = (int)reader["ID"],
                        Name = reader["Name"] as string,
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Image = reader["UserImage"] as byte[]
                    });
                }
            }

            return res;
        }

        public int GetUsersCount()
        {
            return GetAllUsers().Count();
        }
    }
}
