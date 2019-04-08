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

        public static DateTime LAST_TIME_SYNC_CLIENTS { get; set; }
        public static DateTime LAST_TIME_SYNC_FILES { get; set; }
        public static DateTime LAST_TIME_SYNC_GROUPS { get; set; }
        public static DateTime LAST_TIME_SYNC_NOTIFS { get; set; }

        public API()
        {
            bdd = new BD();
            LAST_TIME_SYNC_CLIENTS = DateTime.Now;
            LAST_TIME_SYNC_FILES = DateTime.Now;
            LAST_TIME_SYNC_GROUPS = DateTime.Now;
            LAST_TIME_SYNC_NOTIFS = DateTime.Now;
        }

        private bool ExecuteNonQuery(MySqlCommand cmd)
        {
            try
            {
                bdd.OpenConnection();
                cmd.Connection = bdd.Connection;
                cmd.Transaction = bdd.Connection.BeginTransaction();
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                bdd.CloseConnection();
                return true;
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
                bdd.CloseConnection();
                return false;
            }
        }

        private MySqlDataReader ExecuteReader(MySqlCommand cmd)
        {
            try
            {
                bdd.OpenConnection();
                cmd.Connection = bdd.Connection;
                var reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception)
            {
                bdd.CloseConnection();
                return null;
            }
        }

        // Client //

        private Client ReaderToClient(MySqlDataReader reader)
        {
            Client client = new Client
            {
                id_client = reader["id_client"] != DBNull.Value ? (int)reader["id_client"] : 0,
                nom = reader["nom"] != DBNull.Value ? reader.GetString("nom") : null,
                usager = reader["usager"] != DBNull.Value ? reader.GetString("usager") : null,
                motdepasse = reader["motdepasse"] != DBNull.Value ? reader.GetString("motdepasse") : null,
                action = reader["action"] != DBNull.Value ? reader.GetDateTime("action") : (DateTime?)null
            };

            return client;
        }

        /// <exception cref="Exception"/>
        public List<Client> GetAllClient()
        {
            List<Client> lst = new List<Client>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM client");
                using (MySqlDataReader reader = ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Client c = ReaderToClient(reader);
                        lst.Add(c);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            LAST_TIME_SYNC_CLIENTS = DateTime.Now;
            bdd.CloseConnection();
            return lst;
        }

        public bool CreateClient(Client c)
        {
            string query = "INSERT INTO client(nom, usager, motdepasse, action) VALUES(@nom,@usager,@motdepasse,@action)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@nom", c.nom);
            cmd.Parameters.AddWithValue("@usager", c.usager);
            cmd.Parameters.AddWithValue("@motdepasse", c.motdepasse);
            cmd.Parameters.AddWithValue("@action", c.action);
            LAST_TIME_SYNC_CLIENTS = DateTime.Now;
            return ExecuteNonQuery(cmd);
        }

        public bool ModifyClient(Client c)
        {
            string query = "UPDATE client SET nom=@nom, usager=@usager, motdepasse=@motdepasse, action=@action WHERE id_client=@id_client";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_client", c.id_client);
            cmd.Parameters.AddWithValue("@nom", c.nom);
            cmd.Parameters.AddWithValue("@usager", c.usager);
            cmd.Parameters.AddWithValue("@motdepasse", c.motdepasse);
            cmd.Parameters.AddWithValue("@action", c.action);
            LAST_TIME_SYNC_CLIENTS = DateTime.Now;
            return ExecuteNonQuery(cmd);
        }

        public bool DeleteClient(Client c)
        {
            string query = "DELETE FROM liste_groupe_client WHERE id_client_fk=@id_client";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_client", c.id_client);

            if (!ExecuteNonQuery(cmd))
            {
                return false;
            }
            
            cmd = new MySqlCommand("DELETE FROM invitation WHERE id_client_fk=@id_client");
            cmd.Parameters.AddWithValue("@id_client", c.id_client);
            if (!ExecuteNonQuery(cmd))
            {
                return false;
            }
            
            cmd = new MySqlCommand("DELETE FROM client WHERE id_client=@id_client");
            cmd.Parameters.AddWithValue("@id_client", c.id_client);
            LAST_TIME_SYNC_CLIENTS = DateTime.Now;
            return ExecuteNonQuery(cmd);
        }

        public Client GetClient(int id_client)
        {
            string query = "SELECT * FROM client WHERE id_client=@id_client";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_client", id_client);

            using (var reader = ExecuteReader(cmd))
            {
                if (!reader.HasRows)
                {
                    return null;
                }
                reader.Read();
                Client client = ReaderToClient(reader);
                bdd.CloseConnection();
                LAST_TIME_SYNC_CLIENTS = DateTime.Now;
                return client;
            }
        }

        public Client GetClient(string usager)
        {
            string query = "SELECT * FROM client WHERE usager=@usager";
            var dic = new Dictionary<string, object>
            {
                { "@usager", usager }
            };
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@usager", usager);

            using (var reader = ExecuteReader(cmd))
            {
                if (!reader.HasRows)
                {
                    return null;
                }

                reader.Read();
                Client client = ReaderToClient(reader);
                bdd.CloseConnection();
                LAST_TIME_SYNC_CLIENTS = DateTime.Now;
                return client;
            }
        }

        // GROUP //

        private Groupe ReaderToGroup(MySqlDataReader reader)
        {
            Groupe groupe = new Groupe
            {
                id_groupe = reader["id_groupe"] != DBNull.Value ? reader.GetInt32("id_groupe") : 0,
                nom = reader["nom"] != DBNull.Value ? reader.GetString("nom") : null,
                admin = reader["admin"] != DBNull.Value ? reader.GetInt32("admin") : 0
            };
            LAST_TIME_SYNC_GROUPS = DateTime.Now;
            return groupe;
        }

        private Invitation ReaderToInvitation(MySqlDataReader reader)
        {
            Invitation inv = new Invitation
            {
                id_invitation = reader["id_invitation"] != DBNull.Value ? reader.GetInt32("id_invitation") : 0,
                id_groupe_fk = reader["id_groupe_fk"] != DBNull.Value ? reader.GetInt32("id_groupe_fk") : 0,
                id_client_fk = reader["id_client_fk"] != DBNull.Value ? reader.GetInt32("id_client_fk") : 0
            };
            LAST_TIME_SYNC_NOTIFS = DateTime.Now;
            return inv;
        }

        /// <exception cref="Exception"/>
        public List<Groupe> GetAllGroup()
        {
            List<Groupe> lst = new List<Groupe>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM groupe");
                using (var reader = ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Groupe g = ReaderToGroup(reader);
                        lst.Add(g);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            bdd.CloseConnection();
            LAST_TIME_SYNC_GROUPS = DateTime.Now;
            return lst;
        }

        public bool CreateGroup(Groupe g)
        {
            string query = "INSERT INTO groupe(admin, nom) VALUES(@admin,@nom)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@admin", g.admin);
            cmd.Parameters.AddWithValue("@nom", g.nom);
            bool success = ExecuteNonQuery(cmd);
            if(success && cmd.LastInsertedId != 0)
            {
                AddMemberToGroup((int)cmd.LastInsertedId, g.admin);
            }
            LAST_TIME_SYNC_GROUPS = DateTime.Now;
            return success;
        }

        public bool ModifyGroup(Groupe g)
        {
            string query = "UPDATE groupe SET admin=@admin, nom=@nom WHERE id_groupe=@id_groupe";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_groupe", g.id_groupe);
            cmd.Parameters.AddWithValue("@admin", g.admin);
            cmd.Parameters.AddWithValue("@nom", g.nom);
            LAST_TIME_SYNC_GROUPS = DateTime.Now;
            return ExecuteNonQuery(cmd);
        }

        public bool SetGroupAdministrator(Groupe group, Client admin)
        {
            group.admin = admin.id_client;
            LAST_TIME_SYNC_GROUPS = DateTime.Now;
            return ModifyGroup(group);
        }

        public bool DeleteGroup(Groupe g)
        {
            string query = "DELETE FROM liste_groupe_client WHERE id_groupe_fk=@id_groupe";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_groupe", g.id_groupe);

            if (!ExecuteNonQuery(cmd))
            {
                return false;
            }

            query = "DELETE FROM invitation WHERE id_groupe_fk=@id_groupe";
            cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_groupe", g.id_groupe);
            if (!ExecuteNonQuery(cmd))
            {
                return false;
            }

            query = "DELETE FROM fichier WHERE id_groupe_fk=@id_groupe";
            cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_groupe", g.id_groupe);
            if (!ExecuteNonQuery(cmd))
            {
                return false;
            }

            query = "DELETE FROM groupe WHERE id_groupe=@id_groupe";
            cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_groupe", g.id_groupe);
            LAST_TIME_SYNC_GROUPS = DateTime.Now;
            return ExecuteNonQuery(cmd);
        }

        public Groupe GetGroup(int id_groupe)
        {
            string query = "SELECT * FROM groupe WHERE id_groupe=@id_groupe";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_groupe", id_groupe);

            using (var reader = ExecuteReader(cmd))
            {
                if (!reader.HasRows)
                {
                    return null;
                }

                reader.Read();
                Groupe groupe = ReaderToGroup(reader);
                bdd.CloseConnection();
                LAST_TIME_SYNC_GROUPS = DateTime.Now;
                return groupe;
            }
        }

        public List<Invitation> GetAllInvitation()
        {
            List<Invitation> lst = new List<Invitation>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM invitation");
                using (MySqlDataReader reader = ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Invitation inv = ReaderToInvitation(reader);
                        lst.Add(inv);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            bdd.CloseConnection();
            LAST_TIME_SYNC_NOTIFS = DateTime.Now;
            return lst;
        }

        public Invitation GetInvitation(int id_invitation)
        {
            string query = "SELECT * FROM invitation WHERE id_invitation=@id_invitation";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_invitation", id_invitation);

            using (var reader = ExecuteReader(cmd))
            {
                if (!reader.HasRows)
                {
                    return null;
                }

                reader.Read();
                Invitation inv = ReaderToInvitation(reader);
                bdd.CloseConnection();
                LAST_TIME_SYNC_NOTIFS = DateTime.Now;
                return inv;
            }
        }

        public List<Invitation> GetInvitationByClient(int id_client)
        {
            List<Invitation> lst = new List<Invitation>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM invitation WHERE id_client_fk=@id_client");
                cmd.Parameters.AddWithValue("@id_client", id_client);
                using (var reader = ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Invitation inv = ReaderToInvitation(reader);
                        lst.Add(inv);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            bdd.CloseConnection();
            LAST_TIME_SYNC_NOTIFS = DateTime.Now;
            return lst;
        }

        public bool InviteMemberToGroup(int id_groupe, int id_client)
        {
            string query = "INSERT INTO invitation(id_groupe_fk, id_client_fk) VALUES(@id_groupe,@id_client)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_groupe", id_groupe);
            cmd.Parameters.AddWithValue("@id_client", id_client);
            LAST_TIME_SYNC_NOTIFS = DateTime.Now;
            return ExecuteNonQuery(cmd);
        }

        public bool DeleteInvitation(Invitation inv)
        {
            string query = "DELETE FROM invitation WHERE id_invitation=@id_invitation";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_invitation", inv.id_invitation);
            LAST_TIME_SYNC_NOTIFS = DateTime.Now;
            return ExecuteNonQuery(cmd);
        }
        
        public bool InviteAnswer(int id_invitation, bool answer)
        {
            Invitation inv = GetInvitation(id_invitation);
            if(answer)
            {
                if (AddMemberToGroup(inv.id_groupe_fk, inv.id_client_fk))
                {
                    DeleteInvitation(inv);
                    LAST_TIME_SYNC_NOTIFS = DateTime.Now;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                LAST_TIME_SYNC_NOTIFS = DateTime.Now;
                return DeleteInvitation(inv);
            }
        }
        public bool AddMemberToGroup(int id_groupe, int id_client)
        {
            string query = "INSERT INTO liste_groupe_client(id_client_fk, id_groupe_fk) VALUES(@id_client_fk,@id_groupe_fk)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_client_fk", id_client);
            cmd.Parameters.AddWithValue("@id_groupe_fk", id_groupe);
            LAST_TIME_SYNC_GROUPS = DateTime.Now;
            return ExecuteNonQuery(cmd);
        }

        public List<Client> GetGroupMember(int id_groupe)
        {
            List<Client> lst = new List<Client>();
            try
            {
                string query = "SELECT * FROM liste_groupe_client WHERE id_groupe_fk=@id_groupe";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@id_groupe", id_groupe);
                List<int> lstClientId = new List<int>();
                using (var reader = ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        int id_client = reader["id_client_fk"] != DBNull.Value ? (int)reader["id_client_fk"] : 0;
                        if (id_client != 0)
                        {
                            lstClientId.Add(id_client);
                        }
                    }
                }
                    
                foreach(int id_client in lstClientId)
                {
                    Client c = GetClient(id_client);
                    lst.Add(c);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            LAST_TIME_SYNC_GROUPS = DateTime.Now;
            bdd.CloseConnection();
            return lst;
        }

        public bool RemoveMemberFromGroup(int id_groupe, int id_client)
        {
            string query = "DELETE FROM liste_groupe_client WHERE id_client_fk=@id_client_fk AND id_groupe_fk=@id_groupe_fk";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_client_fk", id_client);
            cmd.Parameters.AddWithValue("@id_groupe_fk", id_groupe);
            LAST_TIME_SYNC_GROUPS = DateTime.Now;
            return ExecuteNonQuery(cmd);
        }

        // File //

        private Fichier ReaderToFile(MySqlDataReader reader)
        {
            Fichier file = new Fichier
            {
                id_fichier = reader["id_fichier"] != DBNull.Value ? reader.GetInt32("id_fichier") : 0,
                id_groupe_fk = reader["id_groupe_fk"] != DBNull.Value ? reader.GetInt32("id_groupe_fk") : 0,
                nom = reader["nom"] != DBNull.Value ? reader.GetString("nom") : null
            };
            LAST_TIME_SYNC_FILES = DateTime.Now;
            return file;
        }

        public Fichier GetFile(int id_fichier)
        {
            string query = "SELECT * FROM fichier WHERE id_fichier=@id_fichier";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_fichier", id_fichier);

            using (var reader = ExecuteReader(cmd))
            {
                if (!reader.HasRows)
                {
                    return null;
                }

                reader.Read();
                Fichier fichier = ReaderToFile(reader);
                bdd.CloseConnection();
                LAST_TIME_SYNC_FILES = DateTime.Now;
                return fichier;
            }
        }

        public List<Fichier> GetFileFromGroup(int id_groupe)
        {
            List<Fichier> lstFile = new List<Fichier>();
            string query = "SELECT * FROM fichier WHERE id_groupe_fk=@id_groupe";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_groupe", id_groupe);

            using (var reader = ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    Fichier fichier = ReaderToFile(reader);
                    lstFile.Add(fichier);
                }
            }

            bdd.CloseConnection();
            return lstFile;
        }

        public bool CreateFile(Fichier file)
        {
            string query = "INSERT INTO fichier(id_groupe_fk, nom) VALUES(@id_groupe_fk,@nom)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_groupe_fk", file.id_groupe_fk);
            cmd.Parameters.AddWithValue("@nom", file.nom);
            LAST_TIME_SYNC_FILES = DateTime.Now;
            return ExecuteNonQuery(cmd);
        }

        public bool ModifyFile(Fichier file)
        {
            string query = "UPDATE fichier SET id_groupe_fk=@id_groupe_fk, nom=@nom WHERE id_fichier=@id_fichier";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_fichier", file.id_fichier);
            cmd.Parameters.AddWithValue("@id_groupe_fk", file.id_groupe_fk);
            cmd.Parameters.AddWithValue("@nom", file.nom);
            LAST_TIME_SYNC_FILES = DateTime.Now;
            return ExecuteNonQuery(cmd);
        }

        public bool DeleteFile(Fichier file)
        {
            string query = "DELETE FROM fichier WHERE id_fichier=@id_fichier";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id_fichier", file.id_fichier);
            LAST_TIME_SYNC_FILES = DateTime.Now;
            return ExecuteNonQuery(cmd);
        }

        // Auth //
        public Client Authentificate(string username, string password)
        {
            Client client = GetClient(username);
            if (client != null && client.motdepasse == password)
            {
                client.action = DateTime.Now;
                if (ModifyClient(client))
                {
                    return client;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
