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
        }

        public override void Synchronize()
        {
            SyncGroup();
            SyncFiles();
            SyncMembers();
        }

        private void SyncGroup()
        {
            GroupNameLabel.Text = ActiveGroup.nom;
            AdminNameLabel.Text = ActiveGroup.admin.ToString();
        }

        private void SyncFiles()
        {
            var files = Task.Run(() => FichierAPI.GetFilesFromGroup(ActiveGroup)).Result;
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
                MemberListBox.ClearSelected();
                foreach (var member in members)
                    MemberListBox.Items.Add(member.usager);
            });
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {

        }

        private void ModifyButton_Click(object sender, System.EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, System.EventArgs e)
        {

        }

        private void InviteButton_Click(object sender, System.EventArgs e)
        {

        }
    }
}
