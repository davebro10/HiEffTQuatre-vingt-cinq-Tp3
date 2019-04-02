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
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM client", bdd.Connection);
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

        private bool ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            MySqlTransaction tr = bdd.Connection.BeginTransaction();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = bdd.Connection;
                cmd.Transaction = tr;

                cmd.CommandText = query;
                foreach(var par in parameters)
                {
                    cmd.Parameters.AddWithValue(par.Key, par.Value);
                }

                if (cmd.ExecuteNonQuery() == 1)
                {
                    tr.Commit();
                    return true;
                }
                tr.Rollback();
                return false;
            }
        }

        private MySqlDataReader ExecuteReader(string query, Dictionary<string, object> parameters)
        {
            MySqlTransaction tr = bdd.Connection.BeginTransaction();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = bdd.Connection;
                cmd.Transaction = tr;

                cmd.CommandText = query;
                foreach (var par in parameters)
                {
                    cmd.Parameters.AddWithValue(par.Key, par.Value);
                }

                return cmd.ExecuteReader();
            }
        }

        public bool CreateClient(Client c)
        {
            string query = "INSERT INTO client(nom, usager, motdepasse, action) VALUES('@nom','@usager','@motdepasse','@action')";
            var dic = new Dictionary<string, object>
            {
                { "@nom", c.nom },
                { "@usager", c.usager },
                { "@motdepasse", c.motdepasse },
                { "@action", c.usager }
            };

            return ExecuteNonQuery(query, dic);
        }

        public bool ModifyClient(Client c)
        {
            string query = "UPDATE client SET nom='@nom', usager='@usager', motdepasse='@motdepasse', action='@action' WHERE id_client='@id_client'";
            var dic = new Dictionary<string, object>
            {
                { "@id_client", c.id_client },
                { "@nom", c.nom },
                { "@usager", c.usager },
                { "@motdepasse", c.motdepasse },
                { "@action", c.usager }
            };

            return ExecuteNonQuery(query, dic);
        }

        public bool DeleteClient(Client c)
        {
            string query = "DELETE FROM liste_groupe_client WHERE id_client='@id_client'";
            var dic = new Dictionary<string, object>
            {
                { "@id_client", c.id_client }
            };

            if(!ExecuteNonQuery(query, dic))
            {
                return false;
            }

            query = "DELETE FROM invitation WHERE id_client='@id_client'";
            if (!ExecuteNonQuery(query, dic))
            {
                return false;
            }

            query = "DELETE FROM client WHERE id_client='@id_client'";
            return ExecuteNonQuery(query, dic);
        }

        public Client GetClient(int id_client)
        {
            string query = "SELECT * FROM client WHERE id_client='@id_client'";
            var dic = new Dictionary<string, object>
            {
                { "@id_client", id_client }
            };

            var reader = ExecuteReader(query, dic);

            if(!reader.HasRows)
            {
                return null;
            }

            reader.Read();
            Client client = new Client
            {
                id_client = id_client,
                nom = reader.GetString("nom"),
                usager = reader.GetString("usager"),
                motdepasse = reader.GetString("motdepasse"),
                action = reader.GetDateTime("action")
            };

            return client;

        }

        public Client GetClient(string usager)
        {
            string query = "SELECT * FROM client WHERE usager='@usager'";
            var dic = new Dictionary<string, object>
            {
                { "@usager", usager }
            };

            var reader = ExecuteReader(query, dic);

            if (!reader.HasRows)
            {
                return null;
            }

            reader.Read();
            Client client = new Client
            {
                id_client = reader.GetInt32("id_client"),
                nom = reader.GetString("nom"),
                usager = usager,
                motdepasse = reader.GetString("motdepasse"),
                action = reader.GetDateTime("action")
            };

            return client;
        }

        public bool CreateGroup(Groupe g)
        {
            string query = "INSERT INTO groupe(admin, nom) VALUES('@admin','@nom')";
            var dic = new Dictionary<string, object>
            {
                { "@admin", g.admin },
                { "@nom", g.nom }
            };

            return ExecuteNonQuery(query, dic);
        }

        public bool ModifyGroup(Groupe g)
        {
            string query = "UPDATE groupe SET admin='@admin', nom='@nom' WHERE id_groupe='@id_groupe'";
            var dic = new Dictionary<string, object>
            {
                { "@id_groupe", g.id_groupe },
                { "@usager", g.admin },
                { "@nom", g.nom }
            };

            return ExecuteNonQuery(query, dic);
        }

        public bool DeleteGroup(Groupe g)
        {
            string query = "DELETE FROM liste_groupe_client WHERE id_groupe='@id_groupe'";
            var dic = new Dictionary<string, object>
            {
                { "@id_client", g.id_groupe }
            };

            if(!ExecuteNonQuery(query, dic))
            {
                return false;
            }

            query = "DELETE FROM invitation WHERE id_groupe='@id_groupe'";
            if (!ExecuteNonQuery(query, dic))
            {
                return false;
            }

            query = "DELETE FROM fichier WHERE id_groupe='@id_groupe'";
            if (!ExecuteNonQuery(query, dic))
            {
                return false;
            }

            query = "DELETE FROM groupe WHERE id_groupe='@id_groupe'";
            return ExecuteNonQuery(query, dic);
        }

        public Groupe GetGroupe(int id_groupe)
        {
            string query = "SELECT * FROM groupe WHERE id_groupe='@id_groupe'";
            var dic = new Dictionary<string, object>
            {
                { "@id_groupe", id_groupe }
            };

            var reader = ExecuteReader(query, dic);

            if (!reader.HasRows)
            {
                return null;
            }

            reader.Read();
            Groupe groupe = new Groupe
            {
                id_groupe = id_groupe,
                nom = reader.GetString("nom"),
                admin = reader.GetInt32("admin")
            };

            return groupe;
        }

        public bool CreateFile(Fichier file)
        {
            string query = "INSERT INTO fichier(id_groupe_fk, nom) VALUES('@id_groupe_fk','@nom')";
            var dic = new Dictionary<string, object>
            {
                { "@id_groupe_fk", file.id_groupe_fk },
                { "@nom", file.nom }
            };

            return ExecuteNonQuery(query, dic);
        }

        public bool ModifyFile(Fichier file)
        {
            string query = "UPDATE fichier SET id_groupe_fk='@id_groupe_fk', nom='@nom' WHERE id_fichier='@id_fichier'";
            var dic = new Dictionary<string, object>
            {
                { "@id_fichier", file.id_fichier },
                { "@id_groupe_fk", file.id_groupe_fk },
                { "@nom", file.nom }
            };

            return ExecuteNonQuery(query, dic);
        }

        public bool DeleteFile(Fichier file)
        {
            string query = "DELETE FROM fichier WHERE id_fichier='@id_fichier'";
            var dic = new Dictionary<string, object>
            {
                { "@id_fichier", file.id_fichier }
            };

            return ExecuteNonQuery(query, dic);
        }

        public bool InviteMemberToGroup(Groupe group, Client member)
        {
            string query = "INSERT INTO invitation(id_groupe, id_client) VALUES('@id_groupe','@id_client')";
            var dic = new Dictionary<string, object>
            {
                { "@id_groupe", group.id_groupe },
                { "@nom", member.id_client }
            };

            return ExecuteNonQuery(query, dic);
        }

        public bool DeleteInvitation(Invitation inv)
        {
            string query = "DELETE FROM invitation WHERE id_invitation='@id_invitation'";
            var dic = new Dictionary<string, object>
            {
                { "@id_invitation", inv.id_invitation }
            };

            return ExecuteNonQuery(query, dic);
        }

        public bool AddMemberToGroup(Groupe group, Client member)
        {
            string query = "INSERT INTO liste_groupe_client(id_client_fk, id_groupe_fk) VALUES('@id_client_fk','@id_groupe_fk')";
            var dic = new Dictionary<string, object>
            {
                { "@id_client_fk", member.id_client },
                { "@id_groupe_fk", group.id_groupe }
            };

            return ExecuteNonQuery(query, dic);
        }

        public bool RemoveMemberFromGroup(Groupe group, Client member)
        {
            string query = "DELETE FROM liste_groupe_client WHERE id_client_fk='@id_client_fk' AND id_groupe_fk='@id_groupe_fk'";
            var dic = new Dictionary<string, object>
            {
                { "@id_client_fk", member.id_client },
                { "@id_groupe_fk", group.id_groupe }
            };

            return ExecuteNonQuery(query, dic);
        }

        public bool SetGroupAdministrator(Groupe group, Client admin)
        {
            group.admin = admin.id_client;
            return ModifyGroup(group);
        }

        public bool InviteAnswer(Invitation inv, bool answer)
        {
            if(answer)
            {
                Client client = GetClient(inv.id_client_fk);
                Groupe group = GetGroupe(inv.id_groupe_fk);
                return AddMemberToGroup(group, client);
            }
            return true;
        }

        public bool Authentificate(string username, string password)
        {
            Client client = GetClient(username);
            return client != null && client.motdepasse == password;
        }

    }
}
