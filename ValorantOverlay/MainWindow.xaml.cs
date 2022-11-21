using MemoryManipulator;

using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

using MessageBox = System.Windows.MessageBox;

namespace ValorantOverlay
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillComboBox();
            Timer timerTray = new Timer() { Enabled = true, Interval = 200 };
            timerTray.Tick += TimerTray_Tick;
        }

        private bool state;

        private void TimerTray_Tick(object sender, EventArgs e)
        {
            if (Memory.GetMemoryMessage("vlr_overlay") == "")
                return;
            TrayOverlay();
            Memory.SetMemoryData("".ToCharArray(), "vlr_overlay");
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            state = !state;
            Memory.SetMemoryData(comboBoxAgents.SelectedIndex.ToString().ToCharArray(), "vlr_index");
            Memory.SetMemoryData(Convert.ToInt32(state).ToString().ToCharArray(), "vlr_state");
        }

        private void FillComboBox()
        {
            try
            {
                comboBoxAgents.Items.Clear();
                Memory.GetMemoryMessage("vlr_agents").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList().ForEach(agent => { comboBoxAgents.Items.Add(agent); });
                comboBoxAgents.SelectedIndex = Convert.ToInt32(Memory.GetMemoryMessage("vlr_index"));
            }
            catch { }
        }

        private void TrayOverlay()
        {
            if (Visibility == Visibility.Visible)
            {
                Visibility = Visibility.Hidden;
                return;
            }
            Visibility = Visibility.Visible;
            FillComboBox();
        }

        private void comboBoxAgents_DropDownClosed(object sender, EventArgs e)
        {
            Memory.SetMemoryData(comboBoxAgents.SelectedIndex.ToString().ToCharArray(), "vlr_index");
        }
    }
}
