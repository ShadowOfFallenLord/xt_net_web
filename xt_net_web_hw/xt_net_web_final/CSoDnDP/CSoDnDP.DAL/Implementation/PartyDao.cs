using CSoDnDP.DAL.Interfaces;
using CSoDnDP.Entities.Enums;
using CSoDnDP.Entities.Implementation.Parties;
using CSoDnDP.Entities.Interfaces.Parties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSoDnDP.DAL.Implementation
{
    public class PartyDao : IPartyDao
    {
        private string connection_string;

        public PartyDao(string connection_string)
        {
            this.connection_string = connection_string;
        }

        public bool AddParty(string party_name, int master_id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.CreateParty";

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.String,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@party_name",
                        Value = party_name
                    });

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@master_id",
                        Value = master_id
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

        public void RemoveParty(int party_id)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveParty";

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@party_id",
                    Value = party_id
                });

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool SetPartyState(int party_id, int state_id)
        {
            if (state_id < 0 || state_id > 3) return false;

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.SetPartyState";

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@party_id",
                    Value = party_id
                });

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@state_id",
                    Value = state_id
                });

                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public IEnumerable<IParty> GetAllParties()
        {
            List<IParty> res = new List<IParty>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllParties";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(new Party
                    {
                        ID = (int)reader["PartyID"],
                        Name = reader["PartyName"] as string,
                        MasterName = reader["UserLogin"] as string,
                        State = (PartyState)((int)reader["PartyState"]),
                    });
                }
            }

            return res;
        }

        public IParty GetPartyByID(int party_id)
        {
            List<IParty> res = new List<IParty>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetPartyById";

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@party_id",
                    Value = party_id
                });

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(new Party
                    {
                        ID = (int)reader["PartyID"],
                        Name = reader["PartyName"] as string,
                        MasterName = reader["UserLogin"] as string,
                        State = (PartyState)((int)reader["PartyState"]),
                    });
                }
            }

            if (res.Count < 1) return null;
            return res[0];
        }

        public bool AddPlayer(int party_id, int player_id, int char_id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.AddPlayerAtParty";

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@party_id",
                        Value = party_id
                    });

                    command.Parameters.Add(new SqlParameter
                    {
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@player_id",
                        Value = player_id
                    });

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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void RemovePlayer(int party_id, int char_id)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemovePlayerFromParty";

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@party_id",
                    Value = party_id
                });

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

        public IEnumerable<IPartyPlayer> GetPlayers(int party_id)
        {
            List<IPartyPlayer> res = new List<IPartyPlayer>();

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllPlayerFromParty";

                command.Parameters.Add(new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@party_id",
                    Value = party_id
                });

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(new PartyPlayer
                    {
                        PlayerID = (int)reader["PlayerID"],
                        PlayerName = reader["UserLogin"] as string,
                        CharID = (int)reader["CharacterID"],
                        CharName = reader["CharName"] as string
                    });
                }
            }

            return res;
        }
    }
}
