using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class ConnectionPanel : UserControl
    {
        public ConnectionPanel()
        {
            InitializeComponent();
        }

        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            // TODO: connect to database to check data
            if (UserTextBox.Text != "" && PasswordTextBox.Text != ""
                && UserTextBox.Text == PasswordTextBox.Text) {
                // MainForm.CurrentPanel = MainForm.Panel.Home;
            }
        }
    }
}
