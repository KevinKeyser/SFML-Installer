namespace SFMLInstaller
{
    partial class Installer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installer));
            this.installButton = new System.Windows.Forms.Button();
            this.installProgressBar = new System.Windows.Forms.ProgressBar();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.infoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // installButton
            // 
            this.installButton.Location = new System.Drawing.Point(103, 188);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(75, 23);
            this.installButton.TabIndex = 0;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // installProgressBar
            // 
            this.installProgressBar.Location = new System.Drawing.Point(12, 141);
            this.installProgressBar.Name = "installProgressBar";
            this.installProgressBar.Size = new System.Drawing.Size(260, 23);
            this.installProgressBar.TabIndex = 1;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.logoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(260, 123);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 2;
            this.logoPictureBox.TabStop = false;
            // 
            // progressTimer
            // 
            this.progressTimer.Interval = 1;
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // infoLabel
            // 
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.Location = new System.Drawing.Point(12, 167);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(260, 18);
            this.infoLabel.TabIndex = 3;
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Installer
            // 
            this.AcceptButton = this.installButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 223);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.installProgressBar);
            this.Controls.Add(this.installButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Installer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SFML Install";
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.ProgressBar installProgressBar;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Timer progressTimer;
        private System.Windows.Forms.Label infoLabel;
    }
}

