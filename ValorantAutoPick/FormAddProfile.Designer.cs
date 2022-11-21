namespace ValorantAutoPick
{
    partial class FormAddProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddProfile));
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelCharacterLocation = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelSelectLocation = new System.Windows.Forms.Label();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(12, 30);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(252, 38);
            this.textBoxName.TabIndex = 0;
            // 
            // labelCharacterLocation
            // 
            this.labelCharacterLocation.AutoSize = true;
            this.labelCharacterLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCharacterLocation.Location = new System.Drawing.Point(282, 21);
            this.labelCharacterLocation.Name = "labelCharacterLocation";
            this.labelCharacterLocation.Size = new System.Drawing.Size(52, 31);
            this.labelCharacterLocation.TabIndex = 1;
            this.labelCharacterLocation.Text = "0;0";
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.Location = new System.Drawing.Point(81, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add Profile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonAddProfile_Click);
            // 
            // labelSelectLocation
            // 
            this.labelSelectLocation.AutoSize = true;
            this.labelSelectLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSelectLocation.Location = new System.Drawing.Point(282, 66);
            this.labelSelectLocation.Name = "labelSelectLocation";
            this.labelSelectLocation.Size = new System.Drawing.Size(52, 31);
            this.labelSelectLocation.TabIndex = 3;
            this.labelSelectLocation.Text = "0;0";
            // 
            // buttonInfo
            // 
            this.buttonInfo.BackgroundImage = global::ValorantAutoPick.Properties.Resources._1200px_Minimalist_info_Icon;
            this.buttonInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonInfo.FlatAppearance.BorderSize = 0;
            this.buttonInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Location = new System.Drawing.Point(387, 116);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(20, 20);
            this.buttonInfo.TabIndex = 4;
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // FormAddProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 148);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.labelSelectLocation);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelCharacterLocation);
            this.Controls.Add(this.textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAddProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Profile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddProfile_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelCharacterLocation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelSelectLocation;
        private System.Windows.Forms.Button buttonInfo;
    }
}