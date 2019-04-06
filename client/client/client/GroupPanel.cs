using System.Windows.Forms;

namespace client
{
    public partial class GroupPanel : UserControl, ISynchronizable
    {
        //public groupe SelectedGroup { get; set; }

        public GroupPanel()
        {
            //SelectedGroup = Service.LstGroupes[1];

            InitializeComponent();
            Synchronize();

            FileListView.Columns.Add("ID");
            FileListView.Columns.Add("Nom");
            FileListView.Columns.Add("Groupe ID");
        }

        public void Synchronize()
        {
            SyncGroup();
            SyncFiles();
            SyncMembers();
        }

        private void SyncGroup()
        {
            //GroupNameLabel.Text = SelectedGroup.nom;
            //AdminNameLabel.Text = SelectedGroup.admin.ToString();
        }

        private void SyncFiles()
        {
         /*   var files = Service.Lstfichiers;

            FileListView.Clear();
            foreach (var file in files)
            {
                string[] rows = { file.id_fichier.ToString(), file.nom, file.id_groupe_fk.ToString() };
                FileListView.Items.Add(new ListViewItem(rows));
            }
            */
        }

        private void SyncMembers()
        {
         /*   var members = Service.LstClients;

            MemberListBox.ClearSelected();
            foreach (var member in members)
            {
                MemberListBox.Items.Add(member.usager);
            }
            */
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
