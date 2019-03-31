using System.Windows.Forms;

namespace client
{
    public partial class GroupPanel : UserControl, ISynchronizable
    {
        public GroupPanel()
        {
            InitializeComponent();
            Synchronize();
        }

        public void Synchronize()
        {
            var fichiers = Service.Lstfichiers;

            //FileListView.Clear();
            //foreach (var file in fichiers)
            //{
            //    FileListView.Items.Add()
            //}
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
