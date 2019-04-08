using System;
using System.Windows.Forms;
using client.API;
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
            ClientAPI = new ClientAPI();
            FichierAPI = new FichierAPI();
            GroupeAPI = new GroupeAPI();
            InvitationAPI = new InvitationAPI();
        }

        protected ClientAPI ClientAPI { get; }
        protected FichierAPI FichierAPI { get; }
        protected GroupeAPI GroupeAPI { get; }
        protected InvitationAPI InvitationAPI { get; }

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