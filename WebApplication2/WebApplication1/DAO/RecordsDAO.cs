using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace WebApplication1.DAO
{
    public class RecordsDAO: DAO
    {
        public List<Records> GetRecords()
        {
            connect();
            List<Records> recordlist = new List<Records>();
            try
            {
                MySqlCommand command = new MySqlCommand("select ID, name, year, ID_winner from tournament", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Records r = new Records();
                    r.ID = Convert.ToInt32(reader["ID"]);
                    r.name = Convert.ToString(reader["name"]);
                    r.year = Convert.ToInt32(reader["year"]);
                    r.ID_winner = Convert.ToInt32(reader["id_winner"]);
                    recordlist.Add(r);
                }
                reader.Close();
            }
            catch (Exception)
            {
                //do something
            }
            finally
            {
                disconnect();
            }

            return recordlist;
        }
        public bool AddRecord(Records records)
        {
            bool result = true;
            connect();
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tournament (name, ID_country, year, Averange_rating, ID_winner, tie_break, pool_prize) " +
                                                                          "values (@n, @ID_c, @y, @A, @ID_w, @tie, @prize)", connection);
                cmd.Parameters.Add(new MySqlParameter("@n", records.name));
                cmd.Parameters.Add(new MySqlParameter("@ID_c", records.ID_country));
                cmd.Parameters.Add(new MySqlParameter("@y", records.year));
                cmd.Parameters.Add(new MySqlParameter("@A", records.averange_rating));
                cmd.Parameters.Add(new MySqlParameter("@ID_w", records.ID_winner));
                cmd.Parameters.Add(new MySqlParameter("@tie", records.tie_break));
                cmd.Parameters.Add(new MySqlParameter("@prize", records.pool_prize));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                disconnect();
            }
            return result;
        }

        public Records getDetaild(int id)
        {
            Records r = new Records();
            connect();
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tournament where ID=@id", connection);
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                r.ID = Convert.ToInt32(reader["ID"]);
                r.ID_country = Convert.ToInt32(reader["ID_country"]);
                r.ID_winner = Convert.ToInt32(reader["ID_winner"]);
                r.name = Convert.ToString(reader["name"]);
                r.pool_prize = Convert.ToInt32(reader["pool_prize"]);
                r.tie_break = Convert.ToBoolean(reader["tie_break"]);
                r.year = Convert.ToInt32(reader["year"]);
                r.averange_rating = Convert.ToInt32(reader["Averange_rating"]);
                reader.Close();
            }
            finally
            {
                disconnect();
            }
            return r;
        }

        public bool DeleteRecord(int id)
        {
            bool result = true;
            connect();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Delete from tournament where ID=@id", connection);
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                cmd.ExecuteNonQuery();
            }
            catch
            {
                result = false;
            }
            finally
            {
                disconnect();
            }
            return result;
        }

        public bool EditRecord(int id, Records records)
        {
            bool result = true;
            connect();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Update tournament set pool_prize=@prize, Averange_rating=@rating where ID=@id", connection);
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                cmd.Parameters.Add(new MySqlParameter("@prize", records.pool_prize));
                cmd.Parameters.Add(new MySqlParameter("@rating", records.averange_rating));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                disconnect();
            }
            return result;
        }
    }
}