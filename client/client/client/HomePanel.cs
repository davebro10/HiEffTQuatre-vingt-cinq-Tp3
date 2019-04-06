using System;
using System.Windows.Forms;
using System.Collections.Generic;
using serveur.Models;
using client.API;

namespace client
{
    public partial class HomePanel : UserControl, ISynchronizable
    {
        private MainForm mainFormRef;
        private ClientAPI clientAPI;
        private GroupeAPI groupeAPI;

        public HomePanel(MainForm reference)
        {
            mainFormRef = reference;
            clientAPI = new ClientAPI();
            groupeAPI = new GroupeAPI();

            InitializeComponent();
            updateClientName();

            Synchronize();
        }

        public void Synchronize()
        {
            fetchUserGroups();
            fetchConnectedUsers();
        }

        public void updateClientName() {
            NomClientLabel.Text = mainFormRef.ActiveClient != null ? mainFormRef.ActiveClient.nom : "Anonyme";
        }

        private async void fetchUserGroups()
        {
            // TODO: check groups where only the user is currently a member
            GroupesListView.Items.Clear();
            List<Groupe> groups = await groupeAPI.getAllGroups();
            if (groups != null)
            {
                foreach (Groupe group in groups)
                {
                    string[] rows = { group.id_groupe.ToString(), group.nom };
                    GroupesListView.Items.Add(new ListViewItem(rows));
                }
            }
        }

        private async void fetchConnectedUsers() {
            ClientsListView.Items.Clear();
            List<Client> clients = await clientAPI.getAllClients();
            if (clients != null) {
                foreach (Client client in clients)
                {
                    string[] rows = { client.nom };
                    ClientsListView.Items.Add(new ListViewItem(rows));
                }
            }
        }

        private void VoirGroupeButton_Click(object sender, System.EventArgs e)
        {
            // TODO: get group id and send group id to group panel
            if (GroupesListView.SelectedItems.Count == 1) {
                int selectedGroup = Int32.Parse(GroupesListView.SelectedItems[0].Text);
                mainFormRef.CurrentPanel = MainForm.Panel.Groupe;
            }
        }

        private void CreerButton_Click(object sender, System.EventArgs e)
        {
            string groupName = Prompt.ShowDialog("Nom du groupe:", "");
            if (groupName != "") {
                // TODO: get active client id to set them as admin
                int activeClientId = 1;
                groupeAPI.createGroup(groupName, activeClientId);
            }
        }

        private void notificationsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            mainFormRef.CurrentPanel = MainForm.Panel.Notification;
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
