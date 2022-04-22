namespace Test3
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.wmpPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.openBtn = new System.Windows.Forms.Button();
            this.listFile = new System.Windows.Forms.ListBox();
            this.speedUpDownHandler = new System.Windows.Forms.NumericUpDown();
            this.lblAdjSpeed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedUpDownHandler)).BeginInit();
            this.SuspendLayout();
            // 
            // wmpPlayer
            // 
            this.wmpPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wmpPlayer.Enabled = true;
            this.wmpPlayer.Location = new System.Drawing.Point(-3, 0);
            this.wmpPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.wmpPlayer.Name = "wmpPlayer";
            this.wmpPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpPlayer.OcxState")));
            this.wmpPlayer.Size = new System.Drawing.Size(811, 455);
            this.wmpPlayer.TabIndex = 0;
            this.wmpPlayer.KeyUpEvent += new AxWMPLib._WMPOCXEvents_KeyUpEventHandler(this.spacePauseEvent);
            // 
            // openBtn
            // 
            this.openBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openBtn.Location = new System.Drawing.Point(819, 415);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 1;
            this.openBtn.Text = "&Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // listFile
            // 
            this.listFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listFile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listFile.FormattingEnabled = true;
            this.listFile.Location = new System.Drawing.Point(819, 13);
            this.listFile.Name = "listFile";
            this.listFile.Size = new System.Drawing.Size(75, 340);
            this.listFile.TabIndex = 2;
            this.listFile.SelectedIndexChanged += new System.EventHandler(this.listFile_SelectedIndexChanged);
            // 
            // speedUpDownHandler
            // 
            this.speedUpDownHandler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.speedUpDownHandler.DecimalPlaces = 1;
            this.speedUpDownHandler.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.speedUpDownHandler.Location = new System.Drawing.Point(819, 389);
            this.speedUpDownHandler.Name = "speedUpDownHandler";
            this.speedUpDownHandler.Size = new System.Drawing.Size(75, 20);
            this.speedUpDownHandler.TabIndex = 3;
            this.speedUpDownHandler.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speedUpDownHandler.ValueChanged += new System.EventHandler(this.speedUpDownHandler_ValueChanged);
            this.speedUpDownHandler.Click += new System.EventHandler(this.speedUpDownHandler_Click);
            // 
            // lblAdjSpeed
            // 
            this.lblAdjSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdjSpeed.AutoSize = true;
            this.lblAdjSpeed.Location = new System.Drawing.Point(819, 370);
            this.lblAdjSpeed.Name = "lblAdjSpeed";
            this.lblAdjSpeed.Size = new System.Drawing.Size(70, 13);
            this.lblAdjSpeed.TabIndex = 4;
            this.lblAdjSpeed.Text = "Adjust Speed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 450);
            this.Controls.Add(this.lblAdjSpeed);
            this.Controls.Add(this.speedUpDownHandler);
            this.Controls.Add(this.listFile);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.wmpPlayer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedUpDownHandler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer wmpPlayer;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.ListBox listFile;
        private System.Windows.Forms.NumericUpDown speedUpDownHandler;
        private System.Windows.Forms.Label lblAdjSpeed;
    }
}

