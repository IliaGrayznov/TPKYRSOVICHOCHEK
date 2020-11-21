using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace WebApplication1.DAO
{
    public class DAO
    {
        private const string strcon = "server=localhost;" +
            "user id=root;" +
            "password=root; " +
            "persistsecurityinfo=True;" +
            "database=chess_tournaments;" +
            "allowuservariables=True";
        protected MySqlConnection connection { get; set; }
        public void connect()
        {
            connection = new MySqlConnection(strcon);
            connection.Open();
        }

        public void disconnect()
        {
            connection.Close();
        }
    }
}