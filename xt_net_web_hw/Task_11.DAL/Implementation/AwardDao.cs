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
    public class AwardDao : IAwardDao
    {
        private string connection_string;

        public AwardDao(string connection_string)
        {
            this.connection_string = connection_string;
        }

        public int AddAward(string title)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAward";

                SqlParameter title_param = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@title",
                    Value = title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(title_param);

                SqlParameter img_param = new SqlParameter()
                {
                    ParameterName = "@award_image",
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

        public IEnumerable<IAward> GetAllAwards()
        {
            List<Award> res = new List<Award>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllAwards";

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

        public IAward GetAwardByID(int id)
        {
            List<Award> res = new List<Award>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAwardById";

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
                    res.Add(new Award
                    {
                        ID = (int)reader["ID"],
                        Title = reader["Title"] as string,
                        Image = reader["AwardImage"] as byte[]
                    });
                }
            }

            if (res.Count < 1) return null;
            return res[0];
        }

        public IAward GetAwardByTitle(string title)
        {
            List<Award> res = new List<Award>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAwardByTitle";

                SqlParameter title_param = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@title",
                    Value = title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(title_param);

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

            if (res.Count < 1) return null;
            return res[0];
        }

        public int GetAwardsCount()
        {
            return GetAllAwards().Count();
        }

        public bool UpdateAward(int id, string title, byte[] img)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateAward";

                SqlParameter id_param = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(id_param);

                SqlParameter title_param = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@title",
                    Value = title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(title_param);

                SqlParameter img_param = new SqlParameter()
                {
                    ParameterName = "@award_image",
                    Value = img,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(img_param);

                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool UpdateAward(int id, string title)
        {
            return UpdateAward(id, title, DefaultImage.Image);
        }

        public bool RemoveAward(int id)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveAward";

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
    }
}
