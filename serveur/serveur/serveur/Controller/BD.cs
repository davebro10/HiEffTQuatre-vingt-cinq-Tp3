using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serveur.Models
{
    public class BD
    {
        private MySqlConnection _conn { get; set; }

        public MySqlConnection Connection
        {
            get => _conn;
        }

        public BD()
        {
            string _server = "ni-web-01.srv.nihost.fr";
            string _user = "minedexf_utp3";
            string _database = "minedexf_tp3";
            string _password = "!TP3BD18!";

            _conn = new MySqlConnection($"server={_server};user={_user};database={_database};port=3306;password={_password}");
        }

        public void OpenConnection()
        {
            try
            {
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (_conn.State != ConnectionState.Closed)
                {
                    _conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
