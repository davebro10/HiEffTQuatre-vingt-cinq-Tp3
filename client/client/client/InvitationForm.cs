using serveur.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace client
{
    public partial class InvitationForm : Form
    {
        public InvitationForm(List<Client> clientList = null)
        {
            InitializeComponent();

            ClientListView.DisplayMember = nameof(Client.usager);

            if (clientList != null)
                ClientList = clientList;
        }

        private void ConfirmButton_Click(object sender, System.EventArgs e)
        {
            CloseDialog(true);
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            CloseDialog(false);
        }

        private void CloseDialog(bool result)
        {
            DialogResult = result ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }

        public List<Client> ClientList
        {
            set
            {
                ClientListView.Items.Clear();
                foreach (var client in value)
                    ClientListView.Items.Add(client);
            }
        }

        public List<Client> SelectedClients
        {
            get
            {
                var selectedClients = new List<Client>();
                if (DialogResult == DialogResult.Cancel)
                    return selectedClients;

                foreach (var item in ClientListView.SelectedItems)
                {
                    if (!(item is Client client))
                        continue;

                    selectedClients.Add(client);
                }

                return selectedClients;
            }
        }
    }
}
