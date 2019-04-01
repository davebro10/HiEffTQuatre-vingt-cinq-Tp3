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
    public partial class FrmClient : Form
    {
        public Client _client { get; set; }

        public FrmClient(Client _client)
        {
            this._client = _client;
            InitializeComponent();
            initFields();
        }

        private void initFields()
        {
            txbId.Text = _client.id_client.ToString();
            txbNom.Text = _client.nom;
            txbUsager.Text = _client.usager;
            txbMotDePasse.Text = _client.motdepasse;
        }

        private void txbOk_Click(object sender, EventArgs e)
        {
            _client.nom = txbNom.Text;
            _client.usager = txbUsager.Text;
            _client.motdepasse = txbMotDePasse.Text;
        }
    }
}
