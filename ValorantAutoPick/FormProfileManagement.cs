using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValorantAutoPick
{
    public partial class FormProfileManagement : Form
    {
        public FormProfileManagement(FormMain parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        public FormMain parent;

        private void ButtonAddProfile_Click(object sender, EventArgs e)
        {
            using (var f = new FormAddProfile(this))
            {
                f.FormClosing += (s, a) => FillComboBox();
                f.ShowDialog();
            }
        }

        public void FillComboBox()
        {
            comboBoxProfiles.Items.Clear();
            comboBoxProfiles.Items.AddRange(parent.profiles.ToArray());
            if (comboBoxProfiles.Items.Count > 0)
                comboBoxProfiles.SelectedIndex = parent.config.FavoriteIndex;
        }

        private void FormProfileManagement_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void ButtonDeleteProfile_Click(object sender, EventArgs e)
        {
            if (comboBoxProfiles.Items.Count == 0)
            {
                MessageBox.Show("Error! Can't find any profiles!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            parent.profiles.Remove(comboBoxProfiles.SelectedItem as Profile);
            FillComboBox();
            MessageBox.Show("Succesfully Removed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonChangeProfile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var f = new FormChangeProfile(this, parent.profiles.IndexOf(comboBoxProfiles.SelectedItem as Profile)))
                {
                    f.FormClosing += (s, a) => FillComboBox();
                    f.ShowDialog();
                }
            }
            catch { MessageBox.Show("Error! Can't find any profiles!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ComboBoxProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            parent.config.FavoriteIndex = comboBoxProfiles.SelectedIndex;
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select profile in comboBox to manage.\n" +
                "Press Delete Profile to permanently delete record\n" +
                "Press Change Profile to open menu with profile settings\n" +
                "Press Add Profile to add new record",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
