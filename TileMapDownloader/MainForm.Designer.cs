namespace TileMapDownloader
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.downloadProgressBar = new MaterialSkin.Controls.MaterialProgressBar();
            this.downloadButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.destinationTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.sourceTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.yMaximumTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.yMinimumTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.xMaximumTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.xMinimumTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.threadsTimer = new System.Windows.Forms.Timer(this.components);
            this.abortButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.mainPanel.Controls.Add(this.abortButton);
            this.mainPanel.Controls.Add(this.downloadProgressBar);
            this.mainPanel.Controls.Add(this.downloadButton);
            this.mainPanel.Controls.Add(this.destinationTextField);
            this.mainPanel.Controls.Add(this.sourceTextField);
            this.mainPanel.Controls.Add(this.yMaximumTextField);
            this.mainPanel.Controls.Add(this.yMinimumTextField);
            this.mainPanel.Controls.Add(this.xMaximumTextField);
            this.mainPanel.Controls.Add(this.xMinimumTextField);
            this.mainPanel.Location = new System.Drawing.Point(12, 64);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(376, 227);
            this.mainPanel.TabIndex = 0;
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadProgressBar.Depth = 0;
            this.downloadProgressBar.Location = new System.Drawing.Point(3, 219);
            this.downloadProgressBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(370, 5);
            this.downloadProgressBar.Step = 1;
            this.downloadProgressBar.TabIndex = 7;
            this.downloadProgressBar.Visible = false;
            // 
            // downloadButton
            // 
            this.downloadButton.AutoSize = true;
            this.downloadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.downloadButton.Depth = 0;
            this.downloadButton.Icon = null;
            this.downloadButton.Location = new System.Drawing.Point(3, 177);
            this.downloadButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Primary = true;
            this.downloadButton.Size = new System.Drawing.Size(96, 36);
            this.downloadButton.TabIndex = 6;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // destinationTextField
            // 
            this.destinationTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destinationTextField.Depth = 0;
            this.destinationTextField.Hint = "Destination...";
            this.destinationTextField.Location = new System.Drawing.Point(3, 148);
            this.destinationTextField.MaxLength = 32767;
            this.destinationTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.destinationTextField.Name = "destinationTextField";
            this.destinationTextField.PasswordChar = '\0';
            this.destinationTextField.SelectedText = "";
            this.destinationTextField.SelectionLength = 0;
            this.destinationTextField.SelectionStart = 0;
            this.destinationTextField.Size = new System.Drawing.Size(370, 23);
            this.destinationTextField.TabIndex = 5;
            this.destinationTextField.TabStop = false;
            this.destinationTextField.UseSystemPasswordChar = false;
            // 
            // sourceTextField
            // 
            this.sourceTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceTextField.Depth = 0;
            this.sourceTextField.Hint = "Source...";
            this.sourceTextField.Location = new System.Drawing.Point(3, 119);
            this.sourceTextField.MaxLength = 32767;
            this.sourceTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.sourceTextField.Name = "sourceTextField";
            this.sourceTextField.PasswordChar = '\0';
            this.sourceTextField.SelectedText = "";
            this.sourceTextField.SelectionLength = 0;
            this.sourceTextField.SelectionStart = 0;
            this.sourceTextField.Size = new System.Drawing.Size(370, 23);
            this.sourceTextField.TabIndex = 4;
            this.sourceTextField.TabStop = false;
            this.sourceTextField.UseSystemPasswordChar = false;
            // 
            // yMaximumTextField
            // 
            this.yMaximumTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMaximumTextField.Depth = 0;
            this.yMaximumTextField.Hint = "Y maximum...";
            this.yMaximumTextField.Location = new System.Drawing.Point(3, 90);
            this.yMaximumTextField.MaxLength = 32767;
            this.yMaximumTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.yMaximumTextField.Name = "yMaximumTextField";
            this.yMaximumTextField.PasswordChar = '\0';
            this.yMaximumTextField.SelectedText = "";
            this.yMaximumTextField.SelectionLength = 0;
            this.yMaximumTextField.SelectionStart = 0;
            this.yMaximumTextField.Size = new System.Drawing.Size(370, 23);
            this.yMaximumTextField.TabIndex = 3;
            this.yMaximumTextField.TabStop = false;
            this.yMaximumTextField.UseSystemPasswordChar = false;
            // 
            // yMinimumTextField
            // 
            this.yMinimumTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMinimumTextField.Depth = 0;
            this.yMinimumTextField.Hint = "Y minimum...";
            this.yMinimumTextField.Location = new System.Drawing.Point(3, 61);
            this.yMinimumTextField.MaxLength = 32767;
            this.yMinimumTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.yMinimumTextField.Name = "yMinimumTextField";
            this.yMinimumTextField.PasswordChar = '\0';
            this.yMinimumTextField.SelectedText = "";
            this.yMinimumTextField.SelectionLength = 0;
            this.yMinimumTextField.SelectionStart = 0;
            this.yMinimumTextField.Size = new System.Drawing.Size(370, 23);
            this.yMinimumTextField.TabIndex = 2;
            this.yMinimumTextField.TabStop = false;
            this.yMinimumTextField.UseSystemPasswordChar = false;
            // 
            // xMaximumTextField
            // 
            this.xMaximumTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMaximumTextField.Depth = 0;
            this.xMaximumTextField.Hint = "X maximum...";
            this.xMaximumTextField.Location = new System.Drawing.Point(3, 32);
            this.xMaximumTextField.MaxLength = 32767;
            this.xMaximumTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.xMaximumTextField.Name = "xMaximumTextField";
            this.xMaximumTextField.PasswordChar = '\0';
            this.xMaximumTextField.SelectedText = "";
            this.xMaximumTextField.SelectionLength = 0;
            this.xMaximumTextField.SelectionStart = 0;
            this.xMaximumTextField.Size = new System.Drawing.Size(370, 23);
            this.xMaximumTextField.TabIndex = 1;
            this.xMaximumTextField.TabStop = false;
            this.xMaximumTextField.UseSystemPasswordChar = false;
            // 
            // xMinimumTextField
            // 
            this.xMinimumTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMinimumTextField.Depth = 0;
            this.xMinimumTextField.Hint = "X minimum...";
            this.xMinimumTextField.Location = new System.Drawing.Point(3, 3);
            this.xMinimumTextField.MaxLength = 32767;
            this.xMinimumTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.xMinimumTextField.Name = "xMinimumTextField";
            this.xMinimumTextField.PasswordChar = '\0';
            this.xMinimumTextField.SelectedText = "";
            this.xMinimumTextField.SelectionLength = 0;
            this.xMinimumTextField.SelectionStart = 0;
            this.xMinimumTextField.Size = new System.Drawing.Size(370, 23);
            this.xMinimumTextField.TabIndex = 0;
            this.xMinimumTextField.TabStop = false;
            this.xMinimumTextField.UseSystemPasswordChar = false;
            // 
            // threadsTimer
            // 
            this.threadsTimer.Enabled = true;
            this.threadsTimer.Interval = 200;
            this.threadsTimer.Tick += new System.EventHandler(this.threadsTimer_Tick);
            // 
            // abortButton
            // 
            this.abortButton.AutoSize = true;
            this.abortButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.abortButton.Depth = 0;
            this.abortButton.Enabled = false;
            this.abortButton.Icon = null;
            this.abortButton.Location = new System.Drawing.Point(105, 177);
            this.abortButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.abortButton.Name = "abortButton";
            this.abortButton.Primary = true;
            this.abortButton.Size = new System.Drawing.Size(65, 36);
            this.abortButton.TabIndex = 8;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Click += new System.EventHandler(this.abortButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 303);
            this.Controls.Add(this.mainPanel);
            this.MaximumSize = new System.Drawing.Size(1200, 303);
            this.MinimumSize = new System.Drawing.Size(400, 303);
            this.Name = "MainForm";
            this.Text = "Tile map downloader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private MaterialSkin.Controls.MaterialProgressBar downloadProgressBar;
        private MaterialSkin.Controls.MaterialRaisedButton downloadButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField destinationTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField sourceTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField yMaximumTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField yMinimumTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField xMaximumTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField xMinimumTextField;
        private System.Windows.Forms.Timer threadsTimer;
        private MaterialSkin.Controls.MaterialRaisedButton abortButton;
    }
}

