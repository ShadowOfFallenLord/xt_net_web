using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.DAL.Interfaces;
using Task_11.Entities.Implementation;
using Task_11.Entities.Interfaces;

namespace Task_11.DAL.Implementation
{
    public class UserAwardsDao : IUserAwardsDao
    {
        private string connection_string;

        public UserAwardsDao(string connection_string)
        {
            this.connection_string = connection_string;
        }

        public IEnumerable<IAward> GetUserAwards(int user_id)
        {
            List<Award> res = new List<Award>();
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserAwards";                

                SqlParameter user_id_param = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = user_id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(user_id_param);

                connection.Open(); 
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(new Award
                    {
                        ID = (int)reader["ID"],
                        Title = reader["Title"] as string,
                        Image = reader["AwardImage"] as byte[]
                    });
                }
            }
            return res;
        }

        public bool AddAwardToUser(int user_id, int award_id)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAwardToUser";

                SqlParameter user_id_param = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@user_id",
                    Value = user_id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(user_id_param);

                SqlParameter award_id_param = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@award_id",
                    Value = award_id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(award_id_param);

                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool RemoveAwardFromUser(int user_id, int award_id)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveAwardFromUser";

                SqlParameter user_id_param = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@user_id",
                    Value = user_id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(user_id_param);

                SqlParameter award_id_param = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@award_id",
                    Value = award_id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(award_id_param);

                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool RemoveAwardFromAll(int award_id)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveAwardFromAll";

                SqlParameter award_id_param = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@award_id",
                    Value = award_id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(award_id_param);

                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool RemoveAllAwardFromUser(int user_id)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveAllAwardsFromUser";

                SqlParameter user_id_param = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = user_id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(user_id_param);

                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool HaveUserAward(int user_id, int award_id)
        {
            return GetUserAwards(user_id).Count((x) => x.ID == award_id) > 0;
        }
    }
}
