namespace ValorantAutoPick
{
    partial class FormChangeProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChangeProfile));
            this.labelSelectLocation = new System.Windows.Forms.Label();
            this.buttonChangeProfile = new System.Windows.Forms.Button();
            this.labelCharacterLocation = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSelectLocation
            // 
            this.labelSelectLocation.AutoSize = true;
            this.labelSelectLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSelectLocation.Location = new System.Drawing.Point(282, 71);
            this.labelSelectLocation.Name = "labelSelectLocation";
            this.labelSelectLocation.Size = new System.Drawing.Size(52, 31);
            this.labelSelectLocation.TabIndex = 7;
            this.labelSelectLocation.Text = "0;0";
            // 
            // buttonChangeProfile
            // 
            this.buttonChangeProfile.Location = new System.Drawing.Point(81, 92);
            this.buttonChangeProfile.Name = "buttonChangeProfile";
            this.buttonChangeProfile.Size = new System.Drawing.Size(99, 35);
            this.buttonChangeProfile.TabIndex = 6;
            this.buttonChangeProfile.Text = "Change Profile";
            this.buttonChangeProfile.UseVisualStyleBackColor = true;
            this.buttonChangeProfile.Click += new System.EventHandler(this.ButtonChangeProfile_Click);
            // 
            // labelCharacterLocation
            // 
            this.labelCharacterLocation.AutoSize = true;
            this.labelCharacterLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCharacterLocation.Location = new System.Drawing.Point(282, 26);
            this.labelCharacterLocation.Name = "labelCharacterLocation";
            this.labelCharacterLocation.Size = new System.Drawing.Size(52, 31);
            this.labelCharacterLocation.TabIndex = 5;
            this.labelCharacterLocation.Text = "0;0";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(12, 35);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(252, 38);
            this.textBoxName.TabIndex = 4;
            // 
            // buttonInfo
            // 
            this.buttonInfo.BackgroundImage = global::ValorantAutoPick.Properties.Resources._1200px_Minimalist_info_Icon;
            this.buttonInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonInfo.FlatAppearance.BorderSize = 0;
            this.buttonInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Location = new System.Drawing.Point(391, 120);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(20, 20);
            this.buttonInfo.TabIndex = 8;
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // FormChangeProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 152);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.labelSelectLocation);
            this.Controls.Add(this.buttonChangeProfile);
            this.Controls.Add(this.labelCharacterLocation);
            this.Controls.Add(this.textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormChangeProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Profile";
            this.Load += new System.EventHandler(this.FormChangeProfile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectLocation;
        private System.Windows.Forms.Button buttonChangeProfile;
        private System.Windows.Forms.Label labelCharacterLocation;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonInfo;
    }
}