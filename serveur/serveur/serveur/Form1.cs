using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serveur
{
    public partial class frmMain : Form
    {
        minedexf_tp3Entities _dbObj;

        public frmMain()
        {
            InitializeComponent();
            _dbObj = new minedexf_tp3Entities();
            //initConnection();
            refreshGrid();
        }

        private void refreshGrid()
        {
            dataGridViewClient.DataSource = _dbObj.client.ToList();
            dataGridViewGroupe.DataSource = _dbObj.groupe.ToList();
            dataGridViewInvitation.DataSource = _dbObj.invitation.ToList();
        }

        /*
        private void initConnection()
        {
            string connStr = "server=ni-web-01.srv.nihost.fr;user=minedexf_utp3;database=minedexf_tp3;port=3306;password=!TP3BD18!";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                addLog("Connexion à la base de donnée en cours...");
                conn.Open();
                // Perform database operations
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            addLog("Connexion à la base de donnée réussie.");
        }
        */

        private void addLog(String text)
        {
            lsbLog.Items.Add("["+DateTime.Now.ToString("HH:mm")+"] " + text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TEST
            client client = new client();
            client.nom = "test2";

            _dbObj.client.Add(client);
            _dbObj.SaveChanges();
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            client client = _dbObj.client.First(i => i.nom == "test2");
            client.nom = "testModif";
            _dbObj.SaveChanges();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }
    }
}
