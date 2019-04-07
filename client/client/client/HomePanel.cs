using client.API;
using serveur.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        public override void Synchronize()
        {
            NomClientLabel.Text = ActiveClient?.nom ?? "Anonyme";
            SyncUserGroups();
            SyncConnectedUsers();
        }

        private void SyncUserGroups()
        {
            var allGroups = Task.Run(() => _groupeApi.getAllGroups()).Result;
            if (allGroups == null)
                return;

            var activeClientGroups = new List<Groupe>();
            foreach (var group in allGroups)
            {
                var members = Task.Run(() => _invitationApi.getGroupMembers(group.id_groupe)).Result;
                if (ActiveClient == null || !members.Contains(ActiveClient) && @group.admin != ActiveClient.id_client)
                    continue;

                activeClientGroups.Add(group);
            }

            GroupesListView?.Invoke((MethodInvoker) delegate
            {
                GroupesListView.Items.Clear();
                foreach (var group in activeClientGroups)
                {
                    string[] rows = { group.id_groupe.ToString(), group.nom };
                    GroupesListView.Items.Add(new ListViewItem(rows));
                }
            });
        }

        private void SyncConnectedUsers()
        {
            var allClients = Task.Run(() => _clientApi.getAllClients()).Result;
            if (allClients == null)
                return;

            ClientsListView.Invoke((MethodInvoker) delegate
            {
                foreach (var client in allClients)
                {
                    var tenMinutesFromNow = DateTime.Now.AddMinutes(10);
                    var status = client.action != null && client.action < tenMinutesFromNow
                        ? "En ligne"
                        : "Hors ligne";
                    string[] rows = { client.nom, status };
                    ClientsListView.Items.Add(new ListViewItem(rows));
                }
            });
        }

        private void VoirGroupeButton_Click(object sender, System.EventArgs e) => Task.Run(() => VoirGroupe(sender, e));

        private async Task VoirGroupe(object sender, System.EventArgs e)
        {
            if (GroupesListView.SelectedItems.Count == 1)
            {
                int selectedGroup = Int32.Parse(GroupesListView.SelectedItems[0].Text);
                ActiveGroup = await _groupeApi.getGroupById(selectedGroup);
                ChangeActivePanel(MainForm.Panel.Groupe);
            }
            else
            {
                DialogResult res = MessageBox.Show("Veuillez sélectionner un groupe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void CreerButton_ClickAsync(object sender, System.EventArgs e) => Task.Run(() => CreerGroupe(sender, e));

        private async Task CreerGroupe(object sender, System.EventArgs e)
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
