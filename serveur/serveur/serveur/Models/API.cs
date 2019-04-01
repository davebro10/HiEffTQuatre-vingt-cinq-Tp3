using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serveur.Models
{
    public class API
    {
        private BD bdd;
        
        public API()
        {
            bdd = new BD();
        }

        public List<Client> GetAllClient()
        {
            try
            {
                List<Client> lst = new List<Client>();
                bdd.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM client", bdd._conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Client c = new Client();
                    c.id_client = (int)reader["id_client"];
                    c.nom = reader["nom"] != DBNull.Value ? reader.GetString("nom") : null;
                    c.usager = reader["usager"] != DBNull.Value ? reader.GetString("usager") : null;
                    c.motdepasse = reader["motdepasse"] != DBNull.Value ? reader.GetString("motdepasse") : null;
                    c.action = reader["action"] != DBNull.Value ? reader.GetDateTime("action") : (DateTime?)null;
                    lst.Add(c);
                }

                bdd.CloseConnection();
                return lst;
            }
            catch (Exception ex)
            {
                bdd.CloseConnection();
                throw ex;
            }
        }

        public bool CreateClient(Client c)
        {
            return true;
        }

        public bool ModifyClient(Client c)
        {
            return true;
        }

        public bool DeleteClient(Client c)
        {
            return true;
        }

        public bool CreateGroup(Groupe g)
        {
            return true;
        }

        public bool ModifyGroup(Groupe g)
        {
            return true;
        }

        public bool DeleteGroup(Groupe g)
        {
            return true;
        }

        public bool CreateFile(Fichier file)
        {
            return true;
        }

        public bool ModifyFile(Fichier file)
        {
            return true;
        }

        public bool DeleteFile(Fichier file)
        {
            return true;
        }

        public bool InviteMemberToGroup(Groupe group, Client member)
        {
            return true;
        }

        public bool InviteAnswer(Invitation inv, bool answer)
        {
            return true;
        }

        public bool RemoveMemberFromGroup(Groupe group, Client member)
        {
            return true;
        }

        public bool SetGroupAdministrator(Groupe group, Client admin)
        {
            return true;
        }

        public bool Authentificate(string username, string password)
        {
            return true;
        }

    }
}
