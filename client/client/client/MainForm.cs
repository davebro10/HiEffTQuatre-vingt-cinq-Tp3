using System;
using System.Windows.Forms;

namespace client
{
    public partial class MainForm : Form
    {
        public enum Panel
        {
            Home,
            Groupe
        }

        private Panel _panel;

        public MainForm()
        {
            InitializeComponent();
            CurrentPanel = Panel.Groupe;
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
                        ActivePanel.Controls.Add(new GroupePanel());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }


    }
}
