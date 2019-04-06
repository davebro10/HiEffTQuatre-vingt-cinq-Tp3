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
using Microsoft.Owin.Hosting;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IO;

namespace serveur
{
    public partial class frmMain : Form
    {
        private API _api;

        public frmMain()
        {
            InitializeComponent();
            _api = new API();

            string baseAddress = "http://localhost:10281/";

            // Start OWIN host
            var webapp = WebApp.Start<Startup>(url: baseAddress);

            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync(baseAddress + "api/client/getallclient").Result;

            Console.WriteLine(response);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);

            //webapp.Dispose();

            Directory.CreateDirectory("groupfiles");

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

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string baseAddress = "http://localhost:10281/";

            /* //Exemple GET
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseAddress + "api/client/getallclient").Result;

            Console.WriteLine(response);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            */

            /* //Exemple POST d'un Client
            Client c = new Client();
            c.nom = "test1";
            c.usager = "test2";
            c.motdepasse = "test3";
            c.action = DateTime.Now;

            HttpClient client = new HttpClient();
            var jsonObj = JsonConvert.SerializeObject(c);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObj);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = client.PostAsync(baseAddress + "api/client/createclient", byteContent).Result;

            Console.WriteLine(response);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            */

        }
    }
}
