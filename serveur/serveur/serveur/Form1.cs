using MySql.Data.MySqlClient;
using serveur.Models;
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
        private API _api;

        public frmMain()
        {
            InitializeComponent();
            _api = new API();
            refreshGrid();
        }

        private void refreshGrid()
        {
            dataGridViewClient.DataSource = _api.GetAllClient();
            //dataGridViewGroupe.DataSource = _dbObj.groupe.ToList();
            //dataGridViewInvitation.DataSource = _dbObj.invitation.ToList();
        }

        private void addLog(String text)
        {
            lsbLog.Items.Add("[" + DateTime.Now.ToString("HH:mm") + "] " + text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void btnAjouterClient_Click(object sender, EventArgs e)
        {
            FrmClient dlg = new FrmClient(new Client());
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
               // _dbObj.client.Add(dlg._client);
               // _dbObj.SaveChanges();
            }
        }

        private void btnModifierClient_Click(object sender, EventArgs e)
        {
            if ( (dataGridViewClient.SelectedRows.Count == 1))
            {
                DataGridViewRow row = dataGridViewClient.SelectedRows[0];
                Client c = new Client();
                c.id_client = (int)row.Cells["id_client"].Value;
                c.nom = (String)row.Cells["nom"].Value;
                c.usager = (String)row.Cells["usager"].Value;
                c.motdepasse = (String)row.Cells["motdepasse"].Value;

                FrmClient dlg = new FrmClient(c);
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    //dlg._client;
                    //MessageBox.Show("Client modifié");
                }
            }
            else
            {
                MessageBox.Show("Il faut sélectionner une ligne dans la grille de Client.");
            }
        }
    }
}
