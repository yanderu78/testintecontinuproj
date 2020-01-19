using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoodtimeApi.Models;
using MySql.Data.MySqlClient;

namespace GoodtimeApi.Services
{
    internal class GoodtimeService : IGoodtimeService
    {
        private string connection;

        public GoodtimeService() {
        }

        public void SetConnectionString(string mysqlConStr)
        {
            connection = mysqlConStr;
        }

        public Task<IEnumerable<Bar>> GetAllBars()
        {
            List<Bar> list = new List<Bar>();

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("GetAllBars", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Bar()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            name = reader["name"].ToString(),
                            phone = reader["phone"].ToString(),
                            lat = float.Parse(reader["lat"].ToString()),
                            lon = float.Parse(reader["lon"].ToString()),
                            cheaper_pint = float.Parse(reader["cheaper_pint"].ToString()),
                            adress = reader["adress"].ToString()
                        });
                    }
                }
            }
            return Task.FromResult<IEnumerable<Bar>>(list);
        }

        public Task<Bar> GetBar(int id)
        {
            Bar result;
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("GetBar", conn);
                cmd.Parameters.AddWithValue("@bar_ID", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    result = new Bar()
                    {
                            id = Convert.ToInt32(reader["id"]),
                            name = reader["name"].ToString(),
                            phone = reader["phone"].ToString(),
                            lat = float.Parse(reader["lat"].ToString()),
                            lon = float.Parse(reader["lon"].ToString()),
                            cheaper_pint = float.Parse(reader["cheaper_pint"].ToString()),
                            adress = reader["adress"].ToString()
                    };
                }
            }
            return Task.FromResult(result);
        }

        public Task<Reservations> GetReservations(int id)
        {
            Reservations result = new Reservations();

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("GetAcceptedRes", conn);
                cmd.Parameters.AddWithValue("@bar_ID", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.accepted.Add(new Reservation()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            name = reader["name"].ToString(),
                            number = reader["number"].ToString(),
                            email = reader["mail"].ToString(),
                            nb_persons = Convert.ToInt32(reader["nb_persons"]),
                            date = Convert.ToDateTime(reader["date"].ToString())
                        });
                    }
                }

                cmd = new MySqlCommand("GetWaitingRes", conn);
                cmd.Parameters.AddWithValue("@bar_ID", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.waiting.Add(new Reservation()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            name = reader["name"].ToString(),
                            number = reader["number"].ToString(),
                            email = reader["mail"].ToString(),
                            nb_persons = Convert.ToInt32(reader["nb_persons"]),
                            date = Convert.ToDateTime(reader["date"].ToString())
                        });
                    }
                }

                cmd = new MySqlCommand("GetDeniedRes", conn);
                cmd.Parameters.AddWithValue("@bar_ID", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.denied.Add(new Reservation()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            name = reader["name"].ToString(),
                            number = reader["number"].ToString(),
                            email = reader["mail"].ToString(),
                            nb_persons = Convert.ToInt32(reader["nb_persons"]),
                            date = Convert.ToDateTime(reader["date"].ToString())
                        });
                    }
                }
            }
            return Task.FromResult(result);
        }

        public Task<IEnumerable<MenuItem>> GetMenu(int id)
        {
            List<MenuItem> list = new List<MenuItem>();

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("GetMenuItem", conn);
                cmd.Parameters.AddWithValue("@bar_ID", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MenuItem()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            name = reader["name"].ToString(),
                            price = float.Parse(reader["lat"].ToString())
                        });
                    }
                }
            }
            return Task.FromResult<IEnumerable<MenuItem>>(list);
        }

        public void CreateMenuItem(MenuItem item, int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("InsertMenuItem", conn);
                cmd.Parameters.AddWithValue("@bar_ID", id);
                cmd.Parameters.AddWithValue("@bar_ID", id);
                cmd.Parameters.AddWithValue("@bar_ID", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateReservation(Reservation item, int id, int user_id)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("InsertReservation", conn);
                cmd.Parameters.AddWithValue("@bar_ID", id);
                cmd.Parameters.AddWithValue("@in_name", item.name);
                cmd.Parameters.AddWithValue("@in_nb", item.nb_persons);
                cmd.Parameters.AddWithValue("@in_date", item.date);
                cmd.Parameters.AddWithValue("@user_ID", user_id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }

        public void AcceptEvent(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("AcceptReservation", conn);
                cmd.Parameters.AddWithValue("@res_ID", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }

        public void RefuseEvent(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("RefuseReservation", conn);
                cmd.Parameters.AddWithValue("@res_ID", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMenuItem(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DeleteMenuItem", conn);
                cmd.Parameters.AddWithValue("@item_ID", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
    }
}