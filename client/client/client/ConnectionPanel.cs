using System;
using System.Windows.Forms;
using serveur.Models;
using client.API;

namespace client
{
    public partial class ConnectionPanel : UserControl
    {
        private MainForm mainFormReference;
        private ClientAPI clientAPI;

        public ConnectionPanel(MainForm reference)
        {
            mainFormReference = reference;
            clientAPI = new ClientAPI();
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
            authenticate(tentativeClient);
        }

        private async void authenticate(Client tentativeClient) {
            ErrorMessage.Text = "";
            Client authClient = await clientAPI.auth(tentativeClient);

            if (authClient != null)
            {
                // set as active client and change panel
                mainFormReference.ActiveClient = authClient;
                mainFormReference.CurrentPanel = MainForm.Panel.Home;
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
    }
}
