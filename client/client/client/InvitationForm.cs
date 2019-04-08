using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using serveur.Models;

namespace client
{
    public partial class InvitationForm : Form
    {
        private List<Client> _clientList;

        public InvitationForm(List<Client> clientList = null)
        {
            InitializeComponent();

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
                _clientList = value;
                ClientListView.Items.Clear();
                foreach (var client in _clientList)
                    ClientListView.Items.Add(client.usager ?? client.nom ?? "UnClientDeTest");
            }
        }

        public List<Client> SelectedClients
        {
            get
            {
                var selectedClients = new List<Client>();
                if (DialogResult == DialogResult.Cancel)
                    return selectedClients;

                selectedClients.AddRange(_clientList.Where(c => ClientListView.SelectedItems.Contains(c.usager)));
                return selectedClients;
            }
        }
    }
}
