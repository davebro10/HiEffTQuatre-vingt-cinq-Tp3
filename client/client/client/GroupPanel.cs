using serveur.Models;
using System.Linq;
using System.Text;
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
        }

        public override void Synchronize()
        {
            PromoteAdmin.Enabled = ActiveGroup?.admin == ActiveClient?.id_client;
            RemoveMember.Enabled = ActiveGroup?.admin == ActiveClient?.id_client;

            //
            var senddata = Encoding.ASCII.GetBytes("GROUPE" + ";" + MainForm.LAST_TIME_SYNC_CLIENTS);
            MainForm.UDPClient.Send(senddata, senddata.Length);

            var receiveBytes = MainForm.UDPClient.Receive(ref MainForm.IP_ENDPOINT);
            var returnData = Encoding.ASCII.GetString(receiveBytes);
            if (returnData != "YES")
                return;
            //

            Task.Run(SyncGroup);
            Task.Run(SyncFiles);
            Task.Run(SyncMembers);
        }

        private async Task SyncGroup()
        {
            GroupNameLabel.Text = ActiveGroup.nom;
            AdminNameLabel.Text = (await ClientAPI.GetClientById(ActiveGroup.admin)).usager;
        }

        private async Task SyncFiles()
        {
            var files = await FichierAPI.GetFilesFromGroup(ActiveGroup.id_groupe);
            if (files == null)
                return;

            FileListView.Invoke((MethodInvoker) delegate
            {
                FileListView.Clear();
                FileListView.Columns.Add("ID");
                FileListView.Columns.Add("Nom");
                foreach (var file in files)
                {
                    string[] rows = { file.id_fichier.ToString(), file.nom };
                    FileListView.Items.Add(new ListViewItem(rows));
                }
            });
        }

        private async Task SyncMembers()
        {
            var members = await InvitationAPI.GetGroupMembers(ActiveGroup.id_groupe);
            if (members == null)
                return;

            MemberListBox.Invoke((MethodInvoker) delegate
            {
                MemberListBox.Items.Clear();
                MemberListBox.DisplayMember = nameof(Client.usager);
                foreach (var member in members)
                    MemberListBox.Items.Add(member);
            });
        }

        private void Return_Click(object sender, System.EventArgs e) => ChangeActivePanel(MainForm.Panel.Home);

        private async void InviteButton_Click(object sender, System.EventArgs e)
        {
            var allClients = await ClientAPI.GetAllClients();
            var groupClients = await InvitationAPI.GetGroupMembers(ActiveGroup.id_groupe);

            var invitationForm = new InvitationForm(allClients.Where(c => !groupClients.Contains(c)).ToList());
            if (invitationForm.ShowDialog() != DialogResult.OK)
                return;

            foreach (var client in invitationForm.SelectedClients)
                await InvitationAPI.InviteMemberToGroupAsync(client.id_client, ActiveGroup.id_groupe);
        }

        private async void PromoteAdmin_Click(object sender, System.EventArgs e)
        {
            if (ActiveGroup.admin != ActiveClient.id_client)
                return;

            if (!(MemberListBox.SelectedItem is Client selectedClient))
                return;

            ActiveGroup.admin = selectedClient.id_client;
            await GroupeAPI.ModifyGroupAsync(ActiveGroup);
            Synchronize();
        }

        private async void RemoveMember_Click(object sender, System.EventArgs e)
        {
            if (ActiveGroup.admin != ActiveClient.id_client)
                return;

            if (!(MemberListBox.SelectedItem is Client selectedClient))
                return;

            await InvitationAPI.RemoveMemberToGroupAsync(selectedClient.id_client, ActiveGroup.id_groupe);
            Synchronize();
        }

        private async void Supprimer_Click(object sender, System.EventArgs e)
        {
            if (ActiveGroup.admin != ActiveClient.id_client)
                return;

            await GroupeAPI.DeleteGroupAsync(ActiveGroup);
            ChangeActivePanel(MainForm.Panel.Home);
        }
    }
}
