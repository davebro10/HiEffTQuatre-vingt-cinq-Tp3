using System;
using System.Windows.Forms;
using serveur.Models;

namespace client
{
    public partial class ConnectionPanel : UserControl
    {
        private MainForm mainFormReference;

        public ConnectionPanel(MainForm reference)
        {
            mainFormReference = reference;
            InitializeComponent();
        }

        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            Client tentativeClient = new Client();

            string user = UserTextBox.Text;
            string password = PasswordTextBox.Text;

            // TODO: connect to database to check data

            if (user != "" && password != "" && user == password)
            {
                // fill up client info
                tentativeClient.nom = UserTextBox.Text;
                tentativeClient.motdepasse = PasswordTextBox.Text;

                // set as active client and change panel
                mainFormReference.ActiveClient = tentativeClient;
                mainFormReference.CurrentPanel = MainForm.Panel.Home;
            }
            else {
                // TODO: show error message
            }
        }
    }
}
