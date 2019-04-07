﻿using System;
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
        private InvitationAPI invitationAPI;

        public HomePanel(MainForm reference)
        {
            mainFormRef = reference;
            clientAPI = new ClientAPI();
            groupeAPI = new GroupeAPI();
            invitationAPI = new InvitationAPI();

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
            Client activeClient = mainFormRef.ActiveClient;
            NomClientLabel.Text = activeClient != null && activeClient.nom != null ? activeClient.nom : "Anonyme";
        }

        private async void fetchUserGroups()
        {
            GroupesListView.Items.Clear();
            List<Groupe> groups = await groupeAPI.getAllGroups();
            if (groups != null)
            {
                foreach (Groupe group in groups)
                {
                    Client activeClient = mainFormRef.ActiveClient;
                    List<Client> members = await invitationAPI.getGroupMembers(group.id_groupe);
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

        private async void fetchConnectedUsers() {
            ClientsListView.Items.Clear();
            List<Client> clients = await clientAPI.getAllClients();
            if (clients != null) {
                foreach (Client client in clients)
                {
                    string status = client.action != null ? "En ligne" : "Hors ligne";
                    string[] rows = { client.nom, status };
                    ClientsListView.Items.Add(new ListViewItem(rows));
                }
            }
            else
            {
                DialogResult res = MessageBox.Show("La recherche des utilisateurs connectés a échoué", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void VoirGroupeButton_Click(object sender, System.EventArgs e)
        {
            if (GroupesListView.SelectedItems.Count == 1)
            {
                int selectedGroup = Int32.Parse(GroupesListView.SelectedItems[0].Text);
                // TODO: get group id and send group id to group panel
                mainFormRef.CurrentPanel = MainForm.Panel.Groupe;
            }
            else
            {
                DialogResult res = MessageBox.Show("Veuillez sélectionner un groupe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void CreerButton_ClickAsync(object sender, System.EventArgs e)
        {
            string groupName = Prompt.ShowDialog("Nom du groupe:", "");
            if (groupName != "") {
                int activeClientId = mainFormRef.ActiveClient.id_client;
                await groupeAPI.createGroup(groupName, activeClientId);
                // TODO : open group panel with group id??
            }
            else
            {
                DialogResult res = MessageBox.Show("Veuillez saisir un nom pour le groupe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void notificationsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            mainFormRef.CurrentPanel = MainForm.Panel.Notification;
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
