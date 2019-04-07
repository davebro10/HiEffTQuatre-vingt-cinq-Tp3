using System;
using System.Windows.Forms;
using serveur.Models;

namespace client
{
#if DEBUG
    public class ApplicationPanel : UserControl, ISynchronizable
#else
    public abstract class ApplicationPanel : UserControl, ISynchronizable
#endif
    {
        private readonly MainForm _parent;

        protected ApplicationPanel(MainForm parent)
        {
            _parent = parent;
        }

#if DEBUG
        [Obsolete("Designer Only", true)]
        public ApplicationPanel() { }

        public virtual void Synchronize() { }
#else
        public abstract void Synchronize();
#endif

        protected Client ActiveClient
        {
            get => _parent.ActiveClient;
            set => _parent.ActiveClient = value;
        }

        protected Groupe ActiveGroup
        {
            get => _parent.ActiveGroup;
            set => _parent.ActiveGroup = value;
        }

        protected void ChangeActivePanel(MainForm.Panel panel) => _parent.CurrentPanel = panel;
    }
}