using serveur.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;

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

        private void GetInvitations()
        {
            var invites = Task.Run(() => InvitationAPI.GetInvitationsByClient(ActiveClient.id_client)).Result;
            if (invites == null)
            {
                DialogResult res = MessageBox.Show("La recherche des notifications a échoué.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                NotificationsListView.Invoke((MethodInvoker)delegate
                {
                    NotificationsListView.Items.Clear();
                    foreach (Invitation invite in invites)
                    {
                        var group = Task.Run(() => GroupeAPI.GetGroupById(invite.id_groupe_fk)).Result;
                        if (group == null)
                        {
                            DialogResult res = MessageBox.Show("La recherche du groupe a échoué.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            NotificationsListView.Invoke((MethodInvoker)delegate
                            {
                                string[] rows = { invite.id_invitation.ToString(), group.nom };
                                ListViewItem item = new ListViewItem(rows);
                                item.Name = invite.id_invitation.ToString();
                                if (!NotificationsListView.Items.ContainsKey(invite.id_invitation.ToString()))
                                {
                                    NotificationsListView.Items.Add(item);
                                }
                            });
                        }
                    }
                });
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
