using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serveur.Models
{
    public class BD
    {
        public MySqlConnection _conn { get; set; }

        public BD()
        {
            string _server = "ni-web-01.srv.nihost.fr";
            string _user = "minedexf_utp3";
            string _database = "minedexf_tp3";
            string _password = "!TP3BD18!";

            _conn = new MySqlConnection($"server={_server};user={_user};database={_database};port=3306;password={_password}");
        }

        public bool OpenConnection()
        {
            try
            {
                _conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                _conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
