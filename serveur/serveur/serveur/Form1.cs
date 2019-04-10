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

using System.Threading;

namespace serveur
{
    public partial class frmMain : Form
    {
        private API _api;

        public frmMain()
        {
            API.LAST_TIME_SYNC_CLIENTS = DateTime.Now;
            API.LAST_TIME_SYNC_FILES = DateTime.Now;
            API.LAST_TIME_SYNC_GROUPS = DateTime.Now;
            API.LAST_TIME_SYNC_NOTIFS = DateTime.Now;

            UDP udpClient = new UDP();
            udpClient.Start();

            InitializeComponent();
            _api = new API();

            string baseAddress = "http://localhost:10281/";
            // Start OWIN host
            var webapp = WebApp.Start<Startup>(url: baseAddress);
            //webapp.Dispose();

            Directory.CreateDirectory("groupfiles");

            refreshGrid();
        }


        private void refreshGrid()
        {
            dataGridViewClient.DataSource = _api.GetAllClient();
            dataGridViewGroupe.DataSource = _api.GetAllGroup();
            dataGridViewInvitation.DataSource = _api.GetAllInvitation();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }
    }
}
