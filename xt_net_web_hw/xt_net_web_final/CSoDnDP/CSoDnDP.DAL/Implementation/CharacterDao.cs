using CSoDnDP.DAL.Interfaces;
using CSoDnDP.Entities.Implementation;
using CSoDnDP.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CSoDnDP.DAL.Implementation
{
    public class CharacterDao : ICharacterDao
    {
        private string connection_string;

        public CharacterDao(string connection_string)
        {
            this.connection_string = connection_string;
        }

        public IEnumerable<ICharacter> GetAllCharacters()
        {
            List<ICharacter> res = new List<ICharacter>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllChar";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(new Character
                    {
                        ID = (int)reader["CharacterID"],
                        PlayerName = reader["UserLogin"] as string,
                        Name = reader["CharName"] as string,
                        InfoXML = XElement.Parse(reader["InfoXML"] as string),
                        StatesXML = XElement.Parse(reader["StatesXML"] as string),
                        MagicXML = XElement.Parse(reader["MagicXML"] as string),
                        InventoryXML = XElement.Parse(reader["InventoryXML"] as string)
                    });
                }
            }

            return res;
        }

        public ICharacter GetCharacterByID(int id)
        {
            List<ICharacter> res = new List<ICharacter>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetCharByID";

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@char_id",
                    Value = id
                });

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(new Character
                    {
                        ID = (int)reader["CharacterID"],
                        PlayerName = reader["UserLogin"] as string,
                        Name = reader["CharName"] as string,
                        InfoXML = XElement.Parse(reader["InfoXML"] as string),
                        StatesXML = XElement.Parse(reader["StatesXML"] as string),
                        MagicXML = XElement.Parse(reader["MagicXML"] as string),
                        InventoryXML = XElement.Parse(reader["InventoryXML"] as string)
                    });
                }
            }

            if (res.Count < 1) return null;
            return res[0];
        }

        public bool AddChar(int player_id, string char_name, XElement info,
            XElement states, XElement magic, XElement inventory)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.AddChar";

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@player_id",
                        Value = player_id
                    });

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.String,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@char_name",
                        Value = char_name
                    });

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.Xml,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@info_xml",
                        Value = info.ToString()
                    });

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.Xml,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@states_xml",
                        Value = states.ToString()
                    });

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.Xml,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@magic_xml",
                        Value = magic.ToString()
                    });

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.Xml,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@inventory_xml",
                        Value = inventory.ToString()
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

        public void UpdateChar(int char_id, string char_name, XElement info,
            XElement states, XElement magic, XElement inventory)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateChar";

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@char_id",
                    Value = char_id
                });

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@char_name",
                    Value = char_name
                });

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Xml,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@info_xml",
                    Value = info.ToString()
                });

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Xml,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@states_xml",
                    Value = states.ToString()
                });

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Xml,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@magic_xml",
                    Value = magic.ToString()
                });

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Xml,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@inventory_xml",
                    Value = inventory.ToString()
                });

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void RemoveChar(int char_id)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveChar";

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@char_id",
                    Value = char_id
                });

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
