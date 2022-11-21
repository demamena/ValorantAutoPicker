using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValorantAutoPick
{
    public partial class FormChangeProfile : Form
    {
        FormProfileManagement parent;

        int profileId;

        public FormChangeProfile(FormProfileManagement parent, int profileId)
        {
            InitializeComponent();
            
            this.parent = parent;
            this.profileId = profileId;
            characterLocation = parent.parent.profiles[profileId].CharacterLocation;
            selectLocation = parent.parent.profiles[profileId].SelectLocation;

            RegisterHotKey(Handle, 7, 0, (int)Keys.F1);
            RegisterHotKey(Handle, 8, 0, (int)Keys.F2);
        }

        private Point characterLocation;
        private Point selectLocation;

        [DllImport("User32.dll")]
        private static extern int RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                switch (m.WParam.ToInt32())
                {
                    case 7:
                        characterLocation = Cursor.Position;
                        labelCharacterLocation.Text = $"{characterLocation.X};{characterLocation.Y}";
                        break;
                    case 8:
                        selectLocation = Cursor.Position;
                        labelSelectLocation.Text = $"{selectLocation.X};{selectLocation.Y}";
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private void ButtonAddProfile_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonChangeProfile_Click(object sender, EventArgs e)
        {
            if (characterLocation == new Point(0, 0) || selectLocation == new Point(0, 0) || textBoxName.Text.Trim() == "")
            {
                MessageBox.Show("Error! Select location and set profile name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetNewData();
            MessageBox.Show("Succesfully Changed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void FormChangeProfile_Load(object sender, EventArgs e)
        {
            FillProfileData();
        }

        private void SetNewData()
        {
            parent.parent.profiles[profileId].Name = textBoxName.Text;
            parent.parent.profiles[profileId].CharacterLocation = characterLocation;
            parent.parent.profiles[profileId].SelectLocation = selectLocation;
        }

        private void FillProfileData()
        {
            textBoxName.Text = parent.parent.profiles[profileId].Name;
            labelCharacterLocation.Text = $"{parent.parent.profiles[profileId].CharacterLocation.X};" +
                $"{parent.parent.profiles[profileId].CharacterLocation.Y}";
            labelSelectLocation.Text = $"{parent.parent.profiles[profileId].SelectLocation.X};" +
                $"{parent.parent.profiles[profileId].SelectLocation.Y}";
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter new profile name in textBox.\n" +
                "To select agent location move your cursor over agent and press F1.\n" +
                "To select button SELECT location move your cursor over that button and press F2.\n" +
                "After press button Change Profile to apply changes.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
