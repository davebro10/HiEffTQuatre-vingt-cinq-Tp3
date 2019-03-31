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

        private void addLog(String text)
        {
            lsbLog.Items.Add("[" + DateTime.Now.ToString("HH:mm") + "] " + text);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void btnAjouterClient_Click(object sender, EventArgs e)
        {
            FrmClient dlg = new FrmClient(new client());
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                _dbObj.client.Add(dlg._client);
                _dbObj.SaveChanges();
            }
        }

        private void btnModifierClient_Click(object sender, EventArgs e)
        {
            if ( (dataGridViewClient.SelectedRows.Count == 1))
            {
                DataGridViewRow row = dataGridViewClient.SelectedRows[0];
                client c = new client();
                c.id_client = (int)row.Cells["id_client"].Value;
                c.nom = (String)row.Cells["nom"].Value;
                c.usager = (String)row.Cells["usager"].Value;
                c.motdepasse = (String)row.Cells["motdepasse"].Value;

                FrmClient dlg = new FrmClient(c);
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    client cModif = _dbObj.client.First(i => i.id_client == dlg._client.id_client);
                    cModif.nom = dlg._client.nom;
                    cModif.usager = dlg._client.usager;
                    cModif.motdepasse = dlg._client.motdepasse;
                    _dbObj.SaveChanges();
                    MessageBox.Show("Client modifié");
                }
            }
            else
            {
                MessageBox.Show("Il faut sélectionner une ligne dans la grille de Client.");
            }
        }
    }
}
