using MemoryManipulator;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ValorantAutoPick
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
			RegisterHotKey(Handle, 1, 0, (int)Keys.F4);
			RegisterHotKey(Handle, 2, 0, (int)Keys.F6);
			var timerOverlayState = new System.Windows.Forms.Timer()
			{
				Interval = 200,
				Enabled = true,
			};
			timerOverlayState.Tick += TimerOverlayState_Tick;
		}

		private bool work = false;

		private Thread workThread;

		[DllImport("user32.dll")]
		public static extern void SetCursorPos(int x, int y);

		[DllImport("user32.dll")]
		static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

		[DllImport("User32.dll")]
		private static extern int RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

		public List<Profile> profiles = new List<Profile>();

		public Config config;

		private Process overlay;

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x0312)
			{
				switch (m.WParam.ToInt32())
				{
					case 1:
						ThreadTaskWork();
                        break;
					case 2:
						Memory.SetMemoryData("1".ToCharArray(), "vlr_overlay");
						break;
				}
			}
			base.WndProc(ref m);
		}

		private void ThreadTaskWork()
		{
            if (work)
            {
                workThread.Abort();
                Console.Beep(400, 125);
                work = !work;
            }
            else if (comboBoxProfiles.Items.Count > 0)
            {
				SetSelectedItemFromData();
                var character = (comboBoxProfiles.SelectedItem as Profile).CharacterLocation;
                var select = (comboBoxProfiles.SelectedItem as Profile).SelectLocation;
                workThread = new Thread(() => MainTask(character, select));
                workThread.Start();
                Console.Beep(1000, 125);
                work = !work;
            }
            else
                MessageBox.Show("Error! Can't find any profiles!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

		private void SetSelectedItemFromData()
		{
            comboBoxProfiles.SelectedIndex = Convert.ToInt32(Memory.GetMemoryMessage("vlr_index"));
        }

		private void MemoryData()
		{
			char[] message = string.Join("", profiles.Select(x => $"{x.Name}\n")).ToCharArray();
			Memory.SetMemoryData(message, "vlr_agents");
			Memory.SetMemoryData(comboBoxProfiles.SelectedIndex.ToString().ToCharArray(), "vlr_index");
		}

        private void TimerOverlayState_Tick(object sender, EventArgs e)
        {
			if (Memory.GetMemoryMessage("vlr_state") == "" || Memory.GetMemoryMessage("vlr_index") == "")
				return;
			SetSelectedItemFromData();
            ThreadTaskWork();
			Memory.SetMemoryData("".ToCharArray(), "vlr_state");
		}

		private void Mouse_Click()
		{
			mouse_event(0x00000002, Cursor.Position.X, Cursor.Position.Y, 0, 0);
			mouse_event(0x00000004, Cursor.Position.X, Cursor.Position.Y, 0, 0);
		}

		private void MainTask(Point character, Point select)
		{
			while (true)
				Task(character, select);
		}

        private void ButtonProfileManagement_Click(object sender, EventArgs e)
        {
			using (var f = new FormProfileManagement(this))
			{
				f.FormClosing += (s, a) => FillComboBox();
				f.ShowDialog();
			}
		}

		private void GetProfiles()
		{
			try
			{
				using (StreamReader reader = new StreamReader("profiles.json", false))
					profiles = JsonConvert.DeserializeObject<List<Profile>>(reader.ReadToEnd());
			}
			catch {  }
			if (profiles == null)
				profiles = new List<Profile>();
		}

		public void FillComboBox()
        {
			comboBoxProfiles.Items.Clear();
			comboBoxProfiles.Items.AddRange(profiles.ToArray());
			if (comboBoxProfiles.Items.Count > 0)
				comboBoxProfiles.SelectedIndex = config.FavoriteIndex;
			MemoryData();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
			GetConfig();
			GetProfiles();
			FillComboBox();
			OpenOverlay();
        }

		public void SaveProfiles()
		{
			try
			{
				using (StreamWriter writer = new StreamWriter($"profiles.json", false))
					writer.WriteLine(JsonConvert.SerializeObject(profiles).ToString());
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); }
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveProfiles();
			SaveConfig();
			try
			{
				overlay.Kill();
			}
			catch { }
		}

		private void Task(Point character, Point select)
        {
			SetCursorPos(character.X, character.Y);
			Thread.Sleep(config.Speed[0]);
			Mouse_Click();
			SetCursorPos(select.X, select.Y);
			Thread.Sleep(config.Speed[1]);
			Mouse_Click();
		}

		private void GetConfig()
		{
			try
			{
				using (StreamReader reader = new StreamReader("config.json", false))
					config = JsonConvert.DeserializeObject<Config>(reader.ReadToEnd());
			}
			catch { }
		}

		public void SaveConfig()
		{
			try
			{
				using (StreamWriter writer = new StreamWriter($"config.json", false))
					writer.WriteLine(JsonConvert.SerializeObject(new Config(config.FavoriteIndex, config.Speed)).ToString());
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); }
		}

        private void ComboBoxProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
			config.FavoriteIndex = comboBoxProfiles.SelectedIndex;
			MemoryData();
		}

		private void OpenOverlay()
		{
			overlay = new Process();
			overlay.StartInfo.FileName = "ValorantOverlay.exe";
			overlay.Start();
        }

		private void buttonInfo_Click(object sender, EventArgs e)
		{
            MessageBox.Show("Select profile in comboBox.\n" +
                "Press F4 to activate macross and press F4 again to deactivate.\n" +
                "F6 to open Overlay (works only in window/full screen window)\n" +
                "You can change profiles in Profile Management",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
	}
}
