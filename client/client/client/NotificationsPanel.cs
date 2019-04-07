using System.Windows.Forms;
using System.Collections.Generic;
using System;
using client.API;
using serveur.Models;

namespace client
{
    public partial class NotificationsPanel : UserControl, ISynchronizable
    {
        private MainForm mainFormRef;
        private InvitationAPI invitationAPI;
        private GroupeAPI groupeAPI;

        public NotificationsPanel(MainForm reference)
        {
            mainFormRef = reference;
            InitializeComponent();
        }

        public void Synchronize()
        {
            getInvitations();
        }

        private async void getInvitations()
        {
            NotificationsListView.Items.Clear();
            int currentClientId = mainFormRef.ActiveClient.id_client;
            List<Invitation> invites = await invitationAPI.getInvitationsByClient(currentClientId);
            if (invites != null)
            {
                foreach (Invitation invite in invites)
                {
                    Groupe g = await groupeAPI.getGroupById(invite.id_groupe_fk);
                    if (g != null) {
                        string[] rows = { invite.id_invitation.ToString(), g.nom };
                        NotificationsListView.Items.Add(new ListViewItem(rows));
                    }
                }
            }
        }

        private async void AcceptButton_ClickAsync(object sender, System.EventArgs e)
        {
            if (NotificationsListView.SelectedItems.Count == 1)
            {
                int invitationId = Int32.Parse(NotificationsListView.SelectedItems[0].Text);
                Invitation invite = new Invitation();
                invite.id_invitation = invitationId;
                await invitationAPI.answerInviteAsync(invite, true);
            }
        }

        private async void DeclineButton_ClickAsync(object sender, System.EventArgs e)
        {
            if (NotificationsListView.SelectedItems.Count == 1) {
                int invitationId = Int32.Parse(NotificationsListView.SelectedItems[0].Text);
                Invitation invite = new Invitation();
                invite.id_invitation = invitationId;
                await invitationAPI.answerInviteAsync(invite, false);
            }
        }

        private void BackButton_Click(object sender, System.EventArgs e)
        {
            mainFormRef.CurrentPanel = MainForm.Panel.Home;
        }
    }
}
