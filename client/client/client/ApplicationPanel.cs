using System.Windows.Forms;
using serveur.Models;

namespace client
{
    public abstract class ApplicationPanel : UserControl, ISynchronizable
    {
        private readonly MainForm _parent;

        protected ApplicationPanel(MainForm parent)
        {
            _parent = parent;
        }

        public abstract void Synchronize();

        protected Client ActiveClient
        {
            get => _parent.ActiveClient;
            set => _parent.ActiveClient = value;
        }

        protected void ChangeActivePanel(MainForm.Panel panel) => _parent.CurrentPanel = panel;
    }
}