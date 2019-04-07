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
        public Groupe ActiveGroup { get; set; }
        
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
            _groupPanel = new GroupPanel(this);
            _connectionPanel = new ConnectionPanel(this);
            _notificationsPanel = new NotificationsPanel(this);
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
                        ActivePanel.Controls.Add(_homePanel);
                        break;
                    case Panel.Groupe:
                        ActivePanel.Controls.Add(_groupPanel);
                        break;
                    case Panel.Connection:
                        ActivePanel.Controls.Add(_connectionPanel);
                        break;
                    case Panel.Notification:
                        ActivePanel.Controls.Add(_notificationsPanel);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Synchronize();
            }
        }

        private void SynchronizeNow_Click(object sender, EventArgs e) => Synchronize();

        public void Synchronize()
        {
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

        private void SynchronizeFiles()
        {
            //TODO: Synchroniser les fichiers sur le disque dur
        }

        public Task PeriodicSynchronization()
        {
            while (true)
            {
                Console.WriteLine(@"Synchronisation");
                Synchronize();
                SynchronizeFiles();
                Thread.Sleep(SYNCHRONIZATION_PERIOD);
            }
        }
    }
}
