using serveur.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace client
{
    public partial class NotificationsPanel : ApplicationPanel
    {

        public NotificationsPanel(MainForm parent)
            : base(parent)
        {
            InitializeComponent();
        }

        public override void Synchronize()
        {
            GetInvitations();
        }

        private async void GetInvitations()
        {
            NotificationsListView.Items.Clear();
            int currentClientId = ActiveClient.id_client;
            List<Invitation> invites = await InvitationAPI.GetInvitationsByClient(currentClientId);
            if (invites != null)
            {
                foreach (Invitation invite in invites)
                {
                    Groupe g = await GroupeAPI.GetGroupById(invite.id_groupe_fk);
                    if (g != null)
                    {
                        string[] rows = { invite.id_invitation.ToString(), g.nom };
                        NotificationsListView.Items.Add(new ListViewItem(rows));
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("La recherche des groupes a échoué.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                DialogResult res = MessageBox.Show("La recherche des notifications a échoué.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void AcceptButton_ClickAsync(object sender, System.EventArgs e)
        {
            if (NotificationsListView.SelectedItems.Count == 1)
            {
                int invitationId = Int32.Parse(NotificationsListView.SelectedItems[0].Text);
                Invitation invite = new Invitation();
                invite.id_invitation = invitationId;
                await InvitationAPI.AnswerInviteAsync(invite, true);
            }
        }

        private async void DeclineButton_ClickAsync(object sender, System.EventArgs e)
        {
            if (NotificationsListView.SelectedItems.Count == 1) {
                int invitationId = Int32.Parse(NotificationsListView.SelectedItems[0].Text);
                Invitation invite = new Invitation();
                invite.id_invitation = invitationId;
                await InvitationAPI.AnswerInviteAsync(invite, false);
            }
        }

        private void BackButton_Click(object sender, System.EventArgs e)
        {
            ChangeActivePanel(MainForm.Panel.Home);
        }
    }
}
