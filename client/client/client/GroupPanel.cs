using serveur.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class GroupPanel : ApplicationPanel
    {
        public GroupPanel(MainForm parent)
            : base(parent)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            FileListView.Columns.Add("ID");
            FileListView.Columns.Add("Nom");
            FileListView.Columns.Add("Groupe ID");

            MemberListBox.DisplayMember = nameof(Client.usager);
        }

        public override void Synchronize()
        {
            PromoteAdmin.Enabled = ActiveGroup?.admin == ActiveClient?.id_client;
            RemoveMember.Enabled = ActiveGroup?.admin == ActiveClient?.id_client;

            SyncGroup();
            SyncFiles();
            SyncMembers();
        }

        private void SyncGroup()
        {
            GroupNameLabel.Text = ActiveGroup.nom;
            AdminNameLabel.Text = Task.Run(() => ClientAPI.GetClientById(ActiveGroup.admin)).Result.usager;
        }

        private void SyncFiles()
        {
            var files = Task.Run(() => FichierAPI.GetFilesFromGroup(ActiveGroup.id_groupe)).Result;
            if (files == null)
                return;

            FileListView.Invoke((MethodInvoker) delegate
            {
                FileListView.Clear();
                foreach (var file in files)
                {
                    string[] rows = { file.id_fichier.ToString(), file.nom, file.id_groupe_fk.ToString() };
                    FileListView.Items.Add(new ListViewItem(rows));
                }
            });
        }

        private void SyncMembers()
        {
            var members = Task.Run(() => InvitationAPI.GetGroupMembers(ActiveGroup.id_groupe)).Result;
            if (members == null)
                return;

            MemberListBox.Invoke((MethodInvoker) delegate
            {
                MemberListBox.Items.Clear();
                foreach (var member in members)
                    MemberListBox.Items.Add(member);
            });
        }

        private void Return_Click(object sender, System.EventArgs e) => ChangeActivePanel(MainForm.Panel.Home);

        private void InviteButton_Click(object sender, System.EventArgs e)
        {
            var allClients = Task.Run(() => ClientAPI.GetAllClients()).Result;
            var groupClients = Task.Run(() => InvitationAPI.GetGroupMembers(ActiveGroup.id_groupe)).Result;

            var invitationForm = new InvitationForm(allClients.Where(c => !groupClients.Contains(c)).ToList());
            if (invitationForm.ShowDialog() != DialogResult.OK)
                return;

            foreach (var client in invitationForm.SelectedClients)
                Task.Run(() => InvitationAPI.InviteMemberToGroupAsync(client.id_client, ActiveGroup.id_groupe));
        }

        private void PromoteAdmin_Click(object sender, System.EventArgs e)
        {
            if (ActiveGroup.admin != ActiveClient.id_client)
                return;

            if (!(MemberListBox.SelectedItem is Client selectedClient))
                return;

            Task.Run(() => GroupeAPI.ModifyGroupAsync(ActiveGroup));
        }

        private void RemoveMember_Click(object sender, System.EventArgs e)
        {
            if (ActiveGroup.admin != ActiveClient.id_client)
                return;

            if (!(MemberListBox.SelectedItem is Client selectedClient))
                return;

            Task.Run(() => InvitationAPI.RemoveMemberToGroupAsync(selectedClient.id_client, ActiveGroup.id_groupe));
        }

        private void Supprimer_Click(object sender, System.EventArgs e)
        {
            if (ActiveGroup.admin != ActiveClient.id_client)
                return;

            Task.Run(() => GroupeAPI.DeleteGroupAsync(ActiveGroup));
            ChangeActivePanel(MainForm.Panel.Home);
        }
    }
}
