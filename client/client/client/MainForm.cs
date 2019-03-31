using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class MainForm : Form, ISynchronizable
    {
        private const int SYNCHRONIZATION_PERIOD = 5000;

        private readonly HomePanel _homePanel;
        private readonly GroupPanel _groupPanel;

        public enum Panel
        {
            Home,
            Groupe
        }

        private Panel _panel;

        public MainForm()
        {
            InitializeComponent();

            _homePanel = new HomePanel();
            _groupPanel = new GroupPanel();
            CurrentPanel = Panel.Groupe;

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
                        ActivePanel.Controls.Add(new HomePanel());
                        break;
                    case Panel.Groupe:
                        ActivePanel.Controls.Add(new GroupPanel());
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
