using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValorantAutoPick
{
    public partial class FormAddProfile : Form
    {
		public FormAddProfile(FormProfileManagement parent)
        {
            InitializeComponent();

			this.parent = parent;
			RegisterHotKey(Handle, 5, 0, (int)Keys.F1);
			RegisterHotKey(Handle, 6, 0, (int)Keys.F2);
		}

		public FormProfileManagement parent;

		private Point characterLocation = new Point(0, 0);
        private Point selectLocation = new Point(0, 0);

		[DllImport("User32.dll")]
		private static extern int RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

		[DllImport("User32.dll")]
		private static extern int UnregisterHotKey(IntPtr hWnd, int id);

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x0312)
			{
				switch (m.WParam.ToInt32())
                {
					case 5: 
						characterLocation = Cursor.Position;
						labelCharacterLocation.Text = $"{characterLocation.X};{characterLocation.Y}";
						break;
					case 6:
						selectLocation = Cursor.Position;
						labelSelectLocation.Text = $"{selectLocation.X};{selectLocation.Y}";
						break;
				}
			}
			base.WndProc(ref m);
		}

		private void ButtonAddProfile_Click(object sender, EventArgs e)
        {
            if (characterLocation == new Point(0, 0) || selectLocation == new Point(0, 0) || textBoxName.Text.Trim() == "")
            {
                MessageBox.Show("Error! Select location and set profile name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            parent.parent.profiles.Add(
                new Profile(textBoxName.Text, characterLocation, selectLocation));
			MessageBox.Show("Succesfully Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			Close();
		}

        private void FormAddProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
			UnregisterHotKey(Handle, 5);
			UnregisterHotKey(Handle, 6);
		}

		private void buttonInfo_Click(object sender, EventArgs e)
		{
            MessageBox.Show("Enter profile name in textBox.\n" +
                "To select agent location move your cursor over agent and press F1.\n" +
                "To select button SELECT location move your cursor over that button and press F2.\n" +
                "After all press button Add Profile to save record.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
	}
}
