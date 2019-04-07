using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using serveur.Models;
using client.API;

namespace client
{
    public partial class HomePanel : ApplicationPanel
    {
        private readonly ClientAPI _clientApi;
        private readonly GroupeAPI _groupeApi;
        private readonly InvitationAPI _invitationApi;

        public HomePanel(MainForm parent)
            : base(parent)
        {
            _clientApi = new ClientAPI();
            _groupeApi = new GroupeAPI();
            _invitationApi = new InvitationAPI();

            InitializeComponent();
            UpdateClientName();

            Synchronize();
        }

        public override void Synchronize()
        {
            FetchUserGroups();
            FetchConnectedUsers();
        }

        public void UpdateClientName()
        {
            Client activeClient = ActiveClient;
            NomClientLabel.Text = activeClient != null && activeClient.nom != null ? activeClient.nom : "Anonyme";
        }

        private async Task FetchUserGroups()
        {
            GroupesListView.Items.Clear();
            List<Groupe> groups = await _groupeApi.getAllGroups();
            if (groups != null)
            {
                foreach (Groupe group in groups)
                {
                    Client activeClient = ActiveClient;
                    List<Client> members = await _invitationApi.getGroupMembers(group.id_groupe);
                    if (activeClient != null && (members.Contains(activeClient) || group.admin == activeClient.id_client))
                    {
                        string[] rows = { group.id_groupe.ToString(), group.nom };
                        GroupesListView.Items.Add(new ListViewItem(rows));
                    }
                }
            }
            else
            {
                DialogResult res = MessageBox.Show("La recherche des groupes a échoué", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task FetchConnectedUsers()
        {
            ClientsListView.Items.Clear();
            List<Client> clients = await _clientApi.getAllClients();
            if (clients != null)
            {
                foreach (Client client in clients)
                {
                    DateTime now = DateTime.Now;
                    DateTime tenMinutesFromNow = now.AddMinutes(10);
                    bool isConnected = client.action != null && client.action < tenMinutesFromNow;
                    string status = isConnected ? "En ligne" : "Hors ligne";
                    string[] rows = { client.nom, status };
                    ClientsListView.Items.Add(new ListViewItem(rows));
                }
            }
            else
            {
                DialogResult res = MessageBox.Show("La recherche des utilisateurs a échoué", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void VoirGroupeButton_Click(object sender, System.EventArgs e)
        {
            if (GroupesListView.SelectedItems.Count == 1)
            {
                int selectedGroup = Int32.Parse(GroupesListView.SelectedItems[0].Text);
                // TODO: get group id and send group id to group panel
                ChangeActivePanel(MainForm.Panel.Groupe);
            }
            else
            {
                DialogResult res = MessageBox.Show("Veuillez sélectionner un groupe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void CreerButton_ClickAsync(object sender, System.EventArgs e)
        {
            string groupName = Prompt.ShowDialog("Nom du groupe:", "");
            if (groupName != "")
            {
                int activeClientId = ActiveClient.id_client;
                await _groupeApi.createGroup(groupName, activeClientId);
                // TODO : open group panel with group id??
            }
            else
            {
                DialogResult res = MessageBox.Show("Veuillez saisir un nom pour le groupe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void notificationsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ChangeActivePanel(MainForm.Panel.Notification);
        }

        private void ClientsListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    // Prompt code credit: https://stackoverflow.com/questions/5427020/prompt-dialog-in-windows-forms
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
