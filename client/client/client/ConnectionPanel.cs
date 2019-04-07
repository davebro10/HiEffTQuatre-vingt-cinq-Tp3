using client.API;
using serveur.Models;
using System;

namespace client
{
    public partial class ConnectionPanel : ApplicationPanel
    {
        private readonly ClientAPI _clientApi;

        public ConnectionPanel(MainForm parent)
            : base(parent)
        {
            _clientApi = new ClientAPI();
            InitializeComponent();
            ErrorMessage.Text = "";
        }

        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            Client tentativeClient = new Client();
            string user = UserTextBox.Text;
            string password = PasswordTextBox.Text;
            tentativeClient.usager = user;
            tentativeClient.motdepasse = password;
            Authenticate(tentativeClient);
        }

        private async void Authenticate(Client tentativeClient)
        {
            ErrorMessage.Text = "";
            Client authClient = await _clientApi.auth(tentativeClient);

            if (authClient != null)
            {
                // set as active client and change panel
                ActiveClient = authClient;
                ChangeActivePanel(MainForm.Panel.Home);
            }
            else
            {
                ErrorMessage.Text = "Informations de connexion erronées.";
                UserTextBox.Text = "";
                PasswordTextBox.Text = "";
                UserTextBox.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public override void Synchronize() { }
        
    }
}
