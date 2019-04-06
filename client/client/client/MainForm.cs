using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using serveur.Models;

namespace client
{
    public partial class MainForm : Form, ISynchronizable
    {
        private const int SYNCHRONIZATION_PERIOD = 5000;

        private readonly HomePanel _homePanel;
        private readonly GroupPanel _groupPanel;
        private readonly ConnectionPanel _connectionPanel;
        private readonly NotificationsPanel _notificationsPanel;

        public Client ActiveClient { get; set; }
        
        public enum Panel
        {
            Home,
            Groupe,
            Connection,
            Notification
        }

        private Panel _panel;

        public MainForm()
        {
            InitializeComponent();

            _homePanel = new HomePanel(this);
            _groupPanel = new GroupPanel();
            _connectionPanel = new ConnectionPanel(this);
            _notificationsPanel = new NotificationsPanel();
            CurrentPanel = Panel.Connection;

            Task.Run(PeriodicSynchronization);
        }

        public Panel CurrentPanel
        {
            get => _panel;
            set
            {
                _panel = value;
                ActivePanel.Controls.Clear();
                switch (_panel)
                {
                    case Panel.Home:
                        ActivePanel.Controls.Add(new HomePanel(this));
                        break;
                    case Panel.Groupe:
                        ActivePanel.Controls.Add(new GroupPanel());
                        break;
                    case Panel.Connection:
                        ActivePanel.Controls.Add(new ConnectionPanel(this));
                        break;
                    case Panel.Notification:
                        ActivePanel.Controls.Add(new NotificationsPanel());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void SynchronizeNow_Click(object sender, EventArgs e) => Synchronize();

        public void Synchronize()
        {

            //TODO: Synchroniser les fichiers sur le disque

            switch (CurrentPanel)
            {
                case Panel.Home:
                    _homePanel.Synchronize();
                    break;
                case Panel.Groupe:
                    _groupPanel.Synchronize();
                    break;
                case Panel.Notification:
                    _notificationsPanel.Synchronize();
                    break;
                case Panel.Connection:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Task PeriodicSynchronization()
        {
            while (true)
            {
                Console.WriteLine(@"Synchronisation");
                Synchronize();
                Thread.Sleep(SYNCHRONIZATION_PERIOD);
            }
        }
    }
}
