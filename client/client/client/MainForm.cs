using client.API;
using serveur.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class MainForm : Form, ISynchronizable
    {
        private const int SYNCHRONIZATION_PERIOD = 5000;
        private const int UDP_PORT = 10282;

        private readonly HomePanel _homePanel;
        private readonly GroupPanel _groupPanel;
        private readonly ConnectionPanel _connectionPanel;
        private readonly NotificationsPanel _notificationsPanel;

        private string ClientDirectoryName => $"..\\..\\..\\..\\{ActiveClient.usager}";
        public Client ActiveClient { get; set; }
        public Groupe ActiveGroup { get; set; }
        protected FichierAPI FichierAPI { get; }


        public static DateTime LAST_TIME_SYNC_CLIENTS { get; set; }
        public static DateTime LAST_TIME_SYNC_FILES { get; set; }
        public static DateTime LAST_TIME_SYNC_GROUPS { get; set; }
        public static DateTime LAST_TIME_SYNC_NOTIFS { get; set; }
        public static UdpClient UDPClient = new UdpClient();
        public static IPEndPoint IP_ENDPOINT = new IPEndPoint(IPAddress.Any, 0);

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
            UDPClient.Connect("localhost", UDP_PORT);
            FichierAPI = new FichierAPI();

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
                    _connectionPanel.Synchronize();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async void SynchronizeFiles()
        {
            if (ActiveClient == null)
                return;

            if (!Directory.Exists(ClientDirectoryName))
                Directory.CreateDirectory(ClientDirectoryName);

            var directories = Directory.GetDirectories(ClientDirectoryName);
            foreach (var directory in directories)
            {
                var directoryInfo = new DirectoryInfo(directory);
                var sendData = Encoding.ASCII.GetBytes("SENDFICHIER" + ";" + directoryInfo.LastWriteTime);
                UDPClient.Send(sendData, sendData.Length);

                var receiveBytes = UDPClient.Receive(ref IP_ENDPOINT);
                if (Encoding.ASCII.GetString(receiveBytes) != "YES")
                    continue;

                var resultString = Regex.Match(directory, @"\d+").Value;
                var groupId = int.Parse(resultString);
                foreach (var file in Directory.GetFiles(directory))
                {
                    var parse = file.Split('\\');
                    await FichierAPI.Upload(File.ReadAllBytes(file), parse[2], groupId);
                }
            }


            /*Byte[] senddata = Encoding.ASCII.GetBytes("SENDFICHIER" + ";" + LAST_TIME_SYNC_FILES);
            UDPClient.Send(senddata, senddata.Length);

            Byte[] receiveBytes = UDPClient.Receive(ref IP_ENDPOINT);
            string returnData = Encoding.ASCII.GetString(receiveBytes);
            if (returnData == "YES")
            {

                //SyncConnectedUsers();
                //MainForm.LAST_TIME_SYNC_CLIENTS = DateTime.Now;
                //SyncUserGroups();
            }*/

            //byte[] bytes = File.ReadAllBytes("dave/heroes.jpg");

            //await FichierAPI.Upload(bytes, "heroes.jpg", 1);
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
